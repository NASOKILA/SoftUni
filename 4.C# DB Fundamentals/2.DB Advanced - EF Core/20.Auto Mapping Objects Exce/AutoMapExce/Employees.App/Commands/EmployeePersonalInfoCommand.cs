namespace Employees.App.Commands
{
    using Employees.App.Commands.CommandInterface;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Excecute(params string[] args)
        {

            int employeeId = int.Parse(args[0]);

            var employee = employeeService.PeronalById(employeeId);

            //ako birthday e null dani izpishe dadeno suobshtenie
            string birthDay = "[no birthday specified]";

            if (employee.BirthDay != null)
            {
                birthDay = employee.BirthDay.Value.ToString();
            }

            //ako address e null dani izpishe dadeno suobshtenie
            string address = employee.Address ?? "[no address specified]";

            string result = $"ID: {employee.Id}" +
             $" - { employee.FirstName }" +
             $" - { employee.LastName}" +
             $" -  ${ employee.Salary:f2}" + Environment.NewLine +
             $"BirthDay: {birthDay}" + Environment.NewLine +
             $"Address: {address}";
            
            return result;

        }
    }
}
