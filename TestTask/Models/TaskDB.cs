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
            db.Tasks.Add(new EmployeeTask { Name = "Task1", Comments = "Установка Windows 10" });
            db.Tasks.Add(new EmployeeTask { Name = "Task2", Comments = "Драйвера на звук" });
            db.Tasks.Add(new EmployeeTask { Name = "Task3", Comments = "Сборка ПК" });
            db.Tasks.Add(new EmployeeTask { Name = "Task4", Comments = "Чистка от пыли" });
            db.Tasks.Add(new EmployeeTask { Name = "Task5", Comments = "Покупка видеокарты" });

            db.Employees.Add(new Employee { FullName = "Поляков1", Address = "Минск", Phone = "+375298289731" });
            db.Employees.Add(new Employee { FullName = "Харсеко", Address = "Круглое", Phone = "+312312423423" });

            db.SpentTimes.Add(new SpentTime { Duration = 2, EmployeeId = 1, TaskId = 2 });

            base.Seed(db);
        }
    }
}