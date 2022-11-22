using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EndProject.Data;
using EndProject.Models;

namespace EndProject.Controllers
{
    public class DealersController : Controller
    {
        private readonly EndProjectContext _context;

        public DealersController(EndProjectContext context)
        {
            _context = context;
        }

        // GET: Dealers
        public async Task<IActionResult> Index()
        {
            var endProjectContext = _context.Dealers.Include(d => d.Vehicle);
            return View(await endProjectContext.ToListAsync());
        }

        // GET: Dealers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dealers == null)
            {
                return NotFound();
            }

            var dealers = await _context.Dealers
                .Include(d => d.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealers == null)
            {
                return NotFound();
            }

            return View(dealers);
        }

        // GET: Dealers/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Manufacturer");
            return View();
        }

        // POST: Dealers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,password,VehicleId")] Dealers dealers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dealers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Manufacturer", dealers.VehicleId);
            return View(dealers);
        }

        // GET: Dealers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dealers == null)
            {
                return NotFound();
            }

            var dealers = await _context.Dealers.FindAsync(id);
            if (dealers == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Manufacturer", dealers.VehicleId);
            return View(dealers);
        }

        // POST: Dealers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,password,VehicleId")] Dealers dealers)
        {
            if (id != dealers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dealers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DealersExists(dealers.Id))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Manufacturer", dealers.VehicleId);
            return View(dealers);
        }

        // GET: Dealers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dealers == null)
            {
                return NotFound();
            }

            var dealers = await _context.Dealers
                .Include(d => d.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dealers == null)
            {
                return NotFound();
            }

            return View(dealers);
        }

        // POST: Dealers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dealers == null)
            {
                return Problem("Entity set 'EndProjectContext.Dealers'  is null.");
            }
            var dealers = await _context.Dealers.FindAsync(id);
            if (dealers != null)
            {
                _context.Dealers.Remove(dealers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DealersExists(int id)
        {
          return _context.Dealers.Any(e => e.Id == id);
        }
    }
}
