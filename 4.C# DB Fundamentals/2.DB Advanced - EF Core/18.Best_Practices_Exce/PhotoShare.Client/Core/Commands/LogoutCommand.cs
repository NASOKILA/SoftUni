namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LogoutCommand
    {
        public static string Execute()
        {
                if (Session.User == null)
                {
                    return "You should log in first in order to logout.";
                }

                User user = Session.User;

                Session.User = null;
                return $"You {user.Username} successfully logged out !";   
        }
    }
}
