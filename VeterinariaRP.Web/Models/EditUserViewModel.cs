using System.ComponentModel.DataAnnotations;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

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
    }
}
