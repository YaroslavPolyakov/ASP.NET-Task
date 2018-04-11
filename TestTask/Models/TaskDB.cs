using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTask.Models
{
    public class TaskDB : DropCreateDatabaseAlways <TaskUserContext>
    {
        protected override void Seed(TaskUserContext db)
        {
            db.Tasks.Add(new EmployeeTask { Name = "Task1", Comments = "Install Windows 10" });
            db.Tasks.Add(new EmployeeTask { Name = "Task2", Comments = "Install drivers" });
            db.Tasks.Add(new EmployeeTask { Name = "Task3", Comments = "Install Skype" });
            db.Tasks.Add(new EmployeeTask { Name = "Task4", Comments = "Install Antivirus" });
            db.Tasks.Add(new EmployeeTask { Name = "Task5", Comments = "Buy Video Card" });

            db.Employees.Add(new Employee { FullName = "Polyakov", Address = "Minsk", Phone = "97987987" });
            db.Employees.Add(new Employee { FullName = "Ivanov", Address = "Brest", Phone = "321321321" });

            db.SpentTimes.Add(new SpentTime { Duration = 2, EmployeeId = 1, TaskId = 2 });
            db.SpentTimes.Add(new SpentTime { Duration = 10, EmployeeId = 1, TaskId = 2 });
            db.SpentTimes.Add(new SpentTime { Duration = 2, EmployeeId = 1, TaskId = 1 });
            db.SpentTimes.Add(new SpentTime { Duration = 10, EmployeeId = 1, TaskId = 3 });
            db.SpentTimes.Add(new SpentTime { Duration = 20, EmployeeId = 2, TaskId = 2 });
            db.SpentTimes.Add(new SpentTime { Duration = 100, EmployeeId = 2, TaskId = 2 });
            db.SpentTimes.Add(new SpentTime { Duration = 2, EmployeeId = 2, TaskId = 1 });
            db.SpentTimes.Add(new SpentTime { Duration = 1, EmployeeId = 2, TaskId = 3 });

            base.Seed(db);
        }
    }
}