namespace Employees.App.Commands
{
    using Employees.App.Commands.CommandInterface;
    using Employees.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ExitCommand : ICommand
    {
        //Tuk service ne ni trqbva
        public string Excecute(params string[] args)
        {
            Console.WriteLine("GoodBye!");
            Environment.Exit(0);
            return string.Empty;  
        }
    }
}
