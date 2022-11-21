﻿using System;
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
    public class EngineTypesController : Controller
    {
        private readonly EndProjectContext _context;

        public EngineTypesController(EndProjectContext context)
        {
            _context = context;
        }

        // GET: EngineTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.EngineTypes.ToListAsync());
        }

        // GET: EngineTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EngineTypes == null)
            {
                return NotFound();
            }

            var engineType = await _context.EngineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineType == null)
            {
                return NotFound();
            }

            return View(engineType);
        }

        // GET: EngineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EngineTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] EngineType engineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineType);
        }

        // GET: EngineTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EngineTypes == null)
            {
                return NotFound();
            }

            var engineType = await _context.EngineTypes.FindAsync(id);
            if (engineType == null)
            {
                return NotFound();
            }
            return View(engineType);
        }

        // POST: EngineTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] EngineType engineType)
        {
            if (id != engineType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineTypeExists(engineType.Id))
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
            return View(engineType);
        }

        // GET: EngineTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EngineTypes == null)
            {
                return NotFound();
            }

            var engineType = await _context.EngineTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineType == null)
            {
                return NotFound();
            }

            return View(engineType);
        }

        // POST: EngineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EngineTypes == null)
            {
                return Problem("Entity set 'EndProjectContext.EngineTypes'  is null.");
            }
            var engineType = await _context.EngineTypes.FindAsync(id);
            if (engineType != null)
            {
                _context.EngineTypes.Remove(engineType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineTypeExists(int id)
        {
          return _context.EngineTypes.Any(e => e.Id == id);
        }
    }
}
