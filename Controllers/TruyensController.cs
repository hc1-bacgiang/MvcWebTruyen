using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcWebTruyen.Data;
using MvcWebTruyen.Models;

namespace MvcWebTruyen.Controllers
{
    public class TruyensController : Controller
    {
        private readonly MvcWebTruyenContext _context;

        public TruyensController(MvcWebTruyenContext context)
        {
            _context = context;
        }

        // GET: Truyens
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Truyen == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var truyens = from m in _context.Truyen
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                truyens = truyens.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(model: await truyens.ToListAsync());
        }

        // GET: Truyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truyen = await _context.Truyen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truyen == null)
            {
                return NotFound();
            }

            return View(truyen);
        }

        // GET: Truyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Truyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Truyen truyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truyen);
        }

        // GET: Truyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truyen = await _context.Truyen.FindAsync(id);
            if (truyen == null)
            {
                return NotFound();
            }
            return View(truyen);
        }

        // POST: Truyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Truyen truyen)
        {
            if (id != truyen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruyenExists(truyen.Id))
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
            return View(truyen);
        }

        // GET: Truyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truyen = await _context.Truyen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truyen == null)
            {
                return NotFound();
            }

            return View(truyen);
        }

        // POST: Truyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truyen = await _context.Truyen.FindAsync(id);
            if (truyen != null)
            {
                _context.Truyen.Remove(truyen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruyenExists(int id)
        {
            return _context.Truyen.Any(e => e.Id == id);
        }
    }
}
