using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApiRifa.DTOs;
using WebApiRifa.Entidades;

namespace WebApiRifa.Controllers
{
        [ApiController]
        [Route("SistemaDeInscripciones/")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Administrador")]
        public class ParticipanteController : ControllerBase
        {
            private readonly ApplicationDbContext dBContext;
            private readonly IMapper mapper;

            public ParticipanteController(ApplicationDbContext context, IMapper mapper)
            {
                this.mapper = mapper;
                this.dBContext = context;
            }

            [HttpGet("ObtenerParticipante/{id:int}", Name = "ObtenerPartcipante")]
            public async Task<ActionResult<ParticipanteDTO>> Get(int id)
            {
                var participante = await dBContext.Participantes.FirstOrDefaultAsync(x => x.Id == id);
                var usuario = await dBContext.Users.FirstAsync(x => x.Id == participante.UserId);
                if (usuario == null)
                {
                    return NotFound("El ususario relacionado al particpante no fue encontrado");
                }
                if (participante == null)
                {
                    return BadRequest("El participante no fue encontrado");
                }
                var participanteDTO = mapper.Map<ParticipanteDTO>(participante);
                /*participanteDTO.Nombres = usuario.UserName;
                participanteDTO.email = usuario.Email;*/
                return participanteDTO;
            }

            [HttpPost("AltaParticipante")]
            public async Task<ActionResult> Post(ParticipanteCreacionDTO participanteCreacionDTO)
            {
                var nuevoElemento = mapper.Map<Participante>(participanteCreacionDTO);
                dBContext.Add(nuevoElemento);
                var nuevaVista = mapper.Map<ParticipanteDTO>(nuevoElemento);
                await dBContext.SaveChangesAsync();
                return CreatedAtRoute("ObtenerPartcipante", new { id = nuevoElemento.Id }, nuevaVista);
            }

            [HttpGet("ObtenerInscripcionesParticipante/{id:int}", Name = "ObtenerParticipacion")]
            public async Task<ActionResult> GetParticipacion(int id)
            {
                var inscripciones = await dBContext.RifaParticipantes.Where(x => x.ParticipanteId == id.ToString()).ToListAsync();
                var salida = new ParticipanteConCartasConRifaSalidaDTO();
                foreach (var i in inscripciones)
                {
                    salida.cartasDTO.Add(Convert.ToInt32(i.CartaId));
                    salida.rifaDTO.Add(Convert.ToInt32(i.RifaId));
                }
                return Ok(salida);
            }

            [HttpPost("inscripcionRifa/{idRifa:int}/Participante/{idParticipante:int}/Carta/{idCarta:int}")]
            public async Task<ActionResult> PostInscripcion(int idRifa, int idParticipante, int idCarta)
            {
                var elementoRifa = await dBContext.Rifas.AnyAsync(x => x.Id == idRifa);
                if (!elementoRifa)
                {
                    return NotFound("No se encontro la rifa undicada");
                }

                var elementoParticipante = await dBContext.Participantes.AnyAsync(x => x.Id == idParticipante);
                if (!elementoParticipante)
                {
                    return NotFound("No se encontro el participante indicado");
                }

                var elementoCartas = await dBContext.Cartas.AnyAsync(x => x.Id == idCarta);
                if (!elementoCartas)
                {
                    return NotFound("No el id de la carta no es indicado");
                }

                try
                {
                    var elemento = await dBContext.RifaParticipantes.SingleAsync(x => x.RifaId == idRifa.ToString() && x.ParticipanteId == idParticipante.ToString());
                    return BadRequest("El participante ya se encuentra participando en esta rifa");
                }
                catch (Exception ex)
                {
                    var cantidadDePraticipantes = await dBContext.RifaParticipantes.Where(x => x.RifaId == idRifa.ToString()).ToListAsync();

                    if (!(cantidadDePraticipantes.Count() <= 54))
                    {
                        return BadRequest("La rifa ya esta llena");
                    }

                    var validacionCarta = await dBContext.RifaParticipantes.AnyAsync(x => x.RifaId == idRifa.ToString() && x.CartaId == idCarta.ToString());
                    if (validacionCarta)
                    {
                        return BadRequest("La carta que se ingreso ya esta en juego en la rifa indicada");
                    }
                    var carta = await dBContext.Cartas.FirstAsync(x => x.Id == idCarta);
                    var rifa = await dBContext.Rifas.FirstAsync(x => x.Id == idRifa);
                    var participante = await dBContext.Participantes.FirstAsync(x => x.Id == idParticipante);
                    var nuevoElemento = new RifaParticipante()
                    {
                        CartaId = carta.Id.ToString(),
                        ParticipanteId = participante.Id.ToString(),
                        RifaId= rifa.Id.ToString(),
                        Cartas = carta,
                        Participante = participante,
                        Rifa = rifa,
                    };
                    dBContext.Add(nuevoElemento);
                    var nuevaVista = mapper.Map<ParticipanteConCartasConRifa>(nuevoElemento);
                    await dBContext.SaveChangesAsync();
                    return CreatedAtRoute("ObtenerParticipacion", new { id = Convert.ToInt32(nuevaVista.ParticipanteDTO) }, nuevaVista);
                }


            }

            [HttpPut("ModificarParticipante/{id:int}")]
            public async Task<ActionResult> Put(ParticipanteCreacionDTO participanteCreacionDTO, int id)
            {
                var exist = await dBContext.Participantes.AnyAsync(x => x.Id == id);
                if (!exist)
                {
                    return BadRequest("El elemento no existe");
                }
                var participante = mapper.Map<Rifa>(participanteCreacionDTO);
                participante.Id = id;
                dBContext.Update(participante);
                await dBContext.SaveChangesAsync();
                return Ok();
            }
        }
}
