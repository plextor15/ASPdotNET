using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Komputerowy_SHOP.Data;
using Komputerowy_SHOP.Models;

namespace Komputerowy_SHOP.Controllers
{
    public class HddController : Controller
    {
        private readonly Komputerowy_SHOPContext _context;

        public HddController(Komputerowy_SHOPContext context)
        {
            _context = context;
        }

        // GET: Hdd
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hdd.ToListAsync());
        }

        // GET: Hdd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hdd = await _context.Hdd
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hdd == null)
            {
                return NotFound();
            }

            return View(hdd);
        }

        // GET: Hdd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hdd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Product,Gb,Rpm")] Hdd hdd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hdd);
        }

        // GET: Hdd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hdd = await _context.Hdd.FindAsync(id);
            if (hdd == null)
            {
                return NotFound();
            }
            return View(hdd);
        }

        // POST: Hdd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Product,Gb,Rpm")] Hdd hdd)
        {
            if (id != hdd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hdd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HddExists(hdd.Id))
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
            return View(hdd);
        }

        // GET: Hdd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hdd = await _context.Hdd
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hdd == null)
            {
                return NotFound();
            }

            return View(hdd);
        }

        // POST: Hdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hdd = await _context.Hdd.FindAsync(id);
            _context.Hdd.Remove(hdd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HddExists(int id)
        {
            return _context.Hdd.Any(e => e.Id == id);
        }
    }
}
