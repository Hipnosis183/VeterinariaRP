using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using VeterinariaRP.Web.Helpers;
using VeterinariaRP.Web.Models;

namespace VeterinariaRP.Web.Controllers
{
    public class CuentaController : Controller
    {
        private readonly IUserHelper _UserHelper;

        public CuentaController(IUserHelper UserHelper)
        {
            _UserHelper = UserHelper;
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (ModelState.IsValid)
            {
                var Result = await _UserHelper.LoginAsync(Model);

                if (Result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Usuario o contraseña no válida.");
            }

            return View(Model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(LoginViewModel Model)
        {
            await _UserHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
