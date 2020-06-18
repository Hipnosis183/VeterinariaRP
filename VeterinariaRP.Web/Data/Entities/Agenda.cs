using System;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Agenda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Comentarios { get; set; }

        [Display(Name = "¿Está Disponible?")]
        public bool IsDisponible { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime FechaLocal => Fecha.ToLocalTime();

        public Propietario Propietario { get; set; }

        public Mascota Mascota { get; set; }
    }
}
