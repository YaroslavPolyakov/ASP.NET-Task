using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }


        public ICollection<SpentTime> SpentTime { get; set; }

    }
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<SpentTime> SpentTime { get; set; }
    }
    public class SpentTime
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeTask")]
        public int? TaskId { get; set; }
        public int Duration { get; set; }

        public EmployeeTask EmployeeTask { get; set; }

        public Employee Employee { get; set; }
    } 
}