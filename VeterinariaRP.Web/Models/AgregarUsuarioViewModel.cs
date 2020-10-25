using System.ComponentModel.DataAnnotations;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Models
{
    public class AgregarUsuarioViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage =DataContext.RequiredError)]
        [MaxLength(100, ErrorMessage = DataContext.LenghtError)]
        [EmailAddress]
        public string NombreUsuario { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(20, ErrorMessage = DataContext.LenghtError)]
        public string Documento { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Apellido { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(100, ErrorMessage = DataContext.LenghtError)]
        public string Direccion { get; set; }

        [Display(Name = "Número de Teléfono")]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Telefono { get; set; }

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
