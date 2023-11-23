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
    public class Cad_ClientesController : Controller
    {
        private readonly DBContext _context;

        public Cad_ClientesController(DBContext context)
        {
            _context = context;
        }

        // GET: Cad_Clientes
        public async Task<IActionResult> Index()
        {
              return _context.Cad_Clientes != null ? 
                          View(await _context.Cad_Clientes.ToListAsync()) :
                          Problem("Entity set 'DBContext.Cad_Clientes'  is null.");
        }

        // GET: Cad_Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cad_Clientes == null)
            {
                return NotFound();
            }

            var cad_Clientes = await _context.Cad_Clientes
                .FirstOrDefaultAsync(m => m.ID_Cli == id);
            if (cad_Clientes == null)
            {
                return NotFound();
            }

            return View(cad_Clientes);
        }

        // GET: Cad_Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cad_Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Cli,Nome_Cli,Telelfone_Cli,Email_Cli")] Cad_Clientes cad_Clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cad_Clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cad_Clientes);
        }

        // GET: Cad_Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cad_Clientes == null)
            {
                return NotFound();
            }

            var cad_Clientes = await _context.Cad_Clientes.FindAsync(id);
            if (cad_Clientes == null)
            {
                return NotFound();
            }
            return View(cad_Clientes);
        }

        // POST: Cad_Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Cli,Nome_Cli,Telelfone_Cli,Email_Cli")] Cad_Clientes cad_Clientes)
        {
            if (id != cad_Clientes.ID_Cli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cad_Clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cad_ClientesExists(cad_Clientes.ID_Cli))
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
            return View(cad_Clientes);
        }

        // GET: Cad_Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cad_Clientes == null)
            {
                return NotFound();
            }

            var cad_Clientes = await _context.Cad_Clientes
                .FirstOrDefaultAsync(m => m.ID_Cli == id);
            if (cad_Clientes == null)
            {
                return NotFound();
            }

            return View(cad_Clientes);
        }

        // POST: Cad_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cad_Clientes == null)
            {
                return Problem("Entity set 'DBContext.Cad_Clientes'  is null.");
            }
            var cad_Clientes = await _context.Cad_Clientes.FindAsync(id);
            if (cad_Clientes != null)
            {
                _context.Cad_Clientes.Remove(cad_Clientes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cad_ClientesExists(int id)
        {
          return (_context.Cad_Clientes?.Any(e => e.ID_Cli == id)).GetValueOrDefault();
        }
    }
}
