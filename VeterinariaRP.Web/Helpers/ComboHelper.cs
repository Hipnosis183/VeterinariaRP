using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Helpers
{
    public class ComboHelper : IComboHelper
    {
        private readonly DataContext _DataContext;

        public ComboHelper(DataContext DataContext)
        {
            _DataContext = DataContext;
        }

        public IEnumerable<SelectListItem> GetComboTipoMascota()
        {
            List<SelectListItem> Lista = _DataContext.TipoMascotas.Select(tm => new SelectListItem
            {
                Text = tm.Nombre,
                Value = $"{tm.Id}"
            }).OrderBy(pt => pt.Text).ToList();

            Lista.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de mascota.]",
                Value = "0"
            });

            return Lista;
        }

        public IEnumerable<SelectListItem> GetComboTipoServicio()
        {
            List<SelectListItem> Lista = _DataContext.TipoServicios.Select(ts => new SelectListItem
            {
                Text = ts.Nombre,
                Value = $"{ts.Id}"
            }).OrderBy(pt => pt.Text).ToList();

            Lista.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de servicio.]",
                Value = "0"
            });

            return Lista;
        }
    }
}
