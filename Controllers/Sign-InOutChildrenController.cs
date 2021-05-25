using Blessings.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blessings.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Blessings.Controllers
{
    public class Sign_InOutChildrenController : Controller

    {

        private readonly BlessingsdbContext _context;

        public Sign_InOutChildrenController(BlessingsdbContext context)
        {
            _context = context;
        }
        // GET: Sign_InOutChildrenController
        public async Task<IActionResult> Index(DateTime from, DateTime to)
        {
            var dbContext = from c in _context.Child
                            join cl in _context.ChildLog on c.ChildId equals cl.ChildId
                            select new Sign_InOutChildrenVM
                            {
                                Day = cl.Day,
                                CheckIn = cl.CheckIn,
                                CheckOut = cl.CheckOut,
                                ChildFirstName = c.ChildFirstName,

                            };

            if (from != null && to !=null)
            {
                dbContext = dbContext.Where(cl => cl.Day >= from && cl.Day <= to);
            }

            return View(await dbContext.ToListAsync());
        }

       
    }
}
