using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {

            List<Teams> AllTeams2 = new List<Teams>();
            List<Teams> TeamsToDisband = new List<Teams>();

            int countOfTeams = int.Parse(Console.ReadLine());

            FormTeams(countOfTeams, AllTeams2);




            char[] separator = { '-', '>' };
            string userJoinsTeam = Console.ReadLine();

            while (!userJoinsTeam.Equals("end of assignment"))
            {
                string[] userJoinsTeamArr = userJoinsTeam.Split(separator).ToArray();
                string user = userJoinsTeamArr[0];
                string teamToJoin = userJoinsTeamArr[2];




                if (!AllTeams2.Any(t => t.Name.Equals(teamToJoin)))
                    Console.WriteLine("Team {0} does not exist!", teamToJoin);
                else if (AllTeams2.Any(team => team.Members.Contains(user)))
                {
                    Console.WriteLine("Member {0} cannot join team {1}!", user, teamToJoin);

                    foreach (var team in AllTeams2.Where(t => t.Name.Equals(teamToJoin)))
                    {
                        TeamsToDisband.Add(team);
                    }
                    
                }
                else
                    foreach (var team in AllTeams2)
                    {
                        if (team.Name.Equals(teamToJoin))  // we add the members of the team
                            team.Members.Add(user);
                    }




                userJoinsTeam = Console.ReadLine();

            }


            //print result
            PrintTeamsAndTeadsToDisband(AllTeams2, TeamsToDisband);

        }

            


        private static void FormTeams(int countOfTeams, List<Teams> AllTeams)
        {
            for (int i = 0; i < countOfTeams; i++)
            {
                List<string> members = new List<string>();
                string[] creatorTeam = Console.ReadLine().Split('-').ToArray();
                string name = creatorTeam[1];
                string creatorName = creatorTeam[0];

                members.Add(creatorName);

                Teams Team = new Teams()
                {
                    Name = name,
                    CreatorName = creatorName,
                    Members = members

                };
                if (AllTeams.Any(team => team.Name.Equals(name)))
                    Console.WriteLine("Team {0} was already created!", name);
                else if (AllTeams.Any(team => team.CreatorName.Equals(creatorName)))
                    Console.WriteLine("{0} cannot create another team!", creatorName);
                else
                {
                    Console.WriteLine("Team {0} has been created by {1}!", name, creatorName);
                    AllTeams.Add(Team);
                }
            }
        }

        private static void PrintTeamsAndTeadsToDisband(List<Teams> AllTeams2, List<Teams> TeamsToDisband)
        {
            foreach (var team in AllTeams2
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name))
            {

                if (!TeamsToDisband.Contains(team))               // ako ne e ot teams to disband
                {
                    Console.WriteLine(team.Name);
                    Console.WriteLine("- {0}", team.CreatorName);
                    foreach (var member in team.Members.OrderBy(m => m))
                    {
                        if (!member.Equals(team.CreatorName))
                            Console.WriteLine("-- {0}", member);
                    }
                    
                }     
                
            }



           
                Console.WriteLine("Teams to disband:");

            foreach (var teamToDis in TeamsToDisband.OrderBy(n => n))
            {   
                Console.WriteLine(teamToDis.Name);
            }

        }
        
    }
}
