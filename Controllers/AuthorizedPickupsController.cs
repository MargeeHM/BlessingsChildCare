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
    public class AuthorizedPickupsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public AuthorizedPickupsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: AuthorizedPickups
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.AuthorizedPickup.Include(a => a.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: AuthorizedPickups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorizedPickup = await _context.AuthorizedPickup
                .Include(a => a.Child)
                .FirstOrDefaultAsync(m => m.AuthorizedPickupId == id);
            if (authorizedPickup == null)
            {
                return NotFound();
            }

            return View(authorizedPickup);
        }

        // GET: AuthorizedPickups/Create
        public IActionResult Create(int ChildId)
        {
            var children = from c in _context.Child where c.ChildId == ChildId select c;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildFirstName");
            return View();
        }

        // POST: AuthorizedPickups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorizedPickupId,PersonName,Relation,phone,ChildId")] AuthorizedPickup authorizedPickup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authorizedPickup);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Children", new { id = authorizedPickup.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", authorizedPickup.ChildId);
            return View(authorizedPickup);
        }

        // GET: AuthorizedPickups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorizedPickup = await _context.AuthorizedPickup.FindAsync(id);
            if (authorizedPickup == null)
            {
                return NotFound();
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", authorizedPickup.ChildId);
            return View(authorizedPickup);
        }

        // POST: AuthorizedPickups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuthorizedPickupId,PersonName,Relation,phone,ChildId")] AuthorizedPickup authorizedPickup)
        {
            if (id != authorizedPickup.AuthorizedPickupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authorizedPickup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorizedPickupExists(authorizedPickup.AuthorizedPickupId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Children", new { id = authorizedPickup.ChildId });
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", authorizedPickup.ChildId);
            return View(authorizedPickup);
        }

        // GET: AuthorizedPickups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorizedPickup = await _context.AuthorizedPickup
                .Include(a => a.Child)
                .FirstOrDefaultAsync(m => m.AuthorizedPickupId == id);
            if (authorizedPickup == null)
            {
                return NotFound();
            }

            return View(authorizedPickup);
        }

        // POST: AuthorizedPickups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authorizedPickup = await _context.AuthorizedPickup.FindAsync(id);
            _context.AuthorizedPickup.Remove(authorizedPickup);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Children", new { id = authorizedPickup.ChildId });
        }

        private bool AuthorizedPickupExists(int id)
        {
            return _context.AuthorizedPickup.Any(e => e.AuthorizedPickupId == id);
        }
    }
}
