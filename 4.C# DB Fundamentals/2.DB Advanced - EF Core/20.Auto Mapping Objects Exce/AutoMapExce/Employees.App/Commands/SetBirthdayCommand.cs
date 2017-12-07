namespace Employees.App.Commands
{
    using Employees.App.Commands.CommandInterface;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SetBirthdayCommand : ICommand
    {

        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Excecute(params string[] args)
        {

            int employeeId = int.Parse(args[0]);

            DateTime birthday = DateTime.ParseExact(args[1], "dd-MM-yyyy", null);

            string fullName = employeeService.SetBirthday(employeeId, birthday);

            return $"{fullName} has birthday {birthday} !";
        }
    }
}
