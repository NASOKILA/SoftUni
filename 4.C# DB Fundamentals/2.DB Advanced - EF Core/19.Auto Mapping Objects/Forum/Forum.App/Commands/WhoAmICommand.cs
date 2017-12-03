namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using Forum.Data.Models;
    using System.Text;

    public class WhoAmICommand : ICommand
    {
        public string Excecute(params string[] args)
        {
            
            if (Session.User == null)
                return "You are not logged in.";

            var user = Session.User;
            
            return $"Your name is {user.UserName}";

        }
    }
}
