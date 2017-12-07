namespace Employees.App.Commands
{
    using Employees.App.Commands.CommandInterface;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }


        public string Excecute(params string[] args)
        {
            int employeeId = int.Parse(args[0]);

            //kato polzvame join mojem da slagame i prazni mesta v nashiq adres
            string address = string.Join(" ", args.Skip(1));

            string fullName = employeeService.SetAddress(employeeId, address);

            return $"{fullName} has address {address} !";
        }
    }
}
