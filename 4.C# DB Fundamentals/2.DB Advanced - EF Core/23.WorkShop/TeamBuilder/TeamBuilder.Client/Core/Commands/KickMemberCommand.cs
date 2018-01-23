namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class KickMemberCommand
    {
        public string Excecute(string[] inputArgs)
        {


            string teamName = inputArgs[0];
            string userName = inputArgs[1];

            using (var db = new TeamBuilderContext())
            {
                Team team = db.Teams
                    .Include(t => t.Creator)
                    .Include(t => t.UserTeams)
                    .ThenInclude(ut => ut.User)
                       .SingleOrDefault(t => t.Name == teamName);

                User userToDelete = db.Users
                       .SingleOrDefault(t => t.Username == userName);

                if (team == null)
                    throw new ArgumentException($"Team {teamName} not found!");

                if (userToDelete == null)
                    throw new ArgumentException($"User {userName} not found!");


                if (Session.User == null)
                    throw new InvalidOperationException("You should login first!");
                
                User currentUser = Session.User;
                
                if(team.Creator.Username != currentUser.Username)
                    throw new InvalidOperationException("Not allowed!");
                
                if(team.Creator.Username == userName)
                    throw new InvalidOperationException("Command not allowed. Use DisbandTeam instead.");


                UserTeam userTeam = db.UserTeams
                    .SingleOrDefault(ut => ut.UserId == userToDelete.Id && ut.TeamId == team.Id);

                if (userTeam == null)
                    throw new ArgumentException($"User {userName} is not a member in {teamName}!");


                db.UserTeams.Remove(userTeam);
                db.SaveChanges();

                
                return $"User {userName} was kicked from {teamName}!";
            }

        }
    }
}
