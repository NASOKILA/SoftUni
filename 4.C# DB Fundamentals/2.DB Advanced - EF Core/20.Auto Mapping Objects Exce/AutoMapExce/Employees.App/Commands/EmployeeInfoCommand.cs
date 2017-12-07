
namespace Employees.App.Commands
{
    using Employees.App.Commands.CommandInterface;
    using Employees.Data;
    using Employees.Models;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Excecute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            Employee employee = employeeService.EmployeeById(employeeId);

            return ($"ID: {employee.Id} - {employee.FirstName} {employee.LastName} -  ${employee.Salary:f2}");
        }
    }
}
