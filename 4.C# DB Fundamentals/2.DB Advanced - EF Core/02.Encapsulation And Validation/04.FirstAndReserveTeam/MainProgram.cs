using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MainProgram
{
    static void Main(string[] args)
    {
        //create both teams
        Team team  = new Team("Team");
        
        //create the people
        var lines = int.Parse(Console.ReadLine());
        var persons = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            var person = new Person(cmdArgs[0],
                                    cmdArgs[1],
                                    int.Parse(cmdArgs[2]),
                                    double.Parse(cmdArgs[3]));

            persons.Add(person);
        }

        foreach (var player in persons)
        {
                team.AddPlayer(player);  
        }

        Console.WriteLine($"First team have {team.FirstTeam.Count} players");
        Console.WriteLine($"Reserve team have {team.ReserveTeam.Count} players");

    }
}

