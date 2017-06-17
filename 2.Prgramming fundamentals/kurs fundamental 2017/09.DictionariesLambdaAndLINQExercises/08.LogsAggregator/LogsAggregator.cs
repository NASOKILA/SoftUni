using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> namesIpsDurations = new SortedDictionary<string, SortedDictionary<string, int>>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                List<string> input = Console.ReadLine()
                    .Split(' ')
                    .ToList();

                string name = input[1];
                string ip = input[0];
                int duration = int.Parse(input[2]);

                if (!namesIpsDurations.ContainsKey(name))
                    namesIpsDurations[name] = new SortedDictionary<string, int>();

                    if (!namesIpsDurations[name].ContainsKey(ip))
                        namesIpsDurations[name][ip] = 0;   
                    //setnahme na tova ime nov rechnik sus ip-to i duration  = na 0
               
                namesIpsDurations[name][ip] += duration; 
                // dobavihme vuv imeto nov rechnik sus ip-to i do nego duration !!!
            }

            foreach (var userIpDuration in namesIpsDurations)
            {
                string user = userIpDuration.Key;
               
                int sum = namesIpsDurations[user].Values.Sum();

                Console.WriteLine($"{user}: {sum} [{string.Join(", ", userIpDuration.Value.Keys)}]");
            }
        }
    }
}
