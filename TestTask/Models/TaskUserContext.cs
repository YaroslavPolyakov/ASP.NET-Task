using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestTask.Models
{
    public class TaskUserContext : DbContext
    {
        public DbSet<EmployeeTask> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SpentTime> SpentTimes { get; set; }
    }
}