using System.ComponentModel.DataAnnotations;

namespace WebApiRifa.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
