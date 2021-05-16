using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blessings.Models;
using Blessings.ViewModel;

namespace Blessings.Controllers
{
    public class PaymentVMsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public PaymentVMsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: PaymentVMs
        public async Task<IActionResult> Index(string searchString)
        {
            var result = from c in _context.Child
                         join e in _context.Enrollment on c.ChildId equals e.ChildId
                         join p in _context.Payment on e.ChildId equals p.ChildId
                         select new PaymentVM
                         {
                             PaymentId = p.PaymentId,
                             ChildFirstName = c.ChildFirstName,
                             ChildBirthdate = c.ChildBirthdate,
                             Course = e.Course,
                             RoomNo = e.RoomNo,
                             EnrollmentDate = e.EnrollmentDate,
                             PaymentType = p.PaymentType,
                             Amount = p.Amount,
                             PaymentDate = p.PaymentDate,
                             Status = p.Status,
                             EnrollmentId = e.EnrollmentId,
                             ChildId = c.ChildId
                         };

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.ChildFirstName.Contains(searchString)
                 || s.ChildBirthdate.ToString().Contains(searchString)
                 || s.Course.Contains(searchString)
                 || s.RoomNo.Contains(searchString)
                 || s.EnrollmentDate.ToString().Contains(searchString)
                 || s.PaymentType.Contains(searchString)
                 || s.Amount.ToString().Contains(searchString)
                 || s.PaymentDate.ToString().Contains(searchString)
                 || s.Status.Contains(searchString));
            }
            return View(await result.ToListAsync());
          /*  return View(await _context.PaymentVM.ToListAsync());*/
        }

        // GET: PaymentVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentVM = await _context.Payment
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentVM == null)
            {
                return NotFound();
            }

            return View(paymentVM);
        }

       /* // GET: PaymentVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentListId,PaymentId,ChildFirstName,ChildBirthdate,Course,RoomNo,EnrollmentDate,PaymentType,Amount,PaymentDate,Status,EnrollmentId,ChildId")] PaymentVM paymentVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentVM);
        }
*/
        // GET: PaymentVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentVM = await _context.PaymentVM.FindAsync(id);
            if (paymentVM == null)
            {
                return NotFound();
            }
            return View(paymentVM);
        }

        // POST: PaymentVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentListId,PaymentId,ChildFirstName,ChildBirthdate,Course,RoomNo,EnrollmentDate,PaymentType,Amount,PaymentDate,Status,EnrollmentId,ChildId")] PaymentVM paymentVM)
        {
            if (id != paymentVM.PaymentListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentVMExists(paymentVM.PaymentListId))
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
            return View(paymentVM);
        }

        // GET: PaymentVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentVM = await _context.PaymentVM
                .FirstOrDefaultAsync(m => m.PaymentListId == id);
            if (paymentVM == null)
            {
                return NotFound();
            }

            return View(paymentVM);
        }

        // POST: PaymentVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentVM = await _context.PaymentVM.FindAsync(id);
            _context.PaymentVM.Remove(paymentVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentVMExists(int id)
        {
            return _context.PaymentVM.Any(e => e.PaymentListId == id);
        }
    }
}
