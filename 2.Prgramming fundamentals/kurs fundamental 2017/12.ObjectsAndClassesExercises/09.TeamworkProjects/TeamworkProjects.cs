using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.TeamworkProjects
{

    class Team
    {
        public string Name { get; set; }

        public List<string> Members { get; set; }

        public string LeaderNme { get; set; }
    }


    class TeamworkProjects
    {
        static void Main(string[] args)
        {
           
            List<Team> teams = new List<Team>();

            Dictionary<string, string> leadersAndTeams = new Dictionary<string, string>();

            SetLeadersAndTeams(teams, leadersAndTeams);

            SetAssignments(leadersAndTeams, teams);

            PrintResult(teams, leadersAndTeams);

        }

        private static void PrintResult(List<Team> teams, Dictionary<string, string> leadersAndTeams)
        {
           
            teams = teams.Where(t => t.Members.Count > 0).ToList();
            teams = teams.OrderByDescending(t => t.Members.Count).ThenBy(t => t.Name).ToList();
            foreach (var team in teams)
            {
                if (team.Members.Count > 0)
                {
                    Console.WriteLine(team.Name);
                    Console.WriteLine($"- {team.LeaderNme}");
                    foreach (var member in team.Members.OrderBy(a => a))
                    {
                        Console.WriteLine($"-- {member}");
                    }
                }
            }

            List<Team> disbandTeams = teams.Where(t => t.Members.Count == 0).ToList();
            
                Console.WriteLine("Teams to disband:");

            foreach (var team in disbandTeams.OrderBy(t => t.Name))
            {
                if (team.Members.Count == 0)
                {
                    Console.WriteLine(team.Name);
                }
            }
        }

        private static void SetAssignments(Dictionary<string, string> leadersAndTeams, List<Team> teams)
        {

            string[] assignment = Console.ReadLine()
                .Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            while (assignment[0].Split(' ').First() != "end")
            {
                string name = assignment[0];
                string joiningTeam = assignment[1];

                if (!leadersAndTeams.ContainsValue(joiningTeam))
                    Console.WriteLine($"Team {joiningTeam} does not exist!");
                else if (teams.Any(t => t.Members.Contains(name) || t.LeaderNme == name)) // ako ima drug team sus sushtiq user v nego
                    Console.WriteLine($"Member {name} cannot join team {joiningTeam}!");
                else
                {
                    Team currentTeam = teams.Where(t => t.Name == joiningTeam).FirstOrDefault();
                    currentTeam.Members.Add(name);    // member added
                }

                assignment = Console.ReadLine()
                .Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

        }

        private static void SetLeadersAndTeams(List<Team> teams, Dictionary<string, string> leadersAndTeams)
        {
            int numOfTeams = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfTeams; i++)
            {
                string[] userAndTeam = Console.ReadLine().Split('-').ToArray();
                string leader = userAndTeam[0];
                string teamName = userAndTeam[1];

                List<string> members = new List<string>();
                Team newteam = new Team()
                {
                    LeaderNme = leader,
                    Name = teamName,
                    Members = members
                };

                if (leadersAndTeams.ContainsValue(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else if (leadersAndTeams.ContainsKey(leader))
                {
                    Console.WriteLine($"{leader} cannot create another team!");
                    continue;
                }
                else
                {
                    leadersAndTeams[leader] = teamName;
                    Console.WriteLine($"Team {teamName} has been created by {leader}!");
                    teams.Add(newteam);
                }

            }
        }
    }
}
