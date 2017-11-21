using System;
using System.Collections.Generic;

namespace IntroDotNetCoreEF.Data.Models
{
    //mahame partial
    public class Project
    {
        public Project()
        {
            //Otaavqme go prazno
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //Dobavqme si HashSet-a da e tuka zashtoto tova e ManyToMany vruzka !
        //I ne mojem da imame dve stoinosti na dve mesta !
        public ICollection<EmployeeProject> EmployeesProjects { get; set; }
        = new HashSet<EmployeeProject>();
    }
}
