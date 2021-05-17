using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blessings.Models;
using Blessings.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Blessings.Controllers
{
    [Authorize]
    public class EnrollmentViewModelsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public EnrollmentViewModelsController(BlessingsdbContext context)
        {
            _context = context;
        }

       /* // GET: EnrollmentViewModels
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.EnrollmentViewModel.Include(e => e.EnrollmentId);
            return View(await blessingsdbContext.ToListAsync());
        }
*/
        // GET: EnrollmentViewModels by searchString
        public async Task<IActionResult> Index(string searchString)
        {
            var result = from c in _context.Child
                         join e in _context.Enrollment on c.ChildId equals e.ChildId
                         select new EnrollmentViewModel
                         {
                             EnrollmentId = e.EnrollmentId,
                             ChildFirstName = c.ChildFirstName,
                             ChildBirthdate = c.ChildBirthdate,
                             Course = e.Course,
                             RoomNo = e.RoomNo,
                             EnrollmentDate = e.EnrollmentDate,
                             ChildId = c.ChildId
                         };

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.ChildFirstName.Contains(searchString)
                 || s.ChildBirthdate.ToString().Contains(searchString)
                 || s.Course.Contains(searchString)
                 || s.RoomNo.Contains(searchString)
                 || s.EnrollmentDate.ToString().Contains(searchString));
            }
            return View(await result.ToListAsync());
            /*return View(await _context.EnrollmentViewModel.ToListAsync());*/
        }

        // GET: EnrollmentViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .FirstOrDefaultAsync(m => m.EnrollmentId == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }
/*
        // GET: EnrollmentViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnrollmentViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentListId,EnrollmentId,ChildFirstName,ChildBirthdate,Course,RoomNo,EnrollmentDate,ChildId")] EnrollmentViewModel enrollmentViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollmentViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enrollmentViewModel);
        }
*/
        // GET: EnrollmentViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentViewModel = await _context.EnrollmentViewModel.FindAsync(id);
            if (enrollmentViewModel == null)
            {
                return NotFound();
            }
            return View(enrollmentViewModel);
        }

        // POST: EnrollmentViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentListId,EnrollmentId,ChildFirstName,ChildBirthdate,Course,RoomNo,EnrollmentDate,ChildId")] EnrollmentViewModel enrollmentViewModel)
        {
            if (id != enrollmentViewModel.EnrollmentListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollmentViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentViewModelExists(enrollmentViewModel.EnrollmentListId))
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
            return View(enrollmentViewModel);
        }

        // GET: EnrollmentViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollmentViewModel = await _context.EnrollmentViewModel
                .FirstOrDefaultAsync(m => m.EnrollmentListId == id);
            if (enrollmentViewModel == null)
            {
                return NotFound();
            }

            return View(enrollmentViewModel);
        }

        // POST: EnrollmentViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollmentViewModel = await _context.EnrollmentViewModel.FindAsync(id);
            _context.EnrollmentViewModel.Remove(enrollmentViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentViewModelExists(int id)
        {
            return _context.EnrollmentViewModel.Any(e => e.EnrollmentListId == id);
        }
    }
}
