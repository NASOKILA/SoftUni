namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AddTeamToCommand
    {
        public string Excecute(string[] inputArgs)
        {

            string eventName = inputArgs[0];
            string teamName = inputArgs[1];


            using (var db = new TeamBuilderContext())
            {
                var eve = db.Events.Include(e => e.Creator)
                    .SingleOrDefault(e => e.Name == eventName);
                var team = db.Teams.SingleOrDefault(t => t.Name == teamName);

                if (eve == null)
                    throw new ArgumentException($"Event {eventName} not found!");

                if (team == null)
                    throw new ArgumentException($"Team {teamName} not found!");

                User currentUser = Session.User;

                if (eve.Creator.Username != currentUser.Username)
                    throw new InvalidOperationException($"Not allowed!");

                if(db.EventTeams.Any(et => et.Event == eve && et.Team == team))
                    throw new InvalidOperationException($"Cannot add same team twice!");

                if (Session.User == null)
                    throw new InvalidOperationException($"You should login first!");


                EventTeam eventTeam = new EventTeam()
                {
                    Team = team,
                    Event = eve
                };

                db.EventTeams.Add(eventTeam);
                db.SaveChanges();
                
                return $"Team {teamName} added for {eventName}!";
            }

        }

    }
}
