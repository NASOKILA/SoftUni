namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class DisbandTeamCommand
    {
        public string Excecute(string[] args)
        {
            string teamName = args[0];

            using (var db = new TeamBuilderContext())
            {
                
                Team team = db.Teams
                 .Include(t => t.Creator)
                    .SingleOrDefault(t => t.Name == teamName);

                if (Session.User == null)
                    throw new InvalidOperationException("You should login first!");

                User currentUser = Session.User;

                if (team == null)
                    throw new ArgumentException($"Team {teamName} not found!");


                if (team.Creator.Username != currentUser.Username)
                    throw new InvalidOperationException("Not allowed!");
                

                db.Teams.Remove(team);
                db.SaveChanges();

                return $"{teamName} has disbanded!";
            }
            
        }
    }
}
