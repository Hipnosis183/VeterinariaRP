using System.Collections.Generic;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Propietario
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Mascota> Mascotas { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
