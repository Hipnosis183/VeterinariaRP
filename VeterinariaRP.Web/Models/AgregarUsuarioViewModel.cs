using System.ComponentModel.DataAnnotations;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Models
{
    public class AgregarUsuarioViewModel : EditUserViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage =DataContext.RequiredError)]
        [MaxLength(100, ErrorMessage = DataContext.LenghtError)]
        [EmailAddress]
        public string NombreUsuario { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = DataContext.LenghtError2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = DataContext.LenghtError2)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
