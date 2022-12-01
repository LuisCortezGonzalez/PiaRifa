using System.ComponentModel.DataAnnotations;
using WebApiRifa.Validaciones;

namespace WebApiRifa.Entidades
{
    public class Participante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(maximumLength: 100, ErrorMessage = "Solo pueden ser 100 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public string UserId { get; set; }

        public List<RifaParticipante> RifaParticipantes { get; set; }
    }
}
