using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using task1.Models;

namespace task1.Controllers
{
    public class CustomerController : Controller
    {

        dbContainer DB = new dbContainer();
        // GET: Customer
        public ActionResult Index()
        {
            var Data = DB.Customers.Include(c => c.Employee).Include(c => c.Gender).AsNoTracking().ToList();
            return View(Data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(DB.Genders.AsNoTracking().ToList(), "Id", "GenderType");
            ViewBag.EmployeeId = new SelectList(DB.Employees.AsNoTracking().ToList(), "Id", "EmpName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer cus1)
        {
            if (ModelState.IsValid)
            {
                DB.Customers.Add(cus1);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.GenderId = new SelectList(DB.Genders.AsNoTracking().ToList(), "Id", "GenderType");
                ViewBag.EmployeeId = new SelectList(DB.Employees.AsNoTracking().ToList(), "Id", "EmpName");
                return View(cus1);
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Data = DB.Customers.Find(id);
            ViewBag.GenderId = new SelectList(DB.Genders, "Id", "GenderType", Data.GenderId);
            ViewBag.EmployeeId = new SelectList(DB.Employees, "Id", "EmpName", Data.EmployeeId);
            return View(Data);
        }

        [HttpPost]
        public ActionResult Edit(Customer Cus1)
        {
            if (ModelState.IsValid)
            {

                #region anather way to eqal and hand data click here
                //var OldData = DB.Employees.Find(Emp1.id);
                //OldData.EmpName = Emp1.EmpName;
                //OldData.EmpAddress = Emp1.EmpAddress;
                //OldData.EmpBirthDate = Emp1.EmpBirthDate;
                //OldData.GenderId = Emp1.GenderId;
                //OldData.CountryId = Emp1.CountryId;
                #endregion
                DB.Entry(Cus1).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.GenderId = new SelectList(DB.Genders, "Id", "GenderType", Cus1.GenderId);
                ViewBag.EmployeeId = new SelectList(DB.Employees, "Id", "EmpName", Cus1.EmployeeId);
                return View(Cus1);
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Data = DB.Customers.Find(id);
            ViewBag.GenderId = new SelectList(DB.Genders.Include(c => c.GenderType), "Id", "GenderType", Data.GenderId);
            ViewBag.EmployeeId = new SelectList(DB.Employees.Include(c => c.EmpName), "Id", "EmpName", Data.EmployeeId);

            return View(Data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var OldD = DB.Customers.Find(id);
            DB.Customers.Remove(OldD);
            DB.SaveChanges();
            return RedirectToAction("Index");


        }

      

    }
}