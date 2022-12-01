using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRifa.DTOs;
using WebApiRifa.Services;

namespace WebApiRifa.Controllers
{
    [ApiController]
    [Route("ResultadosDeRifa/")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Administrador")]
    public class GanadoresController : ControllerBase
    {
        private readonly ApplicationDbContext dBContext;
        private readonly IService service;
        private readonly IWebHostEnvironment env;
        private readonly string archivoGanadores = "Registrosdellamada.txt";

        public GanadoresController(ApplicationDbContext context, IWebHostEnvironment env,
            IService service)
        {
            this.dBContext = context;
            this.env = env;
            this.service = service;
        }

        [HttpGet("GanadorRifa/{id:int}")]
        public async Task<ActionResult<List<ParticipanteDTO>>> post(int id)
        {
            var rifa = dBContext.Rifas
                .Include(p => p.premios)
                .Include(rpc => rpc.RifaParticipantes)
                .ThenInclude(p => p.Participante)
                .FirstOrDefault(x => x.Id == id);
            if (rifa == null)
            {
                return NotFound("No se encontro la rifa solicitada");
            }

            if (rifa.premios.Count != 6)
            {
                return NotFound("No se cuentan con los premios suficientes");
            }

            System.Console.WriteLine($"<{rifa.RifaParticipantes.Count}>");
            if (rifa.RifaParticipantes.Count != 54)
            {
                return NotFound("No se cuentan con la cantidad suficientes de participantes");
            }

            var mazo = await dBContext.Cartas.ToListAsync();
            var con = 6;
            mazo = service.EjecutarSeleccion(mazo);
            var lista = new List<GanadorDTO>();
            foreach (var c in mazo.Take(6))
            {
                var participanteGanador = rifa.RifaParticipantes.FirstOrDefault(x => (x.RifaId == id.ToString()) && (x.CartaId == c.Id.ToString()));
                var participante = await dBContext.Participantes.FirstAsync(x => x.Id.ToString() == participanteGanador.ParticipanteId);
                lista.Add(new GanadorDTO
                {
                    NombreRifa = rifa.Nombre,
                    Participante = new ParticipanteDTO()
                    {
                        Nombre = participante.Nombre,
                        
                    },
                    Premios = new PremiosDTO()
                    {
                        premios = participante.Nombre
                        
                    }
                });
                con--;
            }

            return Ok(lista);
        }
       
    }
}
