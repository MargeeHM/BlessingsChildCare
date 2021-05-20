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
    /*[Authorize(Roles = "Administrator")]*/
    [Authorize]
    public class ChildrenController : Controller
    {
        private readonly BlessingsdbContext _context;

        public ChildrenController(BlessingsdbContext context)
        {
            _context = context;
        }

     /*   public IActionResult Index() {
            return View(_context.Child.ToList());
        }*/
       /* public IActionResult Index()
        {
            var dashboard = new DashBoradViewModel
            {
                Childrens = _context.Child.Count(),
                Staffs = _context.Staff.Count(),
                TotalAmount = _context.Payment.Sum(p => p.Amount),
                DueAmount = _context.Payment.Sum(p => p.Amount),
                ChildrenList = _context.Child.OrderByDescending(c => c.ChildId).ToList()
            };
            return View(dashboard);
        }*/

        // GET: Children
        public async Task<IActionResult> Index(string searchString)
        {
            var result = from c in _context.Child select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.ChildFirstName.Contains(searchString)
                 || s.ChildLastName.Contains(searchString)
                 || s.ChildBirthdate.ToString().Contains(searchString)
                 || s.Age.ToString().Contains(searchString)
                 || s.FatherFirstName.Contains(searchString)
                 || s.FatherLastName.Contains(searchString)
                 || s.MotherFirstName.Contains(searchString)
                 || s.MotherLastName.Contains(searchString)
                 || s.ContactPhone.Contains(searchString));
            }
            return View(await result.ToListAsync());
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
                var result = from c in _context.Child select c;

                result = result.Where(s => s.ChildFirstName.Contains(child.ChildFirstName)
                 && s.ChildLastName.Contains(child.ChildLastName)
                 && s.ChildBirthdate.Equals(child.ChildBirthdate)
                 && s.FatherFirstName.Contains(child.FatherFirstName)
                 && s.FatherLastName.Contains(child.FatherLastName)
                 && s.MotherFirstName.Contains(child.MotherFirstName)
                 && s.MotherLastName.Contains(child.MotherLastName));

                if (result.Any())
                {
                    ViewBag.Message = "Child is already enrolled.";
                    return View(child);
                }
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
