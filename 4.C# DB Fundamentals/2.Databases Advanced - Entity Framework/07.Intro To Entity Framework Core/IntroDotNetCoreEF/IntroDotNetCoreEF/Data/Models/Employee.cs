using System;
using System.Collections.Generic;

namespace IntroDotNetCoreEF.Data.Models
{
    //mahame partial
    public class Employee
    {
        public Employee()
        {
            //ostavame go prazno
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JobTitle { get; set; }
        public int DepartmentId { get; set; }
        public int? ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public int? AddressId { get; set; }

        public Address Address { get; set; }
        public Department Department { get; set; }
        public Employee Manager { get; set; }


        //Dobavqme si HashSet-a da e tuka zashtoto tova e ManyToMany vruzka !
        public ICollection<EmployeeProject> EmployeesProjects { get; set; }
        = new HashSet<EmployeeProject>();

        //Dobavqme si spiuka
        public ICollection<Employee> InverseManager { get; set; }
        = new List<Employee>();
    }
}
