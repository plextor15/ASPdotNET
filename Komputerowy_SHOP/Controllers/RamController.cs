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
    public class RamController : Controller
    {
        private readonly Komputerowy_SHOPContext _context;

        public RamController(Komputerowy_SHOPContext context)
        {
            _context = context;
        }

        // GET: Ram
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ram.ToListAsync());
        }

        // GET: Ram/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Ram.FirstOrDefaultAsync(m => m.Id_Product == id); //"id" to id produktu, nie rodzaju

            var prod = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            GlobalVar.GlobalProductName = prod.Name;

            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        // GET: Ram/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ram/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Product,Gb,Ddr,Mhz")] Ram ram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ram);
        }

        // GET: Ram/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Ram.FindAsync(id);
            if (ram == null)
            {
                return NotFound();
            }
            return View(ram);
        }

        // POST: Ram/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Product,Gb,Ddr,Mhz")] Ram ram)
        {
            if (id != ram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RamExists(ram.Id))
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
            return View(ram);
        }

        // GET: Ram/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ram = await _context.Ram
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ram == null)
            {
                return NotFound();
            }

            return View(ram);
        }

        // POST: Ram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ram = await _context.Ram.FindAsync(id);
            _context.Ram.Remove(ram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RamExists(int id)
        {
            return _context.Ram.Any(e => e.Id == id);
        }
    }
}
