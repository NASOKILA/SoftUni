using System;
using System.Collections.Generic;

namespace IntroDotNetCoreEF.Data.Models
{
    //mahame partial
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
