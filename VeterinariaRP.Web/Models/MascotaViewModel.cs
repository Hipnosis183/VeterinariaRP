using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Models
{
    public class MascotaViewModel : Mascota
    {
        public int PropietarioId { get; set; }

        [Display(Name = "Tipo de Mascota")]
        [Required(ErrorMessage = DataContext.RequiredError)]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un tipo de mascota.")]
        public int TipoMascotaId { get; set; }

        [Display(Name = "Imagen")]
        public IFormFile ArchivoImagen { get; set; }

        public IEnumerable<SelectListItem> TipoMascota { get; set; }
    }
}
