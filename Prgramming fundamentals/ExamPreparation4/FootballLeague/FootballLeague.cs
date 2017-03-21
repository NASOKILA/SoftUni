using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> TeamScore = new Dictionary<string, int>();
            Dictionary<string, int> Classification = new Dictionary<string, int>();
            string key = Console.ReadLine();

            string lines = Console.ReadLine();
            while (!lines.Equals("final"))
            {
                string[] linesArr = lines.Split().ToArray();

                string[] score = linesArr[2].Split(':');
                int firstTeamScore = int.Parse(score[0]);
                int secondTeamScore = int.Parse(score[1]);



                int firstIndex = linesArr[0].IndexOf(key) + key.Length;
                int lastindex = linesArr[0].LastIndexOf(key) - firstIndex;
                linesArr[0] = linesArr[0].Substring(firstIndex, lastindex);

                char[] teamNameChr = linesArr[0].ToUpper().ToCharArray();
                Array.Reverse(teamNameChr);
                linesArr[0] = new string(teamNameChr);

                

                int firstIndex2 = linesArr[1].IndexOf(key) + key.Length;
                int lastindex2 = linesArr[1].LastIndexOf(key) - firstIndex2;
                linesArr[1] = linesArr[1].Substring(firstIndex2, lastindex2);

                char[] teamNameChr2 = linesArr[1].ToUpper().ToCharArray();
                Array.Reverse(teamNameChr2);
                linesArr[1] = new string(teamNameChr2);



                string firstTeam = linesArr[0];
                string secondTeam = linesArr[1];


                if (!TeamScore.Keys.Contains(firstTeam))
                {
                    TeamScore[firstTeam] = firstTeamScore;
                }
                else
                    TeamScore[firstTeam] += firstTeamScore;


                if (!TeamScore.Keys.Contains(secondTeam))
                {
                    TeamScore[secondTeam] = secondTeamScore;
                }
                else
                    TeamScore[secondTeam] += secondTeamScore;


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
                else if (firstTeamScore == secondTeamScore)
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

                lines = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            byte counter3 = 1;
            foreach (var team in Classification
                .OrderByDescending(c => c.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{counter3}. {team.Key} {team.Value}");
                counter3++;
            }

            Console.WriteLine("Top 3 scored goals:");
            byte counter2 = 0;
            foreach (var team in TeamScore
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {

                Console.WriteLine($"- {team.Key} -> {team.Value}");
                counter2++;
                if (counter2 == 3)
                    break;
            }
        }
    }
}
