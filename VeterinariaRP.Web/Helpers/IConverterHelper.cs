using System.Threading.Tasks;
using VeterinariaRP.Web.Data.Entities;
using VeterinariaRP.Web.Models;

namespace VeterinariaRP.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Mascota> ToMascotaAsync(MascotaViewModel Model, string Ruta);
    }
}