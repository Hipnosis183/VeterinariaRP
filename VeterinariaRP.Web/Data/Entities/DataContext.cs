using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaRP.Web.Data.Entities
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Propietario> Propietarios { get; set; }

        public DbSet<TipoMascota> TipoMascotas { get; set; }

        public DbSet<Mascota> Mascotas { get; set; }

        public DbSet<TipoServicio> TipoServicios { get; set; }

        public DbSet<Historia> Historias { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public const string RequiredError = "El campo {0} es obligatorio.";
        public const string LenghtError = "El campo {0} no puede tener más de {1} caracteres.";
    }
}
