using AutoMapper;
using WebApiRifa.DTOs;
using WebApiRifa.Entidades;

namespace WebApiRifa.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CartasCreacionDTO, Cartas>();
            CreateMap<Cartas, CartasDTO>();
            CreateMap<ParticipanteCreacionDTO, Participante>();
            CreateMap<Participante, ParticipanteDTO>();
            CreateMap<PremioCreacionDTO, Premios>();
            CreateMap<PremiosDTO, Premios>();
            CreateMap<Rifa, RifaConCartasDTO>()
                .ForMember(x => x.CartasDTO, opciones => opciones.MapFrom(MapCartas));
            CreateMap<Rifa, RifaConPremiosDTO>()
                .ForMember(x => x.PremiosDTO, opciones => opciones.MapFrom(MapPremios));
            CreateMap<RifaCreacionDTO, Rifa>()
                .ForMember(x => x.RifaParticipantes, opciones => opciones.MapFrom(MapRifaCreacion));
            CreateMap<RifaPatchDTO, Rifa>().ReverseMap();
            CreateMap<RifaParticipante, ParticipanteConCartasConRifa>();                
        }

        private List<Premios> MapRifaCreacion(RifaCreacionDTO rifaCreacionDTO, Rifa rifa)
        {
            var lista = new List<Premios>();
            if (rifaCreacionDTO.premios == null)
            {
                return lista;
            }

            foreach (var i in rifaCreacionDTO.premios)
            {
                lista.Add(new Premios { RifaId = rifa.Id, premios = i.premios });
            }

            return lista;
        }

        private List<CartasDTO> MapCartas(Rifa rifa, RifaConCartasDTO rifaConCartasDTO)
        {
            var lista = new List<CartasDTO>();
            if (rifa.RifaParticipantes == null)
            {
                return lista;
            }
            foreach (var i in rifa.RifaParticipantes)
            {
                lista.Add(new CartasDTO { numero = i.Cartas.numero, Nombre = i.Cartas.Nombre });
            }
            return lista;
        }

        private List<PremiosDTO> MapPremios(Rifa rifa, RifaConPremiosDTO rifaConPremiosDTO)
        {
            var lista = new List<PremiosDTO>();
            if (rifa == null)
            {
                return lista;
            }
            foreach (var p in rifa.premios)
            {
                lista.Add(new PremiosDTO { premios = p.premios });
            }
            return lista;
        }
    }
}
