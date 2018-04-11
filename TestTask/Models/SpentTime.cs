using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
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