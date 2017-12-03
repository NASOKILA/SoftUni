namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Data.Models;
    using Forum.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RegisterCommand : ICommand
    {

        //podavame si IUserService za da mojem da go polzvame       
        private readonly IUserService IUserService;

        public RegisterCommand(IUserService IUserService)
        {
            this.IUserService = IUserService;
        }

        public string Excecute(params string[] args)
        {
            var username = args[0];
            var password = int.Parse(args[1]);


            //Proverqvame dali ima takuv user i ako ima vrushtame suobshtenie !
            var userExists = IUserService.ByUsername(username);
            if (userExists != null)
            {
                return "User already exists !";
            }

            //Suzdavame si nov user
            IUserService.Create(username, password);
            //V SERVISA AVTOMATiCHNO SI IMA SAVECHANGES.

            
            //Nqma da logvame usera avtomatichno sled registraciq
            return $"Congratulations, you registered successfully !";

        }
    }
}





