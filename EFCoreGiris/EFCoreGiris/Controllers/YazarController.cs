using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFCoreGiris.Models;

namespace EFCoreGiris.Controllers
{
    public class YazarController : Controller
    {
        private readonly EFCoreGirisContext _context;

        public YazarController(EFCoreGirisContext context)
        {
            _context = context;
        }

        // GET: Yazar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yazarlar.ToListAsync());
        }

        // GET: Yazar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // GET: Yazar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yazar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ad")] Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yazar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yazar);
        }

        // GET: Yazar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null)
            {
                return NotFound();
            }
            return View(yazar);
        }

        // POST: Yazar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ad")] Yazar yazar)
        {
            if (id != yazar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yazar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YazarExists(yazar.ID))
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
            return View(yazar);
        }

        // GET: Yazar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yazar = await _context.Yazarlar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yazar == null)
            {
                return NotFound();
            }

            return View(yazar);
        }

        // POST: Yazar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);
            _context.Yazarlar.Remove(yazar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YazarExists(int id)
        {
            return _context.Yazarlar.Any(e => e.ID == id);
        }
    }
}
