using System.ComponentModel.DataAnnotations;
using WebApiRifa.Validaciones;

namespace WebApiRifa.DTOs
{
    public class ParticipanteCreacionDTO
    {

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(maximumLength: 100, ErrorMessage = "Solo pueden ser 100 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public List<int> RifaId { get; set; }
    }
}
