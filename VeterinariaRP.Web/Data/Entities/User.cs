using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(30, ErrorMessage = DataContext.LenghtError)]
        public string Documento { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Apellido { get; set; }

        [MaxLength(100, ErrorMessage = DataContext.LenghtError)]
        public string Direccion { get; set; }

        [Display(Name = "Propietario")]
        public string NombreApellido => $"{Nombre} {Apellido}";

        [Display(Name = "Propietario")]
        public string NombreApellidoDocumento => $"{Nombre} {Apellido} - {Documento}";
    }
}
