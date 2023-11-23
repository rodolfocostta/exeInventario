using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exeInventario.Data;
using exeInventario.Models;

namespace exeInventario.Controllers
{
    public class Cad_MaquinasController : Controller
    {
        private readonly DBContext _context;

        public Cad_MaquinasController(DBContext context)
        {
            _context = context;
        }

        // GET: Cad_Maquinas
        public async Task<IActionResult> Index()
        {
              return _context.Cad_Maquinas != null ? 
                          View(await _context.Cad_Maquinas.ToListAsync()) :
                          Problem("Entity set 'DBContext.Cad_Maquinas'  is null.");
        }

        // GET: Cad_Maquinas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cad_Maquinas == null)
            {
                return NotFound();
            }

            var cad_Maquinas = await _context.Cad_Maquinas
                .FirstOrDefaultAsync(m => m.ID_Maq == id);
            if (cad_Maquinas == null)
            {
                return NotFound();
            }

            return View(cad_Maquinas);
        }

        // GET: Cad_Maquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cad_Maquinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Maq,Modelo_Maq,Peças_Maq")] Cad_Maquinas cad_Maquinas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cad_Maquinas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cad_Maquinas);
        }

        // GET: Cad_Maquinas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cad_Maquinas == null)
            {
                return NotFound();
            }

            var cad_Maquinas = await _context.Cad_Maquinas.FindAsync(id);
            if (cad_Maquinas == null)
            {
                return NotFound();
            }
            return View(cad_Maquinas);
        }

        // POST: Cad_Maquinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Maq,Modelo_Maq,Peças_Maq")] Cad_Maquinas cad_Maquinas)
        {
            if (id != cad_Maquinas.ID_Maq)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cad_Maquinas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cad_MaquinasExists(cad_Maquinas.ID_Maq))
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
            return View(cad_Maquinas);
        }

        // GET: Cad_Maquinas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cad_Maquinas == null)
            {
                return NotFound();
            }

            var cad_Maquinas = await _context.Cad_Maquinas
                .FirstOrDefaultAsync(m => m.ID_Maq == id);
            if (cad_Maquinas == null)
            {
                return NotFound();
            }

            return View(cad_Maquinas);
        }

        // POST: Cad_Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cad_Maquinas == null)
            {
                return Problem("Entity set 'DBContext.Cad_Maquinas'  is null.");
            }
            var cad_Maquinas = await _context.Cad_Maquinas.FindAsync(id);
            if (cad_Maquinas != null)
            {
                _context.Cad_Maquinas.Remove(cad_Maquinas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cad_MaquinasExists(int id)
        {
          return (_context.Cad_Maquinas?.Any(e => e.ID_Maq == id)).GetValueOrDefault();
        }
    }
}
