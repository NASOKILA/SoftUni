namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AcceptInviteCommand
    {
        public string Excecute(string[] inputArgs)
        {

            string teamName = inputArgs[0];
            using (var db = new TeamBuilderContext())
            {
                Team team = db.Teams.Include(t => t.Creator)
                       .SingleOrDefault(t => t.Name == teamName);

                if (team == null)
                    throw new ArgumentException($"Team {teamName} not found!");

                if (Session.User == null)
                    throw new InvalidOperationException("You should login first!");

                Invitation invite = db.Invitations
                    .SingleOrDefault(i => i.TeamId == team.Id);

                if (invite == null || invite.IsActive == false)
                    throw new ArgumentException($"Invite from {teamName} is not found!");

                User user = Session.User;

                if (invite.InvitedUserId != user.Id)
                    throw new ArgumentException($"You were not invited!");

                //Kazvame che veche e prieta kato q deezaktivirame
                invite.IsActive = false;

                //Join the user to the team
                UserTeam userTeam = new UserTeam()
                {
                    UserId = user.Id,
                    TeamId = team.Id
                };

                db.UserTeams.Add(userTeam);
                db.SaveChanges();



                return $"User {user.Username} joined team {teamName}!";
            }


        }
    }
}
