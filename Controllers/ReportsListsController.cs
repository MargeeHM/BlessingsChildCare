using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blessings.Models;

namespace Blessings.Controllers
{
    public class ReportsListsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public ReportsListsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: ReportsLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportsList.ToListAsync());
        }

        // GET: ReportsLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsList = await _context.ReportsList
                .FirstOrDefaultAsync(m => m.ReportListId == id);
            if (reportsList == null)
            {
                return NotFound();
            }

            return View(reportsList);
        }

        // GET: ReportsLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportsLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportListId")] ReportsList reportsList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportsList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportsList);
        }

        // GET: ReportsLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsList = await _context.ReportsList.FindAsync(id);
            if (reportsList == null)
            {
                return NotFound();
            }
            return View(reportsList);
        }

        // POST: ReportsLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportListId")] ReportsList reportsList)
        {
            if (id != reportsList.ReportListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportsList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsListExists(reportsList.ReportListId))
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
            return View(reportsList);
        }

        // GET: ReportsLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsList = await _context.ReportsList
                .FirstOrDefaultAsync(m => m.ReportListId == id);
            if (reportsList == null)
            {
                return NotFound();
            }

            return View(reportsList);
        }

        // POST: ReportsLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportsList = await _context.ReportsList.FindAsync(id);
            _context.ReportsList.Remove(reportsList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsListExists(int id)
        {
            return _context.ReportsList.Any(e => e.ReportListId == id);
        }
    }
}
