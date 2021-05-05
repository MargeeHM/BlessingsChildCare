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
    public class EnrollmentsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public EnrollmentsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.Enrollment.Include(e => e.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Child)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create(int ChildId)
        {
            var children = from c in _context.Child where c.ChildId == ChildId select c; 
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildLastName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,Course,RoomNo,EnrollmentDate,ChildId")] Enrollment enrollment)
        {

           /* var children = from c in _context.Child where c.ChildId == enrollment.ChildId select c;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildLastName");*/

            if (enrollment.EnrollmentDate < DateTime.Today)
            {
                ViewBag.Message = "Please choose future Date";
                return View(enrollment);
            }
            if (ModelState.IsValid)
            {
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                
                return RedirectToAction("Details","Children",new { id = enrollment.ChildId});
            }
           
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", enrollment.ChildId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildLastName");
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,Course,RoomNo,EnrollmentDate,ChildId")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   
                        _context.Update(enrollment);
                        await _context.SaveChangesAsync();
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Children", new { id = enrollment.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildLastName", enrollment.ChildId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Child)
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Children", new { id =enrollment.ChildId });
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.EnrollmentId == id);
        }
    }
}
