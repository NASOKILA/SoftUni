namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class ModifyUserCommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public static string Execute(string[] data)
        {
            string username = data[1];
            string property = data[2];
            string newValue = data[3];

            if (Session.User == null)
                throw new InvalidOperationException("Invalid Credentials!");

            using (PhotoShareContext context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username);
               
                if (user == null)
                    throw new ArgumentException($"User {username} not found!");

                switch (property)
                {
                    case "Password":
                        if (!newValue.Any(c => char.IsDigit(c)) || !newValue.Any(c => char.IsLower(c)))
                            throw new ArgumentException($"Value {newValue} not valid." + Environment.NewLine + "Invalid Password");
                        user.Password = newValue;
                        context.SaveChanges();
                        break;

                    case "BornTown":
                        if (!context.Towns.Any(t => t.Name == newValue))
                            throw new ArgumentException($"Value {newValue} not valid." + Environment.NewLine + $"Town {newValue} not found!");

                        var bornTown = context.Towns.SingleOrDefault(t => t.Name == newValue);
                        user.BornTown = bornTown;
                        context.SaveChanges();
                        break;

                    case "CurrentTown":
                        if (!context.Towns.Any(t => t.Name == newValue))
                            throw new ArgumentException($"Value {newValue} not valid." + Environment.NewLine + $"Town {newValue} not found!");

                        var currentTown = context.Towns.SingleOrDefault(t => t.Name == newValue);
                        user.CurrentTown = currentTown;
                        context.SaveChanges();
                        break;
                        

                    default:
                        throw new ArgumentException($"Property {property} not supported!");

                }

                
            return $"User {user.Username} {property} is {newValue}.";
            }
            
            
        }
    }
}
