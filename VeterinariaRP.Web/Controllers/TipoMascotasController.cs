using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VeterinariaRP.Web.Data.Entities;

namespace VeterinariaRP.Web.Controllers
{
    public class TipoMascotasController : Controller
    {
        private readonly DataContext _context;

        public TipoMascotasController(DataContext context)
        {
            _context = context;
        }

        // GET: TipoMascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMascotas.ToListAsync());
        }

        // GET: TipoMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascota = await _context.TipoMascotas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMascota == null)
            {
                return NotFound();
            }

            return View(tipoMascota);
        }

        // GET: TipoMascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] TipoMascota tipoMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMascota);
        }

        // GET: TipoMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMascota = await _context.TipoMascotas.FindAsync(id);
            if (tipoMascota == null)
            {
                return NotFound();
            }
            return View(tipoMascota);
        }

        // POST: TipoMascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] TipoMascota tipoMascota)
        {
            if (id != tipoMascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMascotaExists(tipoMascota.Id))
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
            return View(tipoMascota);
        }

        // GET: TipoMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoMascota TipoMascota = await _context.TipoMascotas.Include(tm => tm.Mascotas).FirstOrDefaultAsync(tm => tm.Id == id);

            if (TipoMascota == null)
            {
                return NotFound();
            }

            if (TipoMascota.Mascotas.Count > 0)
            {
                ModelState.AddModelError(string.Empty, "No se puede eliminar el tipo de mascota si tiene registros relacionados.");

                return RedirectToAction(nameof(Index));
            }

            _context.TipoMascotas.Remove(TipoMascota);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool TipoMascotaExists(int id)
        {
            return _context.TipoMascotas.Any(e => e.Id == id);
        }
    }
}
