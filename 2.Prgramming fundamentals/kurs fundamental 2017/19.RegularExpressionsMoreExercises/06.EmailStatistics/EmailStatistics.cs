using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.EmailStatistics
{
   

    class EmailStatistics
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> domainsAndUsernames = new Dictionary<string, List<string>>();

            SetDomainsAndUsernames(domainsAndUsernames, n);      

            PrintResult(domainsAndUsernames);

        }

        private static void SetDomainsAndUsernames(Dictionary<string, List<string>> domainsAndUsernames, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string email = Console.ReadLine();
                List<string> usernames = new List<string>();

                string pattern = @"\b(?<username>[a-zA-Z]{5,})@(?<Domain>(?<mailServer>[a-z]{3,})(?<topLevelDomain>\.com|\.bg|\.org))\b";

                Regex regex = new Regex(pattern);

                Match match = regex.Match(email);

                if (!match.Success)
                    continue;

                string domain = match.Groups["Domain"].ToString();
                string username = match.Groups["username"].ToString();



                if (!domainsAndUsernames.ContainsKey(domain))
                {
                    usernames.Add(username);
                    domainsAndUsernames[domain] = usernames;
                }
                else
                {
                    usernames = domainsAndUsernames[domain];
                    if (!domainsAndUsernames[domain].Contains(username)) // ako ne sudurja username go dobavi
                        usernames.Add(username); // ako ne go ignorirame

                }
            }
        }

        private static void PrintResult(Dictionary<string, List<string>> domainsAndUsernames)
        {
            domainsAndUsernames = domainsAndUsernames.OrderByDescending(a => a.Value.Count).ToDictionary(c => c.Key, v => v.Value);

            foreach (var domainAndUsername in domainsAndUsernames)
            {
                string domainName = domainAndUsername.Key;
                List<string> listOfUsernames = domainAndUsername.Value;
                Console.WriteLine($"{domainName}:");
                foreach (var username in listOfUsernames)
                    Console.WriteLine($"### {username}");
            }
        }
    }
}
