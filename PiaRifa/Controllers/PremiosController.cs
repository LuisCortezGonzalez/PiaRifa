using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRifa.DTOs;
using WebApiRifa.Entidades;

namespace WebApiRifa.Controllers
{
    [ApiController]
    [Route("RegistroPremiosDeRifa/")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Administrador")]
    public class PremiosController : ControllerBase
    {
        private readonly ApplicationDbContext dBContext;
        private readonly IMapper mapper;

        public PremiosController(ApplicationDbContext context,
           IMapper mapper)
        {
            this.mapper = mapper;
            this.dBContext = context;
        }

        [HttpPut("ModificarPremio/{id:int}")]
        public async Task<ActionResult> put(int id, PremioCreacionDTO premioCreacionDTO)
        {
            var exist = await dBContext.Premios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            var premios = mapper.Map<Premios>(premioCreacionDTO);
            premios.Id = id;

            dBContext.Update(premios);
            await dBContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
