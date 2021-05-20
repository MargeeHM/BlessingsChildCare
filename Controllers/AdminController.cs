using Blessings.Models;
using Blessings.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blessings.Controllers
{
    /*[Authorize(Roles ="Administrator")]*/
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly BlessingsdbContext _context;


        public AdminController(RoleManager<IdentityRole> roleManager, BlessingsdbContext context)
        {
            this.roleManager = roleManager;
            _context = context;
        }    
        public IActionResult Index()


        {
            var dashboard =  new DashBoradViewModel
            {
                Childrens = _context.Child.Count(),
                Staffs = _context.Staff.Count(),
                TotalAmount = _context.Payment.Sum(p => p.Amount),
                DueAmount = _context.Payment.Where(p => p.Status == "Due").Sum(p => p.Amount),
                ChildrenList = _context.Child.OrderByDescending(c => c.ChildId).ToList()
            };
            return View(dashboard);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectRole role)
        {
            var roleExist = await roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }

            return View();
        }
    }
}
