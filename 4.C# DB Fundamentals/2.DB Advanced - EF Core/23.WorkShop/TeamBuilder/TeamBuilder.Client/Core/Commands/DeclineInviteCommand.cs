namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class DeclineInviteCommand
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
                

                invite.IsActive = false;
                db.SaveChanges();

                return $"Invite from {teamName} declined.";
            }
        }


    }
}
