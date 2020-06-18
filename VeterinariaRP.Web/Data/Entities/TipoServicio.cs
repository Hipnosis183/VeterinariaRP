using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class TipoServicio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [Display(Name = "Tipo Servicio")]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Nombre { get; set; }

        public ICollection<Historia> Historias { get; set; }
    }
}
