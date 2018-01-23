namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class DeleteUserCommand
    {

        public string Excecute(string[] inputArgs)
        {

            using (var db = new TeamBuilderContext())
            {
                if (inputArgs.Length > 0)
                    throw new ArgumentException("Invalid arguments count!");

                //Gledame dali imame lognat user lognat
                if (Session.User == null)
                    throw new InvalidOperationException("Invalid Credentials!");


                //vzimme usera ot bazata po username
                User currentUser = Session.User;

                string currentUserUsername = currentUser.Username;
                User userToDelete = db.Users
                    .SingleOrDefault(u => u.Username == currentUserUsername);

                //Gledame dali veche e markiran kato iztrit
                if (userToDelete.IsDeleted == true)
                    throw new InvalidOperationException($"User {currentUserUsername} is already deleted!");


                //Markirame kato iztrit
                userToDelete.IsDeleted = true;
                db.SaveChanges();
                
                // NE ZNAM ZASHTO NE STAWA !!! NE ISKA DA SEIVNE PROMENITE V BAZATA !


                //Logoutvame
                Session.User = null;


                return $"User {currentUserUsername} was deleted successfully!";


            }

        }
    }
}
