using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRifa.DTOs;
using WebApiRifa.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace WebApiRifa.Controllers
{
    [ApiController]
    [Route("rifa")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class RifaController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IConfiguration configuration;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public RifaController(ApplicationDbContext dbContext, IConfiguration configuration, IMapper mapper, ILogger logger)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("Premios/Rifa/{id:int}", Name = "GetRifa")]
        //[AllowAnonymous]
        public async Task<ActionResult<RifaConPremiosDTO>> Get(int id)
        {
            var rifa = await dbContext.Rifas
                .Include(p => p.premios)
                .FirstOrDefaultAsync(x => x.Id == id);
            logger.LogInformation("Se extrago el elemento de la base de datos");
            logger.LogInformation(rifa.ToString());
            if (rifa == null)
            {
                logger.LogInformation("No habia nada");
                return NotFound("La rifa no fue encontrada");
            }
            logger.LogInformation("Paso el if");
            return mapper.Map<RifaConPremiosDTO>(rifa);
        }

        [HttpGet("CartasDisponibles/Rifa/{id:int}")]
        public async Task<ActionResult<RifaConCartasDTO>> GetCartas(int id)
        {
            var rifa = await dbContext.Rifas
                .Include(x => x.RifaParticipantes)
                .ThenInclude(x => x.Cartas)
                .FirstOrDefaultAsync(x => x.Id == id);
            logger.LogInformation("informacion extraida");
            logger.LogInformation(rifa.ToString());

            if (rifa == null)
            {
                logger.LogInformation("No habia nada");
                return NotFound("La rifa no fue encontrada");
            }

            var baraja = await dbContext.Cartas
                .ExceptBy(rifa.RifaParticipantes.Select(c => c.Cartas)
                , x => x).ToListAsync();

            if (baraja.Count() != 54)
            {
                return BadRequest("Las cartas no han sido introducidas");
            }

            var rifaFaltantes = new Rifa()
            {
                Id = rifa.Id,
                Nombre = rifa.Nombre,
                premios = rifa.premios,
                RifaParticipantes = new List<RifaParticipante>() { }
            };

            foreach (var i in baraja)
            {
                rifaFaltantes.RifaParticipantes.Add(new RifaParticipante
                {
                    CartaId = i.Id.ToString(),
                    RifaId = rifaFaltantes.Id.ToString(),
                    Cartas = i,
                    Rifa = rifaFaltantes
                });
            }

            logger.LogInformation("Inforacion recreada");
            logger.LogInformation(rifaFaltantes.ToString());
            return mapper.Map<RifaConCartasDTO>(rifaFaltantes);
        }

        [HttpPatch("/Modificaciones/{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<RifaPatchDTO> json)
        {
            if (json == null) { return BadRequest(); }
            logger.LogInformation("Si habia algo en en json patch");
            logger.LogInformation(json.ToString());

            var Rifa = await dbContext.Rifas.AnyAsync(x => x.Id == id);
            logger.LogInformation("Se extrago algo en la base de datos");
            logger.LogInformation(Rifa.ToString());

            if (!Rifa) { return BadRequest(); }
            var rifaDTO = mapper.Map<RifaPatchDTO>(Rifa);
            logger.LogInformation("Se mapeo el elemento");
            logger.LogInformation(rifaDTO.ToString());
            json.ApplyTo(rifaDTO);

            var IsValid = TryValidateModel(rifaDTO);
            if (!IsValid)
            {
                return BadRequest(ModelState);
            }
            logger.LogInformation("Se logro realizar el procedimiento de validacion");

            mapper.Map(rifaDTO, Rifa);
            logger.LogInformation("Se logro realizar el mapeo");

            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("/CreacionDeRifa")]
        public async Task<ActionResult> Post(RifaCreacionDTO rifaCreacionDTO)
        {
            //var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            //var email = emailClaim.Value;
            //var usuario = await userManager.FindByEmailAsync(email);
            //var usuarioId = usuario.Id;

            var existe = await dbContext.Rifas.AnyAsync(x => x.Nombre == rifaCreacionDTO.Nombre);
            logger.LogInformation("Se extrago algo de la base de datos");
            logger.LogInformation(existe.ToString());
            if (existe)
            {
                return BadRequest("Ya se cuenta con una rifa con este nombre");
            }

            if (rifaCreacionDTO.premios.Count != 6)
            {
                return BadRequest("Los premios no cuentan con la cantidad estipulada para la rifa");
            }
            
            var nuevoElemento = mapper.Map<Rifa>(rifaCreacionDTO);
            logger.LogInformation("Se realizo el mapeo");
            logger.LogInformation(nuevoElemento.ToString());
            dbContext.Add(nuevoElemento);
            foreach (var r in nuevoElemento.premios)
            {
                dbContext.Add(r);
            }
            logger.LogInformation("Se agrego el elemento a la base de datos");
            await dbContext.SaveChangesAsync();
            var nuevaVista = mapper.Map<RifaConPremiosDTO>(nuevoElemento);
            logger.LogInformation("Empezamos con el envio de la confirmacion de la creacion");
            logger.LogInformation(nuevaVista.ToString());
            return CreatedAtRoute("GetRifa", new { id = nuevoElemento.Id }, nuevaVista);
        }

        [HttpPost("/AsignacionDeCartas")]
        public async Task<ActionResult> PostCartas(CartasCreacionDTO cartasDTO)
        {
            var exist = await dbContext.Cartas.AnyAsync(x => x.numero == cartasDTO.numero);
            if (exist)
            {
                return BadRequest("Ya existe esa carta");
            }
            var nuevoElemento = mapper.Map<Cartas>(cartasDTO);
            dbContext.Add(nuevoElemento);
            logger.LogInformation("Se agrego el elemento a la base de datos");
            await dbContext.SaveChangesAsync();
            var nuevaVista = mapper.Map<CartasDTO>(nuevoElemento);
            logger.LogInformation("Empezamos con el envio de la confirmacion de la creacion");
            logger.LogInformation(nuevaVista.ToString());
            return CreatedAtRoute("GetRifa", new { id = nuevoElemento.Id }, nuevaVista);
        }

        [HttpDelete("/EliminacionDeRifa/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await dbContext.Rifas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound("El Recurso no fue encontrado.");
            }
            var rifaBorrar = await dbContext.Rifas.Include(x => x.premios).FirstAsync(x => x.Id == id);
            dbContext.Remove(rifaBorrar);

            await dbContext.SaveChangesAsync();
            return Ok();
        }
        
    }
}
