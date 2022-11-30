using AutoMapper;
using WebApiRifa.DTOs;
using WebApiRifa.Entidades;

namespace WebApiRifa.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RifaDTO, Rifa>();
            CreateMap<Rifa, GetRifaDTO>();
            CreateMap<Rifa, RifaConParticipanteDTO>()
                .ForMember(rifaDTO => rifaDTO.Participante, opciones => opciones.MapFrom(MapRifaDTOParticipante));
        }

        private List<ParticipanteDTO> MapRifaDTOParticipante(Rifa rifa, GetRifaDTO getRifaDTO)
        {
            var result = new List<ParticipanteDTO>();
            
            if(rifa.RifaParticipantes == null) { return result; }

            foreach(var rifaParticipante in rifa.RifaParticipantes)
            {
                result.Add(new ParticipanteDTO(){
                    Id=rifaParticipante.ParticipanteId,
                        Nombre = rifaParticipante.Participante.Nombre
                });
            }
            return result;
        } 
    }
}
