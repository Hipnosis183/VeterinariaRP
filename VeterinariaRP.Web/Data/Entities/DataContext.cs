using Microsoft.EntityFrameworkCore;

namespace VeterinariaRP.Web.Data.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Propietario> Propietarios { get; set; }
    }
}
