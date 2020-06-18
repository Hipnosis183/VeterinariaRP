using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Nombre { get; set; }

        [Display(Name = "Imagen")]
        public string ImagenUrl { get; set; }

        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Raza { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD}", ApplyFormatInEditMode = true)]
        public DateTime Nacimiento { get; set; }

        public string Comentarios { get; set; }

        public string ImagenFullPath => String.IsNullOrEmpty(ImagenUrl)
            ? null
            : $"htps://{ImagenUrl.Substring(1)}";

        [Display(Name = "Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD}", ApplyFormatInEditMode = true)]
        public DateTime NacimientoLocal => Nacimiento.ToLocalTime();

        public TipoMascota TipoMascota { get; set; }

        public Propietario Propietario { get; set; }

        public ICollection<Historia> Historias { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
