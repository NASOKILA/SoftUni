namespace ProductsShop.App.Commands
{
    using ProductsShop.App.Commands.CommandInterface;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExitCommand : ICommand
    {
        public string Excecute(params string[] args)
        {
            Console.WriteLine("Bye bye !");
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
