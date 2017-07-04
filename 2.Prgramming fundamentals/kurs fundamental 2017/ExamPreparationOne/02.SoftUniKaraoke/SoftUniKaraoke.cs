using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            string[] listOfPartecipants = Console.ReadLine()
                .Split(new char[] {',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            List<string> songs = Console.ReadLine()
                .Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToList();

            string[] command = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            Dictionary<string, List<string>> namesAndAwardLists = new Dictionary<string, List<string>>();
            Dictionary<string, int> namesAndAwardCounts = new Dictionary<string, int>();
           

            

            while (command[0] != "dawn")
            {
                List<string> awardList = new List<string>();
                int awardCount = 0;

                if (command.Length > 1)
                {
                    string participant = command[0];
                    string song = command[1];

                    if (command.Length > 2)
                    {
                        string award = command[2];




                        if (listOfPartecipants.Contains(participant) && songs.Contains(song))
                        {
                            if (!namesAndAwardLists.ContainsKey(participant))
                            {
                                awardList.Add(award);
                                awardCount++; 
                            }
                            else
                            {
                                awardCount = namesAndAwardCounts[participant];
                                awardList = namesAndAwardLists[participant];
                                if (!awardList.Contains(award))
                                {
                                    awardCount++;
                                    awardList.Add(award);
                                }
                            }

                            namesAndAwardLists[participant] = awardList;
                            namesAndAwardCounts[participant] = awardCount;

                        }



                    }
                }

                command = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();
            }


            PrintResult(namesAndAwardLists, namesAndAwardCounts);
        }

        private static void PrintResult(Dictionary<string, List<string>> namesAndAwardLists, Dictionary<string, int> namesAndAwardCounts)
        {
            namesAndAwardCounts = namesAndAwardCounts.OrderByDescending(a => a.Value).ThenBy(b => b.Key).ToDictionary(c => c.Key, v => v.Value);

            if (namesAndAwardCounts.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            foreach (var kvp in namesAndAwardCounts)
            {
                string name = kvp.Key;
                int awardCount = kvp.Value;
                Console.WriteLine($"{name}: {awardCount} awards");
   
                foreach (var award in namesAndAwardLists[name].OrderBy(a => a))
                    Console.WriteLine($"--{award}");

            }
        }
    }
}
