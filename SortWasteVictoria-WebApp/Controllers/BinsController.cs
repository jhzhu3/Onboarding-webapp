using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SortWasteVictoria_WebApp.Data;
using SortWasteVictoria_WebApp.Models;

namespace SortWasteVictoria_WebApp.Controllers
{
    public class BinsController : Controller
    {
        private readonly SortWasteVictoria_WebAppContext _context;

        public BinsController(SortWasteVictoria_WebAppContext context)
        {
            _context = context;
        }

        // GET: Bins
        public async Task<IActionResult> Index()
        {
              return _context.Bin != null ? 
                          View(await _context.Bin.ToListAsync()) :
                          Problem("Entity set 'SortWasteVictoria_WebAppContext.Bin'  is null.");
        }

        // GET: Bins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bin == null)
            {
                return NotFound();
            }

            var bin = await _context.Bin
                .FirstOrDefaultAsync(m => m.BinId == id);
            if (bin == null)
            {
                return NotFound();
            }

            return View(bin);
        }

        // GET: Bins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BinId,BinColour,BinInfo")] Bin bin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bin);
        }

        // GET: Bins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bin == null)
            {
                return NotFound();
            }

            var bin = await _context.Bin.FindAsync(id);
            if (bin == null)
            {
                return NotFound();
            }
            return View(bin);
        }

        // POST: Bins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BinId,BinColour,BinInfo")] Bin bin)
        {
            if (id != bin.BinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinExists(bin.BinId))
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
            return View(bin);
        }

        // GET: Bins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bin == null)
            {
                return NotFound();
            }

            var bin = await _context.Bin
                .FirstOrDefaultAsync(m => m.BinId == id);
            if (bin == null)
            {
                return NotFound();
            }

            return View(bin);
        }

        // POST: Bins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bin == null)
            {
                return Problem("Entity set 'SortWasteVictoria_WebAppContext.Bin'  is null.");
            }
            var bin = await _context.Bin.FindAsync(id);
            if (bin != null)
            {
                _context.Bin.Remove(bin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinExists(int id)
        {
          return (_context.Bin?.Any(e => e.BinId == id)).GetValueOrDefault();
        }
    }
}
