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
    public class GpuController : Controller
    {
        private readonly Komputerowy_SHOPContext _context;

        public GpuController(Komputerowy_SHOPContext context)
        {
            _context = context;
        }

        // GET: Gpu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gpu.ToListAsync());
        }

        // GET: Gpu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpu.FirstOrDefaultAsync(m => m.Id_Product == id); //"id" to id produktu, nie rodzaju

            var prod = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            GlobalVar.GlobalProductName = prod.Name;

            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // GET: Gpu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gpu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Product,VramGB,Gddr,Mhz")] Gpu gpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gpu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gpu);
        }

        // GET: Gpu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpu.FindAsync(id);
            if (gpu == null)
            {
                return NotFound();
            }
            return View(gpu);
        }

        // POST: Gpu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Product,VramGB,Gddr,Mhz")] Gpu gpu)
        {
            if (id != gpu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gpu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GpuExists(gpu.Id))
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
            return View(gpu);
        }

        // GET: Gpu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // POST: Gpu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gpu = await _context.Gpu.FindAsync(id);
            _context.Gpu.Remove(gpu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GpuExists(int id)
        {
            return _context.Gpu.Any(e => e.Id == id);
        }
    }
}
