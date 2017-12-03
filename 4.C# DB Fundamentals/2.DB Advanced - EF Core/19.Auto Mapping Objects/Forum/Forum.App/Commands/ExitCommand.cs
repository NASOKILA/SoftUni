namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    //Tova e komandata Exit koqto izliza ot programata i vrushta prazen string
    public class ExitCommand : ICommand
    {

        private IUserService userService;

        public ExitCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Excecute(params string[] args)
        {
            Environment.Exit(0);
            return string.Empty;
        }

        

    }
}





