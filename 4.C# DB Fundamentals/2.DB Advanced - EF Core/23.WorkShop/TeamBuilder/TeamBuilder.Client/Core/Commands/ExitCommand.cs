namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExitCommand
    {
        public string Excecute(string[] inputArgs)
        {
            Environment.Exit(0);
            return "Buy-buy";
        }
    }
}
