using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionHub.Data;
using FashionHub.Models;

namespace FashionHub.Controllers
{
    public class BillsController : Controller
    {
        private readonly Context _context;

        public BillsController(Context context)
        {
            _context = context;
        }

        // GET: Bills
        public async Task<IActionResult> Index()
        {
            var context = _context.bills.Include(b => b.Order).Include(b => b.Product);
            return View(await context.ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.bills
                .Include(b => b.Order)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // GET: Bills/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.orders, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id");
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,OrderId,ItemPrice,TotalPrice,NUmItems,Date")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.orders, "Id", "Id", bill.OrderId);
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", bill.ProductId);
            return View(bill);
        }

        // GET: Bills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.orders, "Id", "Id", bill.OrderId);
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", bill.ProductId);
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,OrderId,ItemPrice,TotalPrice,NUmItems,Date")] Bill bill)
        {
            if (id != bill.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.ProductId))
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
            ViewData["OrderId"] = new SelectList(_context.orders, "Id", "Id", bill.OrderId);
            ViewData["ProductId"] = new SelectList(_context.products, "Id", "Id", bill.ProductId);
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.bills
                .Include(b => b.Order)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.bills.FindAsync(id);
            if (bill != null)
            {
                _context.bills.Remove(bill);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillExists(int id)
        {
            return _context.bills.Any(e => e.ProductId == id);
        }
    }
}
