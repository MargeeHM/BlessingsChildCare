using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blessings.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Blessings.Controllers
{
  
    public class ChildActivitiesController : Controller
    {
        private readonly BlessingsdbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ChildActivitiesController(BlessingsdbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: ChildActivities
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.ChildActivity.Include(c => c.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: ChildActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childActivity = await _context.ChildActivity
                .Include(c => c.Child)
                .FirstOrDefaultAsync(m => m.ChildActivityId == id);
            if (childActivity == null)
            {
                return NotFound();
            }

            return View(childActivity);
        }

        // GET: ChildActivities/Create
        public IActionResult Create()
        {
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName");
            return View();
        }

        // POST: ChildActivities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChildActivityId,Activitytime,ActivityName,ActivityImage,ChildId")] ChildActivity childActivity)
        {
            if (ModelState.IsValid)
            {

                //save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(childActivity.ActivityImage.FileName);
                string extension = Path.GetExtension(childActivity.ActivityImage.FileName);
                childActivity.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
               
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await childActivity.ActivityImage.CopyToAsync(filestream);
                }

             

                // insert 
                _context.Add(childActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", childActivity.ChildId);
            return View(childActivity);
        }


        // GET: ChildActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childActivity = await _context.ChildActivity.FindAsync(id);
            if (childActivity == null)
            {
                return NotFound();
            }
            var children = from c in _context.Child where c.ChildId == childActivity.ChildId select c;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildFirstName", childActivity.ChildId);
            return View(childActivity);
        }

        // POST: ChildActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChildActivityId,Activitytime,ActivityName,ChildId")] ChildActivity childActivity)
        {
            if (id != childActivity.ChildActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(childActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChildActivityExists(childActivity.ChildActivityId))
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
            var children = from c in _context.Child where c.ChildId == childActivity.ChildId select c;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildFirstName", childActivity.ChildId);
            return View(childActivity);
        }

        // GET: ChildActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var childActivity = await _context.ChildActivity
                .Include(c => c.Child)
                .FirstOrDefaultAsync(m => m.ChildActivityId == id);
            if (childActivity == null)
            {
                return NotFound();
            }

            return View(childActivity);
        }

        // POST: ChildActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var childActivity = await _context.ChildActivity.FindAsync(id);


            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Image", childActivity.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            _context.ChildActivity.Remove(childActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChildActivityExists(int id)
        {
            return _context.ChildActivity.Any(e => e.ChildActivityId == id);
        }
    }
}
