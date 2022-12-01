using System.ComponentModel.DataAnnotations;
using WebApiRifa.Validaciones;

namespace WebApiRifa.DTOs
{
    public class RifaCreacionDTO
    {
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(maximumLength: 30, ErrorMessage = "Solo pueden ser 30 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public List<PremioCreacionDTO> premios { get; set; }
    }
}
