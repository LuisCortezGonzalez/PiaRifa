using System.ComponentModel.DataAnnotations;
using WebApiRifa.Validaciones;

namespace WebApiRifa.Entidades
{
    public class Rifa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(maximumLength: 30, ErrorMessage = "Solo pueden ser 30 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public List<RifaParticipante> RifaParticipantes { get; set; }
        public List<Premios> premios { get; set; }


    }
}
