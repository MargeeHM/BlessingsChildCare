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
   
    public class PaymentsController : Controller
    {
        private readonly BlessingsdbContext _context;

        public PaymentsController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var blessingsdbContext = _context.Payment.Include(p => p.Child);
            return View(await blessingsdbContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Child)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create(int ChildId)
        {
            var children = from e in _context.Child where e.ChildId == ChildId select e;
            ViewData["ChildId"] = new SelectList(children, "ChildId", "ChildLastName");

            /*    var coursefee = from cf in _context.CourseFees join e in _context.Enrollment on cf.Course equals e.Course select cf.Fee;
                double amount = Convert.ToDouble(coursefee);
                ViewData["Amount"] = new SelectList(amount, "ChildId", "ChildLastName");*/
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,PayerName,PaymentType,Amount,PaymentDate,Status,ChildId")] Payment payment)
        {
        if (ModelState.IsValid)
        {
                var coursefee = from c in _context.Child
                                join e in _context.Enrollment on payment.ChildId equals e.ChildId 
                                join cf in _context.CourseFees on e.Course equals cf.Course
                                select cf.Fee;

           payment.Amount = Convert.ToInt32(coursefee.First());
            _context.Add(payment);
           await _context.SaveChangesAsync();

           
           return RedirectToAction("Details", "Children", new { id = payment.ChildId });
        }
            var children = from c in _context.EnrollmentViewModel where c.ChildId == payment.ChildId select c;
            ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", payment.ChildId);
        return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
        if (id == null)
        {
           return NotFound();
        }

        var payment = await _context.Payment.FindAsync(id);
        if (payment == null)
        {
           return NotFound();
        }
        ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", payment.ChildId);
        return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,PayerName,PaymentType,Amount,PaymentDate,ChildId")] Payment payment)
        {
        if (id != payment.PaymentId)
        {
           return NotFound();
        }

        if (ModelState.IsValid)
        {
           try
           {
               _context.Update(payment);
               await _context.SaveChangesAsync();
           }
           catch (DbUpdateConcurrencyException)
           {
               if (!PaymentExists(payment.PaymentId))
               {
                   return NotFound();
               }
               else
               {
                   throw;
               }
           }
           return RedirectToAction("Details", "Children", new { id = payment.ChildId });
        }
        ViewData["ChildId"] = new SelectList(_context.Child, "ChildId", "ChildFirstName", payment.ChildId);
        return View(payment);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
        if (id == null)
        {
           return NotFound();
        }

        var payment = await _context.Payment
           .Include(p => p.Child)
           .FirstOrDefaultAsync(m => m.PaymentId == id);
        if (payment == null)
        {
           return NotFound();
        }

        return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        var payment = await _context.Payment.FindAsync(id);
        _context.Payment.Remove(payment);
        await _context.SaveChangesAsync();
        return RedirectToAction("Details", "Children", new { id = payment.ChildId });
        }

        private bool PaymentExists(int id)
        {
        return _context.Payment.Any(e => e.PaymentId == id);
        }
        }
        }
