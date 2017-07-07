using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.RoliTheCoder
{
    class RoliTheCoder
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            Dictionary<int, string> idsAndEvents = new Dictionary<int, string>();
            Dictionary<string, List<string>> eventsAndParticipants = new Dictionary<string, List<string>>();
            Dictionary<string, int> eventsAndCountOfPartecipants = new Dictionary<string, int>();

            while (input[0] != "Time")
            {
                int id = int.Parse(input[0]);
                string @event = input[1];
                if (@event.First() == '#')
                {
                    List<string> partecipants = new List<string>();
                    for (int i = 2; i < input.Length; i++)
                    {
                        if(input[i].First() == '@')
                            partecipants.Add(input[i]);
                    }
                        

                    if (!idsAndEvents.ContainsKey(id))
                    {
                       idsAndEvents[id] = @event;
                       eventsAndParticipants[@event] = partecipants;
                    }
                    else
                    {
                        // the id exists

                        if (idsAndEvents.ContainsValue(@event))
                        {// if the event is the same

                            List<string> otherPartecipants = eventsAndParticipants[@event];
                            foreach (var partecipant in partecipants)
                            {
                                if (!otherPartecipants.Contains(partecipant))
                                    otherPartecipants.Add(partecipant);
                            }

                            eventsAndParticipants[@event] = otherPartecipants;
                        }
                       

                    }

                }

                input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();
            }


            PrintResult(idsAndEvents, eventsAndParticipants, eventsAndCountOfPartecipants);


        }

        private static void PrintResult(Dictionary<int, string> idsAndEvents, Dictionary<string, List<string>> eventsAndParticipants, Dictionary<string, int> eventsAndCountOfPartecipants)
        {
            eventsAndParticipants = eventsAndParticipants
                .OrderByDescending(a => a.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(b => b.Key, c => c.Value);

            foreach (var eventAndParticipants in eventsAndParticipants)
            {
                string @event = eventAndParticipants.Key.Substring(1);
                List<string> partecipants = eventAndParticipants.Value;
                int partecipantsCount = partecipants.Count;

                Console.WriteLine($"{@event} - {partecipantsCount}");
                foreach (var partecipant in partecipants.OrderBy(a => a))
                {
                    Console.WriteLine(partecipant);
                }
            }

        }
    }
}
