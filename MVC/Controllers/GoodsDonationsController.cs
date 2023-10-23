using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class GoodsDonationsController : Controller
    {
        private readonly ApplicationContext _context;

        public GoodsDonationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: GoodsDonations
        public async Task<IActionResult> Index()
        {
              return _context.goodDonation != null ? 
                          View(await _context.goodDonation.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.goodDonation'  is null.");
        }

        // GET: GoodsDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.goodDonation == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.goodDonation
                .FirstOrDefaultAsync(m => m.goodsId == id);
            if (goodsDonation == null)
            {
                return NotFound();
            }

            return View(goodsDonation);
        }

        // GET: GoodsDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("goodsId,donatorName,donationDate,goodsCategory,numberOfItems,goodsDescription")] GoodsDonation goodsDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsDonation);
        }
        
        


        // GET: GoodsDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.goodDonation == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.goodDonation.FindAsync(id);
            if (goodsDonation == null)
            {
                return NotFound();
            }
            return View(goodsDonation);
        }

        // POST: GoodsDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("goodsId,donatorName,donationDate,goodsCategory,numberOfItems,goodsDescription")] GoodsDonation goodsDonation)
        {
            if (id != goodsDonation.goodsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsDonationExists(goodsDonation.goodsId))
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
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.goodDonation == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.goodDonation
                .FirstOrDefaultAsync(m => m.goodsId == id);
            if (goodsDonation == null)
            {
                return NotFound();
            }

            return View(goodsDonation);
        }

        // POST: GoodsDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.goodDonation == null)
            {
                return Problem("Entity set 'ApplicationContext.goodDonation'  is null.");
            }
            var goodsDonation = await _context.goodDonation.FindAsync(id);
            if (goodsDonation != null)
            {
                _context.goodDonation.Remove(goodsDonation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsDonationExists(int id)
        {
          return (_context.goodDonation?.Any(e => e.goodsId == id)).GetValueOrDefault();
        }
    }
}
