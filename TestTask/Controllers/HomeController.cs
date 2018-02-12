using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        TaskUserContext db = new TaskUserContext();
        public ActionResult Index()
        {
            IEnumerable<EmployeeTask> tasks = db.Tasks;
            IEnumerable<Employee> employees = db.Employees;
            IEnumerable<SpentTime> spenttimes = db.SpentTimes;
            ViewBag.Tasks = tasks;
            ViewBag.Employees = employees;
            ViewBag.SpentTimes = spenttimes;
            //var data = db.SpentTimes.GroupBy()
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeTask task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}