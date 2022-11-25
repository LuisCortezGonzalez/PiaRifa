using System.ComponentModel.DataAnnotations;
using WebApiRifa.Entidades;
using WebApiRifa.Validaciones;

namespace WebApiRifa.DTOs
{
    public class ParticipanteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        [StringLength(maximumLength: 100, ErrorMessage = "Solo pueden ser 100 caracteres.")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        public List<NumRifa> NumRifa { get; set; }
    }
}
