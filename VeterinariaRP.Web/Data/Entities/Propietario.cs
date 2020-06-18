using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Propietario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(30, ErrorMessage = DataContext.LenghtError)]
        public string Documento { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [Display(Name = "Teléfono Celular")]
        [MaxLength(20, ErrorMessage = DataContext.LenghtError)]
        public string TelCelular { get; set; }

        [Display(Name = "Teléfono Fijo")]
        [MaxLength(20, ErrorMessage = DataContext.LenghtError)]
        public string TelFijo { get; set; }

        [MaxLength(100, ErrorMessage = DataContext.LenghtError)]
        public string Direccion { get; set; }

        [Display(Name = "Propietario")]
        public string NombreApellido => $"{Nombre} {Apellido}";

        [Display(Name = "Propietario")]
        public string NombreApellidoDocumento =>  $"{Nombre} {Apellido} - {Documento}";

        public ICollection<Mascota> Mascotas { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
