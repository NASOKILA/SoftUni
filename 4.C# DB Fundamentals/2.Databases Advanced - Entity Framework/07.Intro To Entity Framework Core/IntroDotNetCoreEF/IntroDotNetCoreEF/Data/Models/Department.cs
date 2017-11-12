using System;
using System.Collections.Generic;

namespace IntroDotNetCoreEF.Data.Models
{
    //mahame partial
    public class Department
    {
        public Department()
        {
            //Ostavqme go prazno
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        //Dobavqme si spisucite
        public ICollection<DeletedEmployee> DeletedEmployees { get; set; }
         = new List<DeletedEmployee>();

        public ICollection<Employee> Employees { get; set; }
         = new List<Employee>();
    }
}
