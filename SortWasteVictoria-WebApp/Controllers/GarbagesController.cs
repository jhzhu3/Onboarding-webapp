using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SortWasteVictoria_WebApp.Data;
using SortWasteVictoria_WebApp.Models;

namespace SortWasteVictoria_WebApp.Controllers
{
    public class GarbagesController : Controller
    {
        private readonly SortWasteVictoria_WebAppContext _context;

        public GarbagesController(SortWasteVictoria_WebAppContext context)
        {
            _context = context;
        }

        // GET: Garbages
        public async Task<IActionResult> Index()
        {
            var sortWasteVictoria_WebAppContext = _context.Garbage.Include(g => g.Bin);
            return View(await sortWasteVictoria_WebAppContext.ToListAsync());
        }

        //GET: Garbages/Info
        public async Task<IActionResult> Info(string SearchString)
        {
            var sortWasteVictoria_WebAppContext = _context.Garbage.Include(g => g.Bin);

            ViewData["CurrentFilter"] = SearchString;
            var garbages = from g in _context.Garbage select g;

            List<Garbage> testList = sortWasteVictoria_WebAppContext.ToList();
            List<Garbage> found = testList.Where(gb => gb.GarbageName.Contains(SearchString)).ToList();

            return View(found);
            

/*            if (!String.IsNullOrEmpty(SearchString))
            {
                garbages = garbages.Where(g => g.GarbageName.Contains(SearchString));
            }
            
            return View(await garbages.ToListAsync());*/
        }

        // GET: Garbages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Garbage == null)
            {
                return NotFound();
            }

            var garbage = await _context.Garbage
                .Include(g => g.Bin)
                .FirstOrDefaultAsync(m => m.GarbageId == id);
            if (garbage == null)
            {
                return NotFound();
            }

            return View(garbage);
        }

        // GET: Garbages/Create
        public IActionResult Create()
        {
            ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "BinId");
            return View();
        }

        // POST: Garbages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarbageId,GarbageName,BinId")] Garbage garbage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garbage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "BinId", garbage.BinId);
            return View(garbage);
        }

        // GET: Garbages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Garbage == null)
            {
                return NotFound();
            }

            var garbage = await _context.Garbage.FindAsync(id);
            if (garbage == null)
            {
                return NotFound();
            }
            ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "BinId", garbage.BinId);
            return View(garbage);
        }

        // POST: Garbages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarbageId,GarbageName,BinId")] Garbage garbage)
        {
            if (id != garbage.GarbageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garbage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarbageExists(garbage.GarbageId))
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
            ViewData["BinId"] = new SelectList(_context.Bin, "BinId", "BinId", garbage.BinId);
            return View(garbage);
        }

        // GET: Garbages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Garbage == null)
            {
                return NotFound();
            }

            var garbage = await _context.Garbage
                .Include(g => g.Bin)
                .FirstOrDefaultAsync(m => m.GarbageId == id);
            if (garbage == null)
            {
                return NotFound();
            }

            return View(garbage);
        }

        // POST: Garbages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Garbage == null)
            {
                return Problem("Entity set 'SortWasteVictoria_WebAppContext.Garbage'  is null.");
            }
            var garbage = await _context.Garbage.FindAsync(id);
            if (garbage != null)
            {
                _context.Garbage.Remove(garbage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarbageExists(int id)
        {
          return (_context.Garbage?.Any(e => e.GarbageId == id)).GetValueOrDefault();
        }
    }
}
