using System.Collections.Generic;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Propietario
    {
        public int Id { get; set; }

        public User User { get; set; }

        /*
        [Required(ErrorMessage = DataContext.RequiredError)]
        [Display(Name = "Teléfono Celular")]
        [MaxLength(20, ErrorMessage = DataContext.LenghtError)]
        public string TelCelular { get; set; }

        [Display(Name = "Teléfono Fijo")]
        [MaxLength(20, ErrorMessage = DataContext.LenghtError)]
        public string TelFijo { get; set; }
        */

        public ICollection<Mascota> Mascotas { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
