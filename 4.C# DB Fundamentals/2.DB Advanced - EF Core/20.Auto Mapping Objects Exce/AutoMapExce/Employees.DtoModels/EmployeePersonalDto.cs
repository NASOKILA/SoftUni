
namespace Employees.DtoModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeePersonalDto
    {
        //Shte durji vsichko koeto ima i Employee
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; } //nullable

        public string Address { get; set; }
    }
}
