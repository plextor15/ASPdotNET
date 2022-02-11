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
    public class ProductController : Controller
    {
        private readonly Komputerowy_SHOPContext _context;

        public ProductController(Komputerowy_SHOPContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(string sortow, string searchString, string typ)
        {
            var products = from p in _context.Product select p; //placeholder

            switch (sortow) {
                case "nazwa":
                    products = from p in _context.Product orderby p.Name select p;
                    break;
                case "cena":
                    products = from p in _context.Product orderby p.Price select p;
                    break;
                default:
                    products = from p in _context.Product select p;
                    break;
            }
            

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(typ))
            {
                int typint = int.Parse(typ);
                products = products.Where(p => p.Type.Equals(typint) );
            }

            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Koszyk()
        {
            var products = GlobalVar.GlobalListaZakupow;


            return View(products);
        }


        // GET: Product/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }*/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            /*switch (product.Type) {
                case 1:
                    product = await _context.Cpu.FirstOrDefaultAsync(c => c.Id_Product == id);
                    break;
                case 2:
                    var ram = await _context.Cpu.FirstOrDefaultAsync(r => r.Id_Product == id);
                    break;
                case 3:
                    var gpu = await _context.Cpu.FirstOrDefaultAsync(g => g.Id_Product == id);
                    break;
                case 4:
                    var hdd = await _context.Cpu.FirstOrDefaultAsync(h => h.Id_Product == id);
                    break;
                case 0:
                    break;
            }*/

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Amount,Type")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Amount,Type")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Kup/5
        public async Task<IActionResult> Kup(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            //product.kupiony();
            //_context.Product.Update(product);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // POST: Product/Kup/5
        [HttpPost, ActionName("Kup")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KupConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            //_context.Product.Update(product);

            Product zakupiony = new Product();
            zakupiony.Id = product.Id;
            zakupiony.Name = product.Name;
            zakupiony.Price = product.Price;
            zakupiony.Type = GlobalVar.GlobalListaZakupow.Count; //Typ robi tutaj za numer na liscie
            zakupiony.Amount = -1;
            GlobalVar.GlobalListaZakupow.Add(zakupiony);
            GlobalVar.SumaDoZaplaty += product.Price;
            
            product.kupiony();
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Product/Zwrot/5
        public async Task<IActionResult> Zwrot(int? id, string ktory)
        {
            if (id == null)
            {
                return NotFound();
            }

            GlobalVar.NrDozwrotu = int.Parse(ktory);
            var product = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // POST: Product/Zwrot/5
        [HttpPost, ActionName("Zwrot")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ZwrotConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            //_context.Product.Update(product);

            Product zakupiony = new Product();
            zakupiony.Id = product.Id;
            zakupiony.Name = product.Name;
            zakupiony.Price = product.Price;
            zakupiony.Type = -1;
            zakupiony.Amount = -1;

            //Typ robi tutaj za numer na liscie


            GlobalVar.GlobalListaZakupow.RemoveAt(GlobalVar.NrDozwrotu);
            GlobalVar.SumaDoZaplaty -= product.Price;

            product.zwrot();
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Koszyk)); //zeby wrocil do Koszyka
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
