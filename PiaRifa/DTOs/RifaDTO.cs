using System.ComponentModel.DataAnnotations;
using WebApiRifa.Validaciones;

namespace WebApiRifa.DTOs
{
    public class RifaDTO
    {
        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(maximumLength: 30, ErrorMessage = "Solo pueden ser 30 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
