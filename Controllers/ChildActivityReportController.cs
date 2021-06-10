using Blessings.Models;
using Blessings.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blessings.Controllers
{
    public class ChildActivityReportController : Controller
    {

        private readonly BlessingsdbContext _context;

        public ChildActivityReportController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: ChildActivityReportController
        public async Task<IActionResult> Index(DateTime from, DateTime to)
        {
            
                  

            var dbContext = from c in _context.Child
                            join ca in _context.ChildActivity on c.ChildId equals ca.ChildId
                            select new ChildActivitiesVM
                            {
                                ActivityName = ca.ActivityName,
                                Activitytime = ca.Activitytime,
                                ActivityImage = ca.ActivityImage,
                                ChildFirstName = c.ChildFirstName
                                
                            };

            if (from != null && to != null)
            {
                dbContext = dbContext.Where(ca => ca.Activitytime >= from && ca.Activitytime <= to);
            }

            return View(await dbContext.ToListAsync());
        }

        // GET: ChildActivityReportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChildActivityReportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChildActivityReportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChildActivityReportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChildActivityReportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChildActivityReportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChildActivityReportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
