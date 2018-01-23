namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using TeamBuilder.Models;

    public class LogoutCommand
    {
        public string Excecute(string[] inputArgs)
        {
            if (inputArgs.Length > 0)
                throw new ArgumentException("Invalid arguments count!");

            if (Session.User == null)
                return "You should log in first.";
            
            //Vzimame si lognatiq user ot klasa Session
            User user = Session.User;

            // izlizame i printirame suobshtenie
            Session.User = null;
            return $"You {user.Username} successfully logged out !";
        }

    }
}
