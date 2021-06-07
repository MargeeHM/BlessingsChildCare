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
    public class StaffIn_OutVMController : Controller
    {
        private readonly BlessingsdbContext _context;

        public StaffIn_OutVMController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: StaffIn_OutVM
        public async Task<IActionResult> StaffAttendance(DateTime from, DateTime to)
        {
            var dbContext = from s in _context.Staff
                            join sl in _context.StaffLog on s.StaffId equals sl.StaffId
                            select new StaffInOutVM
                            {
                                Day = sl.Day,
                                StaffCheckIn = sl.StaffCheckIn,
                                StaffCheckOut = sl.StaffCheckOut,
                                StaffFirstName = s.StaffFirstName,
                            };

            if (from != null && to != null)
            {
                dbContext = dbContext.Where(sl => sl.Day >= from && sl.Day <= to && sl.StaffCheckIn != null && sl.StaffCheckOut != null);
            }

            return View(await dbContext.ToListAsync());
        }

        public async Task<IActionResult> StaffAbsentlist(DateTime from, DateTime to)
        {
            var dbContext = from s in _context.Staff
                            join sl in _context.StaffLog on s.StaffId equals sl.StaffId
                            select new StaffInOutVM
                            {
                                Day = sl.Day,
                                StaffCheckIn = sl.StaffCheckIn,
                                StaffCheckOut = sl.StaffCheckOut,
                                StaffFirstName = s.StaffFirstName,
                            };

            if (from != null && to != null)
            {
                dbContext = dbContext.Where(sl => sl.Day >= from && sl.Day <= to && sl.StaffCheckIn == null && sl.StaffCheckOut == null);
            }

            return View(await dbContext.ToListAsync());
        }

    }
}
