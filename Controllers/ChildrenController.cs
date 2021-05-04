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
    public class ChildrenController : Controller
    {
        private readonly BlessingsdbContext _context;

        public ChildrenController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: Children
        public async Task<IActionResult> Index(/*string searchString*/)
        {
            /*var dbContext = from c in _context.Child
                            join e in _context.Enrollment on c.ChildId
                            equals e.ChildId into Temp
                            from lj in Temp.DefaultIfEmpty()
                            select new */

            return View(await _context.Child.ToListAsync());
        }

        // GET: Children/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Child
                .FirstOrDefaultAsync(m => m.ChildId == id);
            if (child == null)
            {
                return NotFound();
            }
            child.Enrollment = _context.Enrollment.Where(m => m.ChildId == child.ChildId).ToList();
            child.Emergency = _context.Emergency.Where(m => m.ChildId == child.ChildId).ToList();
            child.Medical = _context.Medical.Where(m => m.ChildId == child.ChildId).ToList();
            child.Payment = _context.Payment.Where(m => m.ChildId == child.ChildId).ToList();

            return View(child);
        }

        // GET: Children/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChildId,ChildFirstName,ChildLastName,ChildBirthdate,Age,FatherFirstName,FatherLastName,MotherFirstName,MotherLastName,ContactPhone,Street,City,State,Zipcode")] Child child)
        {
            if (ModelState.IsValid)
            {
                // Save today's date.
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - child.ChildBirthdate.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (child.ChildBirthdate.Date > today.AddYears(-age)) age--;
                child.Age = age;
                _context.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(child);
        }

        // GET: Children/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Child.FindAsync(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChildId,ChildFirstName,ChildLastName,ChildBirthdate,Age,FatherFirstName,FatherLastName,MotherFirstName,MotherLastName,ContactPhone,Street,City,State,Zipcode")] Child child)
        {
            if (id != child.ChildId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(child);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildExists(child.ChildId))
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
            return View(child);
        }

        // GET: Children/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var child = await _context.Child
                .FirstOrDefaultAsync(m => m.ChildId == id);
            if (child == null)
            {
                return NotFound();
            }

            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var child = await _context.Child.FindAsync(id);
            _context.Child.Remove(child);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChildExists(int id)
        {
            return _context.Child.Any(e => e.ChildId == id);
        }
    }
}
