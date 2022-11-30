using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRifa.DTOs;
using WebApiRifa.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiRifa.Controllers
{
    [ApiController]
    [Route("rifa")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class RifaController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public RifaController(ApplicationDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetRifaDTO>>> Get()
        {
            var rifas = await dbContext.Rifas.ToListAsync();
            return mapper.Map<List<GetRifaDTO>>(rifas);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RifaDTO rifaDTO)
        {
            var existeRifaMismoNombre = await dbContext.Rifas.AnyAsync(x => x.Nombre == rifaDTO.Nombre);

            if (existeRifaMismoNombre)
            {
                return BadRequest("Ya existe una pelicula con ese nombre");
            }

            var rifa = mapper.Map<Rifa>(rifaDTO);
            dbContext.Add(rifa);
            await dbContext.SaveChangesAsync();
            var peliculaDto = mapper.Map<GetRifaDTO>(rifa);

            return CreatedAtRoute("obtenerpelicula", new { id = rifa.Id }, rifaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(RifaDTO rifaCreacionDTO, int id)
        {
            var exist = await dbContext.Rifas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }

            var rifa = mapper.Map<Rifa>(rifaCreacionDTO);
            rifa.Id = id;

            dbContext.Update(rifa);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Rifas.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound();
            }
            dbContext.Remove(new Rifa()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
