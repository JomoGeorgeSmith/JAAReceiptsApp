using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JAAReceipts.Web.Data;
using JAAReceipts.Web.Models;
using System.Data.Entity;

namespace JAAReceipts.Web.Controllers
{
    public class ReceiptTypeCategoriesController : Controller
    {
        private readonly JAAReceiptsWebContext _context;

        public ReceiptTypeCategoriesController(JAAReceiptsWebContext context)
        {
            _context = context;
        }

        // GET: ReceiptTypeCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReceiptTypeCategory.ToListAsync());
        }

        // GET: ReceiptTypeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptTypeCategory = await _context.ReceiptTypeCategory
                .FirstOrDefaultAsync(m => m.ReceiptTypeCategoryID == id);
            if (receiptTypeCategory == null)
            {
                return NotFound();
            }

            return View(receiptTypeCategory);
        }

        // GET: ReceiptTypeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceiptTypeCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceiptTypeCategoryID,Description")] ReceiptTypeCategory receiptTypeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receiptTypeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(receiptTypeCategory);
        }

        // GET: ReceiptTypeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptTypeCategory = await _context.ReceiptTypeCategory.FindAsync(id);
            if (receiptTypeCategory == null)
            {
                return NotFound();
            }
            return View(receiptTypeCategory);
        }

        // POST: ReceiptTypeCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceiptTypeCategoryID,Description")] ReceiptTypeCategory receiptTypeCategory)
        {
            if (id != receiptTypeCategory.ReceiptTypeCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiptTypeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptTypeCategoryExists(receiptTypeCategory.ReceiptTypeCategoryID))
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
            return View(receiptTypeCategory);
        }

        // GET: ReceiptTypeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receiptTypeCategory = await _context.ReceiptTypeCategory
                .FirstOrDefaultAsync(m => m.ReceiptTypeCategoryID == id);
            if (receiptTypeCategory == null)
            {
                return NotFound();
            }

            return View(receiptTypeCategory);
        }

        // POST: ReceiptTypeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receiptTypeCategory = await _context.ReceiptTypeCategory.FindAsync(id);
            _context.ReceiptTypeCategory.Remove(receiptTypeCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReceiptTypeCategoryExists(int id)
        {
            return _context.ReceiptTypeCategory.Any(e => e.ReceiptTypeCategoryID == id);
        }
    }
}
