using System;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaRP.Web.Data.Entities
{
    public class Historia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [Display(Name = "Descripción")]
        [MaxLength(50, ErrorMessage = DataContext.LenghtError)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = DataContext.RequiredError)]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Comentarios { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:YYYY/MM/DD HH:MM}", ApplyFormatInEditMode = true)]
        public DateTime FechaLocal => Fecha.ToLocalTime();

        public TipoServicio TipoServicio { get; set; }

        public Mascota Mascota { get; set; }
    }
}
