using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main(string[] args)
    {


        List<Team> teams = new List<Team>();

        string command = Console.ReadLine();
        
        while (command != "END")
        {
            string[] input = command
                    .Split(';')
                    .ToArray();

            if (input[0] == "Team")
            {
                try
                {
                    Team team = new Team(input[1]);
                    teams.Add(team);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
        }
            else if (input[0] == "Add")
            {
                try
                {
                    Team team = teams.Where(t => t.Name == input[1]).FirstOrDefault();

                    if(team == null)
                    {
                        throw new ArgumentException($"Team {input[1]} does not exist.");
                    }

                    Stats stats = new Stats(int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]));
                    Player player = new Player(input[2], stats);
                    team.AddPlayer(player);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input[0] == "Remove")
            {
                try
                {
                    Team team = teams.Where(t => t.Name == input[1]).FirstOrDefault();

                    Player pl = team.players.Where(pp => pp.Name == input[1]).FirstOrDefault();

                    if (pl == null)
                    {
                        throw new ArgumentException($"Player {input[2]} is not in {input[1]} team.");
                    }

                    team.RemovePlayer(team.players.Where(p => p.Name == input[2]).FirstOrDefault());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input[0] == "Rating")
            {
                try
                {
                    Team team = teams.Where(t => t.Name == input[1]).FirstOrDefault();
                    Console.WriteLine(team);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            command = Console.ReadLine();
        }


    }
}

