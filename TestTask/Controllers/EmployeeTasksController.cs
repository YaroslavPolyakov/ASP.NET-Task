using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class EmployeeTasksController : Controller
    {
        private TaskUserContext db = new TaskUserContext();

        // GET: EmployeeTasks
        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        // GET: EmployeeTasks/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employeeTask = db.Tasks.Include(x => x.SpentTime).Include(x => x.SpentTime.Select(q => q.Employee)).FirstOrDefault(x =>x.Id == id);

            if (employeeTask == null)
            {
                return HttpNotFound();
            }
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeTasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Comments")] EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(employeeTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeTask);
        }

        // GET: EmployeeTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTask employeeTask = db.Tasks.Find(id);
            if (employeeTask == null)
            {
                return HttpNotFound();
            }
            return View(employeeTask);
        }

        // POST: EmployeeTasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Comments")] EmployeeTask employeeTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeTask);
        }

        // GET: EmployeeTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTask employeeTask = db.Tasks.Find(id);
            if (employeeTask == null)
            {
                return HttpNotFound();
            }
            return View(employeeTask);
        }

        // POST: EmployeeTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeTask employeeTask = db.Tasks.Include(x => x.SpentTime).FirstOrDefault(x => x.Id == id);

            if (!employeeTask.SpentTime.Any())
            {
                db.Tasks.Remove(employeeTask);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
