namespace Employees.Models
{
    using System;

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; } //nullable

        public string Address { get; set; }
    }
}
