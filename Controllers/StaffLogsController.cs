using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blessings.Models;
using Microsoft.AspNetCore.Authorization;
using Blessings.ViewModel;

namespace Blessings.Controllers
{
    /*[Authorize(Roles = "Administrator")]*/
    [Authorize]
    public class StaffLogsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public StaffLogsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: StaffLogs
        public async Task<IActionResult> Index(string searchString)
        {
            /*         var result = from sl in _context.StaffLog
                                  join s in _context.Staff on sl.StaffId equals s.StaffId
                                  select new StaffLog {
                                      StaffId = sl.StaffId,
                                      Day = sl.Day,
                                      StaffCheckIn = sl.StaffCheckIn,
                                      StaffCheckOut = sl.StaffCheckOut,
                                      StafflogId = sl.StafflogId,

                                  };

                     if (!String.IsNullOrEmpty(searchString))
                     {

                         result = result.Where(sl => *//*sl.StaffFirstName.Contains(searchString)
                         ||*//* sl.Day.ToString().Contains(searchString)
                         || sl.StaffCheckIn.ToString().Contains(searchString)
                         || sl.StaffCheckOut.ToString().Contains(searchString));
                     }

                     return View(await result.ToListAsync());
         */
            var blessingsdbContext = _context.StaffLog.Include(s => s.Staff);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: StaffLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffLog = await _context.StaffLog
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StafflogId == id);
            if (staffLog == null)
            {
                return NotFound();
            }

            return View(staffLog);
        }

        // GET: StaffLogs/Create
        public IActionResult Create()
        {
           
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffFirstName");
            return View();
        }

        // POST: StaffLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StafflogId,Day,StaffCheckIn,StaffCheckOut,StaffId")] StaffLog staffLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var staff = from s in _context.Staff where s.StaffId == staffLog.StaffId select s;
            ViewData["StaffId"] = new SelectList(staff, "StaffId", "StaffFirstName", staffLog.StaffId);
         
            return View(staffLog);
        }

        // GET: StaffLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffLog = await _context.StaffLog.FindAsync(id);
            if (staffLog == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffFirstName", staffLog.StaffId);
            return View(staffLog);
        }

        // POST: StaffLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StafflogId,Day,StaffCheckIn,StaffCheckOut,StaffId")] StaffLog staffLog)
        {
            if (id != staffLog.StafflogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffLogExists(staffLog.StafflogId))
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
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "StaffFirstName", staffLog.StaffId);
            return View(staffLog);
        }

        // GET: StaffLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffLog = await _context.StaffLog
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StafflogId == id);
            if (staffLog == null)
            {
                return NotFound();
            }

            return View(staffLog);
        }

        // POST: StaffLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffLog = await _context.StaffLog.FindAsync(id);
            _context.StaffLog.Remove(staffLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffLogExists(int id)
        {
            return _context.StaffLog.Any(e => e.StafflogId == id);
        }
    }
}
