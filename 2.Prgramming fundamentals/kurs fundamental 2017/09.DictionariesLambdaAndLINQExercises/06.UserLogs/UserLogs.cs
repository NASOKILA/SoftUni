using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(new char[] {' ', '=', '\''}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
           
            SortedDictionary<string, Dictionary<string, int>> nameIpAndMessageCount =
                new SortedDictionary<string, Dictionary<string, int>>();

            Dictionary<string, int> ipAndMessageCount = new Dictionary<string, int>();

            SetIdAndMessagesCount(ipAndMessageCount, nameIpAndMessageCount, input);

            foreach (var usernameIpAndMessageCount in nameIpAndMessageCount)
            {
                string user = usernameIpAndMessageCount.Key;
                Console.WriteLine($"{user}:");
                List<string> result = new List<string>();
                foreach (var item in nameIpAndMessageCount[user])
                {
                    result.Add(item.Key + " => " + item.Value.ToString());
                } 
                Console.WriteLine(string.Join(", ", result) + ".");
            }


        }

        private static void SetIdAndMessagesCount(Dictionary<string, int> ipAndMessageCount, SortedDictionary<string, Dictionary<string, int>> nameIpAndMessageCount, List<string> input)
        {
            while (input[0] != "end")
            {
                string ip = input[1];
                string message = input[3];
                string user = input.Last();

                if (!nameIpAndMessageCount.ContainsKey(user))
                    ipAndMessageCount = new Dictionary<string, int>();
                else
                {
                    ipAndMessageCount = nameIpAndMessageCount[user];
                }

                if (!ipAndMessageCount.Keys.Contains(ip))
                    ipAndMessageCount[ip] = 1;
                else
                    ipAndMessageCount[ip]++;

                nameIpAndMessageCount[user] = ipAndMessageCount;



                input = Console.ReadLine()
                .Split(new char[] { ' ', '=', '\'' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }
        }


    }
}
