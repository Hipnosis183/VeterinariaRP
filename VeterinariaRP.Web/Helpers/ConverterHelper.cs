using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaRP.Web.Data.Entities;
using VeterinariaRP.Web.Models;

namespace VeterinariaRP.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _DataContext;

        public ConverterHelper(DataContext DataContext)
        {
            _DataContext = DataContext;
        }

        public async Task<Mascota> ToMascotaAsync(MascotaViewModel Model, string Ruta)
        {
            return new Mascota
            {
                Agendas = Model.Agendas,
                Nacimiento = Model.Nacimiento,
                Historias = Model.Historias,
                //Id = Model.Id,
                ImagenUrl = Model.ImagenUrl,
                Nombre = Model.Nombre,
                Propietario = await _DataContext.Propietarios.FindAsync(Model.PropietarioId),
                TipoMascota = await _DataContext.TipoMascotas.FindAsync(Model.TipoMascotaId),
                Raza = Model.Raza,
                Comentarios = Model.Comentarios
            };
        }
    }
}
