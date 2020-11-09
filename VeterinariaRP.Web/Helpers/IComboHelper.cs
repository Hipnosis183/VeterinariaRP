using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace VeterinariaRP.Web.Helpers
{
    public interface IComboHelper
    {
        IEnumerable<SelectListItem> GetComboTipoMascota();

        IEnumerable<SelectListItem> GetComboTipoServicio();
    }
}