using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Propietario
    {
        private const string RequiredError = "El campo {0} es obligatorio.";
        private const string LenghtError = "El campo {0} no puede tener más de {1} caracteres.";

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [MaxLength(30, ErrorMessage = LenghtError)]
        public string Documento { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [MaxLength(50, ErrorMessage = LenghtError)]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = RequiredError)]
        [MaxLength(50, ErrorMessage = LenghtError)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = RequiredError)]
        [Display(Name = "Teléfono Celular")]
        [MaxLength(20, ErrorMessage = LenghtError)]
        public string TelCelular { get; set; }

        [Display(Name = "Teléfono Fijo")]
        [MaxLength(20, ErrorMessage = LenghtError)]
        public string TelFijo { get; set; }

        [MaxLength(100, ErrorMessage = LenghtError)]
        public string Direccion { get; set; }

        [Display(Name = "Propietario")]
        public string NombreApellido => $"{Nombre} {Apellido}";

        [Display(Name = "Propietario")]
        public string NombreApellidoDocumento =>  $"{Nombre} {Apellido} - {Documento}";
    }
}
