namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LoginCommand : ICommand
    {
        //Nie iskame tova avtomatichno da se pulni zatova s ipravim konstruktor i IUserService 
        //koito da se setva ot nego pri suzdavane.

        private readonly IUserService userService;

        public LoginCommand(IUserService userService)
        {
            this.userService = userService;
        }

        public string Excecute(params string[] args)
        {
            var username = args[0];
            var password = int.Parse(args[1]);

            var user = userService.ByUsernameAndPassword(username, password);
            
            if (user == null)
            {
                return "Cannot login Invalid username or password!";
            }

            //podavame usera na Session
            Session.User = user;

            return $"{user.UserName} has logged in successfully !";
        }
    }
}
