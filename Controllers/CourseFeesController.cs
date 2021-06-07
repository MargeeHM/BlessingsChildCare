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
    /*[Authorize(Roles = "Administrator")]*/
    [Authorize]
    public class CourseFeesController : Controller
    {
        private readonly BlessingsdbContext _context;

        public CourseFeesController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: CourseFees
        public async Task<IActionResult> Index(string searchString)
        {
            var result = from cf in _context.CourseFees select cf;

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(cf => cf.Course.Contains(searchString)
                 || cf.Fee.ToString().Contains(searchString));
            }
            return View(await result.ToListAsync());
        }

        // GET: CourseFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseFees = await _context.CourseFees
                .FirstOrDefaultAsync(m => m.CourseFeeId == id);
            if (courseFees == null)
            {
                return NotFound();
            }

            return View(courseFees);
        }

        // GET: CourseFees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseFeeId,Course,Fee")] CourseFees courseFees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseFees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseFees);
        }

        // GET: CourseFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseFees = await _context.CourseFees.FindAsync(id);
            if (courseFees == null)
            {
                return NotFound();
            }
            return View(courseFees);
        }

        // POST: CourseFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseFeeId,Course,Fee")] CourseFees courseFees)
        {
            if (id != courseFees.CourseFeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseFees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseFeesExists(courseFees.CourseFeeId))
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
            return View(courseFees);
        }

        // GET: CourseFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseFees = await _context.CourseFees
                .FirstOrDefaultAsync(m => m.CourseFeeId == id);
            if (courseFees == null)
            {
                return NotFound();
            }

            return View(courseFees);
        }

        // POST: CourseFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseFees = await _context.CourseFees.FindAsync(id);
            _context.CourseFees.Remove(courseFees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseFeesExists(int id)
        {
            return _context.CourseFees.Any(e => e.CourseFeeId == id);
        }
    }
}
