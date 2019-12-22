using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ogrenciyimProje.Data;
using ogrenciyimProje.Models;

namespace ogrenciyimProje.Controllers
{
    public class SorularsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SorularsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sorulars
        [Authorize()]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sorular.ToListAsync());
        }

        // GET: Sorulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sorular = await _context.Sorular
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sorular == null)
            {
                return NotFound();
            }

            return View(sorular);
        }

        // GET: Sorulars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sorulars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Baslik,Soru,Foto")] Sorular sorular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sorular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sorular);
        }

        // GET: Sorulars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sorular = await _context.Sorular.FindAsync(id);
            if (sorular == null)
            {
                return NotFound();
            }
            return View(sorular);
        }

        // POST: Sorulars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Baslik,Soru,Foto")] Sorular sorular)
        {
            if (id != sorular.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sorular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SorularExists(sorular.ID))
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
            return View(sorular);
        }

        // GET: Sorulars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sorular = await _context.Sorular
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sorular == null)
            {
                return NotFound();
            }

            return View(sorular);
        }

        // POST: Sorulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sorular = await _context.Sorular.FindAsync(id);
            _context.Sorular.Remove(sorular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SorularExists(int id)
        {
            return _context.Sorular.Any(e => e.ID == id);
        }
    }
}
