using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinariaRP.Web.Helpers
{
    public class ImagenHelper : IImagenHelper
    {
        public async Task<string> UploadImageAsync(IFormFile ArchivoImagen)
        {
            string GUID = Guid.NewGuid().ToString();
            string Archivo = $"{GUID}.jpg";

            string Ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Mascotas", Archivo);

            using (FileStream Stream = new FileStream(Ruta, FileMode.Create))
            {
                await ArchivoImagen.CopyToAsync(Stream);
            }

            Ruta = $"~/images/Mascotas/{Archivo}";

            return Ruta;
        }
    }
}
