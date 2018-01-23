namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class CreateTeamCommand
    {
        public string Excecute(string[] inputArgs)
        {
            string teamName = inputArgs[0];

            string acronym = inputArgs[1];
            

            if (acronym.Length != 3)
                throw new ArgumentException($"Acronym {acronym} not valid!");


            string description = inputArgs[2];

            using (var db = new TeamBuilderContext())
            {

                Team teamExists = db.Teams.SingleOrDefault(u => u.Name == teamName);

                if (teamExists != null)
                    throw new ArgumentException($"Team {teamExists.Name} exists!");


                if (Session.User == null)
                    throw new InvalidOperationException("You should login first!");

                    User currentUser = Session.User;

                Team team = new Team()
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = currentUser.Id 
                };

                db.Teams.Add(team);
                db.SaveChanges();

                return $"Team {team.Name} successfully created!";
            }
            
        }
    }
}
