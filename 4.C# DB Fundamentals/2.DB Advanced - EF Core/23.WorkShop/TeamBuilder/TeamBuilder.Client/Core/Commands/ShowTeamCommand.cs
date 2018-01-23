namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Data;

    public class ShowTeamCommand
    {
        public string Excecute(string[] inputArgs)
        {

            string teamName = inputArgs[0];

            using (var db = new TeamBuilderContext())
            {
                
                var team = db.Teams
                    .Include(t => t.UserTeams)
                    .ThenInclude(ut => ut.User)
                    .SingleOrDefault(e => e.Name == teamName);

                if (team == null)
                    throw new ArgumentException($"Team {teamName} not found!");

                StringBuilder sb = new StringBuilder();

                sb.Append($"{team.Name} {team.Acronym}" + Environment.NewLine);
                sb.Append("Members:" + Environment.NewLine);

                foreach (var m in team.UserTeams)
                {
                    var user = db.Users.SingleOrDefault(u => u.Id == m.UserId);
                    sb.Append("--" + user.Username + Environment.NewLine);
                }
                
                return sb.ToString();

                
            }

        }
    }
}
