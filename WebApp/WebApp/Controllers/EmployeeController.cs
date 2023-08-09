using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeRepos repo;

        public EmployeeController()
        {
            this.repo = new EmployeeRepos();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel student)
        {
            if (ModelState.IsValid)
            {
                var count = repo.AddEmployee(student);
                if (count > 0)
                {
                    ViewBag.Okay = "Data Added";
                }
            }
            return View();
        }

        public ActionResult GetAll()
        {
            var data = repo.GetAllData();
            return View(data);
        }

        public ActionResult Details(int id)
        {
            var data = repo.GetDetails(id);
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = repo.GetDetails(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(int id, EmployeeModel student)
        {
            if (ModelState.IsValid)
            {
                var count = repo.UpdateData(id, student);

                return RedirectToAction("GetAll");

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var data = repo.DeleteData(id);
            return RedirectToAction("GetAll");
        }
    }
}