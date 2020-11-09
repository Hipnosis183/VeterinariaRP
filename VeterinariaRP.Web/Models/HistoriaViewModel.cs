using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Models
{
    public class HistoriaViewModel : Historia
    {
        public int MascotaId { get; set; }

        [Display(Name = "Tipo de Servicio")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de servicio.")]
        public int TipoServicioId { get; set; }

        public IEnumerable<SelectListItem> TipoServicios { get; set; }
    }
}
