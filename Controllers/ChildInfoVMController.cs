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
    public class ChildInfoVMController : Controller
    {
        private readonly BlessingsdbContext _context;

        public ChildInfoVMController(BlessingsdbContext context)
        {
            _context = context;
        }

        // GET: ChildInfoVMController
        public async Task<IActionResult> Index(string searchString)
        {
            var result = from c in _context.Child
                         join e in _context.Enrollment on c.ChildId equals e.ChildId into temp
                         from lj in temp.DefaultIfEmpty()
                         join a in _context.AuthorizedPickup on lj.ChildId equals a.ChildId into temp1
                         from lj1 in temp1.DefaultIfEmpty()
                         join m in _context.Medical on lj1.ChildId equals m.ChildId into temp2
                         from lj2 in temp2.DefaultIfEmpty()
                         join ec in _context.Emergency on lj2.ChildId equals ec.ChildId into temp3
                         from lj3 in temp3.DefaultIfEmpty()
                         select new ChildInfoVM
                         {
                            ChildFirstName = c.ChildFirstName,
                            ChildLastName = c.ChildLastName,
                            ChildBirthdate = c.ChildBirthdate,
                            Age = c.Age,
                            FatherFirstName = c.FatherFirstName,
                            FatherLastName = c.FatherLastName,
                            MotherFirstName = c.MotherFirstName,
                            MotherLastName = c.MotherLastName,
                            ContactPhone = c.ContactPhone,
                            Street = c.Street,
                            City = c.City,
                            State = c.State,
                            Zipcode = c.Zipcode,
                            Course = lj.Course,
                            RoomNo = lj.RoomNo,
                            EnrollmentDate = lj.EnrollmentDate,
                            PersonName = lj1.PersonName,
                            Relation = lj1.Relation,
                            phone = lj1.phone,
                            PersonToContactFirstName = lj2.PersonToContactFirstName,
                            PersonToContactLastName = lj2.PersonToContactLastName,
                            PersonToContactPhone = lj2.PersonToContactPhone,
                            ChildsDoctorFirstName = lj2.ChildsDoctorFirstName,
                            ChildsDoctorLastName = lj2.ChildsDoctorLastName,
                            ChildsDoctorPhone = lj2.ChildsDoctorPhone,
                            RegularlyUsedHospitalName = lj2.RegularlyUsedHospitalName,
                            DiaetryRestriction = lj2.DiaetryRestriction,
                            MedicalIssue = lj2.MedicalIssue,
                            EmergencyContactFirstName = lj3.EmergencyContactFirstName,
                            EmergencyContactLastName = lj3.EmergencyContactLastName,
                            EmergencyContactPhone = lj3.EmergencyContactPhone,
                            Relationship = lj3.Relationship
                         };

            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(c => c.ChildFirstName.Contains(searchString)
                 || c.ChildLastName.Contains(searchString));
            }
            return View(await result.ToListAsync());
        }

        // GET: ChildInfoVMController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChildInfoVMController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChildInfoVMController/Create
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

        // GET: ChildInfoVMController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChildInfoVMController/Edit/5
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

        // GET: ChildInfoVMController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChildInfoVMController/Delete/5
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
