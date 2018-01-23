namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class InviteToTeamCommand
    {
        public string Excecute(string[] inputArgs)
        {

            string teamName = inputArgs[0];

            string userName = inputArgs[1];

            using (var db = new TeamBuilderContext())
            {

                Team team = db.Teams.Include(t => t.Creator)
                    .SingleOrDefault(t => t.Name == teamName);

                User userToInvite = db.Users.SingleOrDefault(t => t.Username == userName);

                if (Session.User == null)
                    throw new InvalidOperationException("You should login first!");


                User user = Session.User;

                if (team.Creator.Username != user.Username)
                    throw new InvalidOperationException("Not allowed!");
                
                if (team == null || userToInvite == null)
                    throw new ArgumentException("Team or user does not exist!");


                // NE E DOVURSHENO  
                if (db.Invitations.Any(i => i.InvitedUser.Username == userName
                     && i.Team.Name == teamName))
                    throw new InvalidOperationException("Invite is already sent!");

              

                Invitation invitation = new Invitation()
                {
                    InvitedUser = userToInvite,
                    Team = team,
                    IsActive = true
                };

                db.Invitations.Add(invitation);
                db.SaveChanges();

                return $"Team {teamName} invited {userName}!";
            }

        }
    }
}
