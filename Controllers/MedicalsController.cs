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
    [Authorize]
    public class MedicalsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public MedicalsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: Medicals
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.Medical.Include(m => m.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: Medicals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical = await _context.Medical
                .Include(m => m.Child)
                .FirstOrDefaultAsync(m => m.MedicalId == id);
            if (medical == null)
            {
                return NotFound();
            }

            return View(medical);
        }

        // GET: Medicals/Create
        public IActionResult Create(int ChildId)
        {
            var children = from c in _context.Child where c.ChildId == ChildId select c;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildLastName");
            return View();
        }

        // POST: Medicals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalId,PersonToContactFirstName,PersonToContactLastName,PersonToContactPhone,ChildsDoctorFirstName,ChildsDoctorLastName,ChildsDoctorPhone,RegularlyUsedHospitalName,DiaetryRestriction,MedicalIssue,ChildId")] Medical medical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medical);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Children", new { id = medical.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", medical.ChildId);
            return View(medical);
        }

        // GET: Medicals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical = await _context.Medical.FindAsync(id);
            if (medical == null)
            {
                return NotFound();
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", medical.ChildId);
            return View(medical);
        }

        // POST: Medicals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalId,PersonToContactFirstName,PersonToContactLastName,PersonToContactPhone,ChildsDoctorFirstName,ChildsDoctorLastName,ChildsDoctorPhone,RegularlyUsedHospitalName,DiaetryRestriction,MedicalIssue,ChildId")] Medical medical)
        {
            if (id != medical.MedicalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalExists(medical.MedicalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Children", new { id = medical.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", medical.ChildId);
            return View(medical);
        }

        // GET: Medicals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medical = await _context.Medical
                .Include(m => m.Child)
                .FirstOrDefaultAsync(m => m.MedicalId == id);
            if (medical == null)
            {
                return NotFound();
            }

            return View(medical);
        }

        // POST: Medicals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medical = await _context.Medical.FindAsync(id);
            _context.Medical.Remove(medical);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Children", new { id = medical.ChildId });
        }

        private bool MedicalExists(int id)
        {
            return _context.Medical.Any(e => e.MedicalId == id);
        }
    }
}
