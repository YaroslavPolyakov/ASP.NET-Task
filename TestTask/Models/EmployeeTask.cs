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

}