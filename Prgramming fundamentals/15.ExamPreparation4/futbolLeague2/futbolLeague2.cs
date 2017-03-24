using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace futbolLeague2
{
    class futbolLeague2
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> standings = new Dictionary<string, int>();
            Dictionary<string, int> teamGoals = new Dictionary<string, int>();

            string key = Console.ReadLine();
            string line = Console.ReadLine();

            while (!line.Equals("final"))
            {
                string[] lineArgs = line.Split();
                string firstTeamName = GetTeamName(lineArgs[0], key);
                string secondTeamName = GetTeamName(lineArgs[1], key);


                string[] score = lineArgs[2].Split(':');
                int firstTeamScore = int.Parse(score[0]);
                int secondTeamScore = int.Parse(score[1]);

               
                AddScoteToTeam(teamGoals, firstTeamName, firstTeamScore, secondTeamName, secondTeamScore);
                AddPointsToStandins(standings, firstTeamName, firstTeamScore, secondTeamName, secondTeamScore);

               

                line = Console.ReadLine();
            }

            PrintStandings(standings);
            PrintTopThreeTeams(teamGoals);
        }

        private static void PrintTopThreeTeams(Dictionary<string, int> teamGoals)
        {
            int counter = 0;
            Console.WriteLine("Top 3 scored goals:");
            foreach (var pair in teamGoals
                .OrderByDescending(c => c.Value)
                .ThenBy(c => c.Key))
            {
                Console.WriteLine($"- {pair.Key} -> {pair.Value}");
                counter++;
                if (counter == 3)
                    break;
            }
        }

        private static void PrintStandings(Dictionary<string, int> standings)
        {
            Console.WriteLine("League standings:");
            int counter = 1;
            foreach (var pair in standings
                .OrderByDescending(x => x.Value)
                .ThenBy(c => c.Key))
            {
                Console.WriteLine($"{counter}. {pair.Key} {pair.Value}");
                counter++;
            }
        }

        private static void AddPointsToStandins(Dictionary<string, int> Classification, string firstTeam, int firstTeamScore, string secondTeam, int secondTeamScore)
        {
            if (firstTeamScore < secondTeamScore)
            {
                if (!Classification.ContainsKey(firstTeam))
                    Classification[firstTeam] = 0;
                else
                    Classification[firstTeam] += 0;

                if (!Classification.ContainsKey(secondTeam))
                    Classification[secondTeam] = 3;
                else
                    Classification[secondTeam] += 3;
            }
            else if (firstTeamScore > secondTeamScore)
            {
                if (!Classification.ContainsKey(firstTeam))
                    Classification[firstTeam] = 3;
                else
                    Classification[firstTeam] += 3;

                if (!Classification.ContainsKey(secondTeam))
                    Classification[secondTeam] = 0;
                else
                    Classification[secondTeam] += 0;
            }
            else 
            {
                if (!Classification.ContainsKey(firstTeam))
                    Classification[firstTeam] = 1;
                else
                    Classification[firstTeam] += 1;

                if (!Classification.ContainsKey(secondTeam))
                    Classification[secondTeam] = 1;
                else
                    Classification[secondTeam] += 1;
            }
            
        }

        private static void AddScoteToTeam(Dictionary<string, int> TeamScore, string firstTeam, int firstTeamScore, string secondTeam, int secondTeamScore)
        {
            if (!TeamScore.Keys.Contains(firstTeam))
                TeamScore[firstTeam] = firstTeamScore;
            else
                TeamScore[firstTeam] += firstTeamScore;


            if (!TeamScore.Keys.Contains(secondTeam))
                TeamScore[secondTeam] = secondTeamScore;     
            else
                TeamScore[secondTeam] += secondTeamScore;

        }

        private static string GetTeamName(string teamName, string key)
        {
            int firstIndex = teamName.IndexOf(key) + key.Length;
            int lastindex = teamName.LastIndexOf(key) - firstIndex;
            teamName = teamName.Substring(firstIndex, lastindex);



            /*
             SUBSTRING EXAMPLE:
             string input = "OneTwoThree";

             // Get first three characters.
             string sub = input.Substring(0, 3);
             output one
             */




            //MOJE I TAKA DA GO OBURNEM
            //char[] teamNameChr = teamName.ToUpper().ToCharArray();
            //Array.Reverse(teamNameChr);
            //teamName = new string(teamNameChr);


            return string.Join("",teamName.ToCharArray().Reverse()).ToUpper();

        }
    }
}
