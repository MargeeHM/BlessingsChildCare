using Blessings.Models;
using Blessings.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index(DateTime day, string room)
        {

            var dbContext = from s in _context.Staff
                            join sl in _context.StaffLog on s.StaffId equals sl.StaffId
                            select new ChildActivitiesVM
                            {
                               
                            };

          /*  if (day != null && to != null)
            {
                dbContext = dbContext.Where(sl => sl.Day >= from && sl.Day <= to && sl.StaffCheckIn != null && sl.StaffCheckOut != null);
            }*/

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
