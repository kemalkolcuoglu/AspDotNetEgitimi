using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Odevler.Data;
using Odevler.Models;

namespace Odevler.Controllers
{
    public class KisisController : Controller
    {
        private readonly OdevContext _context;

        public KisisController(OdevContext context)
        {
            _context = context;
        }

        // GET: Kisis
        public async Task<IActionResult> Index()
        {
            List<Kisi> kisiler = await _context.Kisi.Include(x => x.Adresler).ToListAsync();
            return View(kisiler);
        }

        // GET: Kisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // GET: Kisis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ad,Soyad,Yas")] Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisi);
        }

        // GET: Kisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisi.FindAsync(id);
            if (kisi == null)
            {
                return NotFound();
            }
            return View(kisi);
        }

        // POST: Kisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ad,Soyad,Yas")] Kisi kisi)
        {
            if (id != kisi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisiExists(kisi.ID))
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
            return View(kisi);
        }

        // GET: Kisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = await _context.Kisi
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // POST: Kisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kisi = await _context.Kisi.FindAsync(id);
            _context.Kisi.Remove(kisi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisiExists(int id)
        {
            return _context.Kisi.Any(e => e.ID == id);
        }
    }
}
