using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blessings.Models;
using Microsoft.AspNetCore.Authorization;

namespace Blessings.Controllers
{
    /* [Authorize(Roles = "Administrator")]*/
    [Authorize]
    public class ChildLogsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public ChildLogsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: ChildLogs
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.ChildLog.Include(c => c.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: ChildLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childLog = await _context.ChildLog
                .Include(c => c.Child)
                .FirstOrDefaultAsync(m => m.ChildlogId == id);
            if (childLog == null)
            {
                return NotFound();
            }

            return View(childLog);
        }

        // GET: ChildLogs/Create
        public IActionResult Create()
        {
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName");
            return View();
        }

        // POST: ChildLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChildlogId,Day,CheckIn,CheckOut,ChildId")] ChildLog childLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(childLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", childLog.ChildId);
            return View(childLog);
        }

        // GET: ChildLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childLog = await _context.ChildLog.FindAsync(id);
            if (childLog == null)
            {
                return NotFound();
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", childLog.ChildId);
            return View(childLog);
        }

        // POST: ChildLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChildlogId,Day,CheckIn,CheckOut,ChildId")] ChildLog childLog)
        {
            if (id != childLog.ChildlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(childLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildLogExists(childLog.ChildlogId))
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
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", childLog.ChildId);
            return View(childLog);
        }

        // GET: ChildLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childLog = await _context.ChildLog
                .Include(c => c.Child)
                .FirstOrDefaultAsync(m => m.ChildlogId == id);
            if (childLog == null)
            {
                return NotFound();
            }

            return View(childLog);
        }

        // POST: ChildLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var childLog = await _context.ChildLog.FindAsync(id);
            _context.ChildLog.Remove(childLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChildLogExists(int id)
        {
            return _context.ChildLog.Any(e => e.ChildlogId == id);
        }
    }
}
