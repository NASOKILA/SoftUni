namespace Employees.App.Commands
{
    using Employees.App.Commands.CommandInterface;
    using Employees.DtoModels;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Excecute(params string[] args)
        {
            string firstName = args[0];
            
            string lastName = args[1];

            decimal salary = decimal.Parse(args[2]);


            //Pravim si Dto kato polzvame dopulnitelniq konstruktur
            EmployeeDto employeeDto = new EmployeeDto(firstName, lastName, salary);
            
            //Polzvame DTO za tova sme go napravili, podavame go na metoda v servica za da ni suzdade rabotnika!
            employeeService.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} has been added to the database!";
        }
    }
}
