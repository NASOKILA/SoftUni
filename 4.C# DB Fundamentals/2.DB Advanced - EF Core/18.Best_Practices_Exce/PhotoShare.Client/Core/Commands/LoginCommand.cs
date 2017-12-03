namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LoginCommand
    {
        public static string Execute(string[] args)
        {

            using (var context = new PhotoShareContext())
            {
                string username = args[1];
                string password = args[2];

                User user = context.Users
                    .SingleOrDefault(u => u.Username == username && u.Password == password);

                if (user == null)
                {
                    throw new ArgumentException("Invalid username or password!");
                }

                if (Session.User != null)
                    throw new ArgumentException($"You should logout first!");

                Session.User = user;

                return $"User {username} successfully logged in!";
            }
        }
    }
}
