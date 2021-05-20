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
    [Authorize]
    public class DashBoradViewModelsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public DashBoradViewModelsController(BlessingsdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
       /* // GET: DashBoradViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.DashBoradViewModel.ToListAsync());
        }*/

        // GET: DashBoradViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashBoradViewModel = await _context.DashBoradViewModel
                .FirstOrDefaultAsync(m => m.dashboardvmId == id);
            if (dashBoradViewModel == null)
            {
                return NotFound();
            }

            return View(dashBoradViewModel);
        }

        // GET: DashBoradViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DashBoradViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dashboardvmId,Childrens,Staffs,TotalAmount,DueAmount")] DashBoradViewModel dashBoradViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dashBoradViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dashBoradViewModel);
        }

        // GET: DashBoradViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashBoradViewModel = await _context.DashBoradViewModel.FindAsync(id);
            if (dashBoradViewModel == null)
            {
                return NotFound();
            }
            return View(dashBoradViewModel);
        }

        // POST: DashBoradViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dashboardvmId,Childrens,Staffs,TotalAmount,DueAmount")] DashBoradViewModel dashBoradViewModel)
        {
            if (id != dashBoradViewModel.dashboardvmId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dashBoradViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashBoradViewModelExists(dashBoradViewModel.dashboardvmId))
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
            return View(dashBoradViewModel);
        }

        // GET: DashBoradViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashBoradViewModel = await _context.DashBoradViewModel
                .FirstOrDefaultAsync(m => m.dashboardvmId == id);
            if (dashBoradViewModel == null)
            {
                return NotFound();
            }

            return View(dashBoradViewModel);
        }

        // POST: DashBoradViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dashBoradViewModel = await _context.DashBoradViewModel.FindAsync(id);
            _context.DashBoradViewModel.Remove(dashBoradViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashBoradViewModelExists(int id)
        {
            return _context.DashBoradViewModel.Any(e => e.dashboardvmId == id);
        }
    }
}
