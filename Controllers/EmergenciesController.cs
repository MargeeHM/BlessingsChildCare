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
    public class EmergenciesController : Controller
    {
        private readonly BlessingsdbContext _context;

        public EmergenciesController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: Emergencies
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.Emergency.Include(e => e.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: Emergencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergency = await _context.Emergency
                .Include(e => e.Child)
                .FirstOrDefaultAsync(m => m.EmergencyId == id);
            if (emergency == null)
            {
                return NotFound();
            }

            return View(emergency);
        }

        // GET: Emergencies/Create
        public IActionResult Create(int ChildId)
        {
           
            var children = from c in _context.Child where c.ChildId == ChildId select c;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildLastName");
            return View();
        }

        // POST: Emergencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmergencyId,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,Relationship,ChildId")] Emergency emergency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergency);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Children", new { id = emergency.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", emergency.ChildId);
            return View(emergency);
        }

        // GET: Emergencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergency = await _context.Emergency.FindAsync(id);
            if (emergency == null)
            {
                return NotFound();
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", emergency.ChildId);
            return View(emergency);
        }

        // POST: Emergencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmergencyId,EmergencyContactFirstName,EmergencyContactLastName,EmergencyContactPhone,Relationship,ChildId")] Emergency emergency)
        {
            if (id != emergency.EmergencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyExists(emergency.EmergencyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Children", new { id = emergency.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", emergency.ChildId);
            return View(emergency);
        }

        // GET: Emergencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergency = await _context.Emergency
                .Include(e => e.Child)
                .FirstOrDefaultAsync(m => m.EmergencyId == id);
            if (emergency == null)
            {
                return NotFound();
            }

            return View(emergency);
        }

        // POST: Emergencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergency = await _context.Emergency.FindAsync(id);
            _context.Emergency.Remove(emergency);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Children", new { id = emergency.ChildId });
        }

        private bool EmergencyExists(int id)
        {
            return _context.Emergency.Any(e => e.EmergencyId == id);
        }
    }
}
