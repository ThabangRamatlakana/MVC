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
    public class MonetaryDonationsController : Controller
    {
        private readonly ApplicationContext _context;

        public MonetaryDonationsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: MonetaryDonations
        public async Task<IActionResult> Index()
        {
              return _context.monetaryGoods != null ? 
                          View(await _context.monetaryGoods.ToListAsync()) :
                          Problem("Entity set 'ApplicationContext.monetaryGoods'  is null.");
        }

        // GET: MonetaryDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.monetaryGoods == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.monetaryGoods
                .FirstOrDefaultAsync(m => m.moneyId == id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }

            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonetaryDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("moneyId,donatorName,donationDate,moneyAmount")] MonetaryDonation monetaryDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monetaryDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.monetaryGoods == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.monetaryGoods.FindAsync(id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }
            return View(monetaryDonation);
        }

        // POST: MonetaryDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("moneyId,donatorName,donationDate,moneyAmount")] MonetaryDonation monetaryDonation)
        {
            if (id != monetaryDonation.moneyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monetaryDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonetaryDonationExists(monetaryDonation.moneyId))
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
            return View(monetaryDonation);
        }

        // GET: MonetaryDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.monetaryGoods == null)
            {
                return NotFound();
            }

            var monetaryDonation = await _context.monetaryGoods
                .FirstOrDefaultAsync(m => m.moneyId == id);
            if (monetaryDonation == null)
            {
                return NotFound();
            }

            return View(monetaryDonation);
        }

        // POST: MonetaryDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.monetaryGoods == null)
            {
                return Problem("Entity set 'ApplicationContext.monetaryGoods'  is null.");
            }
            var monetaryDonation = await _context.monetaryGoods.FindAsync(id);
            if (monetaryDonation != null)
            {
                _context.monetaryGoods.Remove(monetaryDonation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonetaryDonationExists(int id)
        {
          return (_context.monetaryGoods?.Any(e => e.moneyId == id)).GetValueOrDefault();
        }
    }
}
