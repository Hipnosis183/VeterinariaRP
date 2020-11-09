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
        private readonly IComboHelper _ComboHelper;

        public ConverterHelper(DataContext DataContext, IComboHelper ComboHelper)
        {
            _DataContext = DataContext;
            _ComboHelper = ComboHelper;
        }

        public async Task<Mascota> ToMascotaAsync(MascotaViewModel Model, string Ruta, bool EsNuevo)
        {
            Mascota Mascota = new Mascota
            {
                Agendas = Model.Agendas,
                Nacimiento = Model.Nacimiento,
                Historias = Model.Historias,
                Id = EsNuevo ? 0 : Model.Id,
                ImagenUrl = Ruta,
                Nombre = Model.Nombre,
                Propietario = await _DataContext.Propietarios.FindAsync(Model.PropietarioId),
                TipoMascota = await _DataContext.TipoMascotas.FindAsync(Model.TipoMascotaId),
                Raza = Model.Raza,
                Comentarios = Model.Comentarios
            };

            return Mascota;
        }

        public MascotaViewModel ToMascotaViewModel(Mascota Mascota)
        {
            return new MascotaViewModel
            {
                Agendas = Mascota.Agendas,
                Nacimiento = Mascota.Nacimiento,
                Historias = Mascota.Historias,
                ImagenUrl = Mascota.ImagenUrl,
                Nombre = Mascota.Nombre,
                Propietario = Mascota.Propietario,
                TipoMascota = Mascota.TipoMascota,
                Raza = Mascota.Raza,
                Comentarios = Mascota.Comentarios,
                Id = Mascota.Id,
                PropietarioId = Mascota.Propietario.Id,
                TipoMascotaId = Mascota.TipoMascota.Id,
                TipoMascotas = _ComboHelper.GetComboTipoMascota()
            };
        }

        public async Task<Historia> ToHistoriaAsync(HistoriaViewModel Model, bool EsNuevo)
        {
            Historia Historia = new Historia
            {
                Fecha = Model.Fecha,
                Descripcion = Model.Descripcion,
                Id = EsNuevo ? 0 : Model.Id,
                Mascota = await _DataContext.Mascotas.FindAsync(Model.MascotaId),
                TipoServicio = await _DataContext.TipoServicios.FindAsync(Model.TipoServicioId),
                Comentarios = Model.Comentarios
            };

            return Historia;
        }

        public HistoriaViewModel ToHistoriaViewModel(Historia Historia)
        {
            return new HistoriaViewModel
            {
                Fecha = Historia.Fecha,
                Mascota = Historia.Mascota,
                TipoServicio = Historia.TipoServicio,
                Descripcion = Historia.Descripcion,
                Comentarios = Historia.Comentarios,
                Id = Historia.Id,
                MascotaId = Historia.Mascota.Id,
                TipoServicioId = Historia.TipoServicio.Id,
                TipoServicios = _ComboHelper.GetComboTipoServicio()
            };
        }
    }
}
