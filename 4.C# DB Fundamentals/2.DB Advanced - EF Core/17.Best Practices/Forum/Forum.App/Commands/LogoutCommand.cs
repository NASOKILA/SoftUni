namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LogoutCommand : ICommand
    {
        public string Excecute(params string[] args)
        {

            if (Session.User == null)
            {
                return "You are not logged in.";
            }

            Session.User = null;
            return $"You have successfully logged out !";
        }
    }
}
