namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;

    public class ShowEventCommand
    {

        public string Excecute(string[] inputArgs)
        {

            string name = inputArgs[0];

            using (var db = new TeamBuilderContext())
            {

                var eve = db.Events
                    .Include(e => e.ParticipatingEventTeams)
                    .ThenInclude(pet => pet.Team)
                    .SingleOrDefault(e => e.Name == name);

                if (eve == null)
                    throw new ArgumentException($"Event {name} not found!");

                StringBuilder sb = new StringBuilder();

                sb.Append($"{eve.Name} {eve.StartDate} {eve.EndDate} {eve.Description}" + Environment.NewLine);
                sb.Append("Teams:" + Environment.NewLine);

                foreach (var pet in eve.ParticipatingEventTeams)
                {
                    var team = db.Teams.SingleOrDefault(u => u.Id == pet.TeamId);
                    
                    sb.Append("-" + team.Name + Environment.NewLine);
                }
                
                return sb.ToString();
            }

        }
    }
}