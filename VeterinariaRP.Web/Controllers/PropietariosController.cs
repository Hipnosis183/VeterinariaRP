using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeterinariaRP.Web.Data.Entities;
using VeterinariaRP.Web.Helpers;
using VeterinariaRP.Web.Models;

namespace VeterinariaRP.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PropietariosController : Controller
    {
        private readonly DataContext _Context;
        private readonly IUserHelper _UserHelper;
        private readonly IComboHelper _ComboHelper;
        private readonly IConverterHelper _ConverterHelper;
        private readonly IImagenHelper _ImagenHelper;

        public PropietariosController(DataContext context, IUserHelper UserHelper, IComboHelper ComboHelper, IConverterHelper ConverterHelper, IImagenHelper ImagenHelper)
        {
            _Context = context;
            _UserHelper = UserHelper;
            _ComboHelper = ComboHelper;
            _ConverterHelper = ConverterHelper;
            _ImagenHelper = ImagenHelper;
        }

        // GET: Propietarios
        public IActionResult Index()
        {
            return View(_Context.Propietarios
                .Include(p => p.User)
                .Include(p => p.Mascotas));
        }

        // GET: Propietarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _Context.Propietarios
                .Include(p => p.User)
                .Include(p => p.Mascotas)
                .ThenInclude(m => m.TipoMascota)
                .Include(p => p.Mascotas)
                .ThenInclude(m => m.Historias)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // GET: Propietarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgregarUsuarioViewModel Model)
        {
            if (ModelState.IsValid)
            {
                User Usuario = new User
                {
                    Direccion = Model.Direccion,
                    Documento = Model.Documento,
                    Email = Model.NombreUsuario,
                    Nombre = Model.Nombre,
                    Apellido = Model.Apellido,
                    PhoneNumber = Model.Telefono,
                    UserName = Model.NombreUsuario
                };

                IdentityResult Respuesta = await _UserHelper.AddUserAsync(Usuario, Model.Password);

                if (Respuesta.Succeeded)
                {
                    var UsuarioInDB = await _UserHelper.GetUserByEmailAsync(Model.NombreUsuario);
                    await _UserHelper.AddUserToRoleAsync(UsuarioInDB, "Cliente");

                    Propietario Propietario = new Propietario
                    {
                        Agendas = new List<Agenda>(),
                        Mascotas = new List<Mascota>(),
                        User = UsuarioInDB
                    };

                    _Context.Propietarios.Add(Propietario);

                    try
                    {
                        await _Context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }

                    catch (Exception Ex)
                    {
                        ModelState.AddModelError(string.Empty, Ex.ToString());
                        return View(Model);
                        throw;
                    }
                }

                ModelState.AddModelError(string.Empty, Respuesta.Errors.FirstOrDefault().Description);
            }

            return View(Model);
        }

        // GET: Propietarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _Context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Propietario Propietario)
        {
            if (id != Propietario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _Context.Update(Propietario);
                    await _Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(Propietario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Propietario);
        }

        // GET: Propietarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _Context.Propietarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propietario = await _Context.Propietarios.FindAsync(id);
            _Context.Propietarios.Remove(propietario);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropietarioExists(int id)
        {
            return _Context.Propietarios.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddMascota(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Propietario Propietario = await _Context.Propietarios.FindAsync(id.Value);

            if (Propietario == null)
            {
                return NotFound();
            }

            MascotaViewModel Model = new MascotaViewModel
            { 
                Nacimiento = DateTime.Today,
                PropietarioId = Propietario.Id,
                TipoMascota = _ComboHelper.GetComboTipoMascota()
            };

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMascota(MascotaViewModel Model)
        {
            if (ModelState.IsValid)
            {
                string Ruta = string.Empty;

                if (Model.ArchivoImagen != null)
                {
                    Ruta = await _ImagenHelper.UploadImageAsync(Model.ArchivoImagen);
                }

                Mascota Mascota = await _ConverterHelper.ToMascotaAsync(Model, Ruta, true);

                _Context.Mascotas.Add(Mascota);
                await _Context.SaveChangesAsync();

                return new RedirectResult(HttpUtility.UrlDecode((Url.Action($"Details/{Model.PropietarioId}", "Propietarios"))));
            }

            return View(Model);
        }

        public async Task<IActionResult> EditMascota(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mascota Mascota = await _Context.Mascotas.Include(p => p.Propietario).Include(p => p.TipoMascota).FirstOrDefaultAsync(p => p.Id == id);

            if (Mascota == null)
            {
                return NotFound();
            }

            return View(_ConverterHelper.ToMascotaViewModel(Mascota));
        }

        [HttpPost]
        public async Task<IActionResult> EditMascota(MascotaViewModel Model)
        {
            if (ModelState.IsValid)
            {
                string Ruta = string.Empty;

                if (Model.ArchivoImagen != null)
                {
                    Ruta = await _ImagenHelper.UploadImageAsync(Model.ArchivoImagen);
                }

                Mascota Mascota = await _ConverterHelper.ToMascotaAsync(Model, Ruta, false);

                _Context.Mascotas.Update(Mascota);
                await _Context.SaveChangesAsync();

                return new RedirectResult(HttpUtility.UrlDecode((Url.Action($"Details/{Model.PropietarioId}", "Propietarios"))));
            }

            return View(Model);
        }
    }
}
