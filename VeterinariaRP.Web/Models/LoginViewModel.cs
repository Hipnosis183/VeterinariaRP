using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string NombreUsuario { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool Recordarme { get; set; }
    }
}
