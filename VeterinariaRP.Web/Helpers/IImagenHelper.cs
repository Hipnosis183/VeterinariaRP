using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace VeterinariaRP.Web.Helpers
{
    public interface IImagenHelper
    {
        Task<string> UploadImageAsync(IFormFile ArchivoImagen);
    }
}