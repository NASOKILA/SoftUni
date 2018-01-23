namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class LoginCommand
    {
        public string Excecute(string[] inputArgs)
        {
            using (var context = new TeamBuilderContext())
            {
                string username = inputArgs[0];
                string password = inputArgs[1];

                //vzimame si usera s tozi username
                User user = context.Users
                    .SingleOrDefault(u => u.Username == username && u.Password == password);

                //Ako nqma takuv user hvurlqme exception sus suobshtenie
                if (user == null)
                    throw new ArgumentException("Invalid username or password!");

                //Gledame dali ne e iztrit
                if (user.IsDeleted == true)
                    throw new ArgumentException("Invalid username or password!");
                
               

                //proverqvame dali veche ne e lognat
                if(Session.User != null)
                    throw new ArgumentException("User is already logged!");

                Session.User = user;

                return $"User {username} has logged in successfully";
            }
            
        }

    }
}
