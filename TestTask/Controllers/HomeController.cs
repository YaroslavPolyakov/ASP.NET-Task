using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TestTask.Models;
using WebGrease.Css.Extensions;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        TaskUserContext db = new TaskUserContext();
        public ActionResult Index()
        {
            ViewBag.Data = (from empl in db.Employees
                join st in db.SpentTimes on empl.Id equals st.EmployeeId
                join t in db.Tasks on st.TaskId equals t.Id
                group st by new {st.EmployeeTask.Name} into g
                select new ReportModel {TaskName = g.Key.Name, Duration = g.Max(x => x.Duration)})
                .ToList();
                   
            return View();
        }
    }
}