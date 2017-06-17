using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, string> namesAndEmails = new Dictionary<string, string>();

            string prevCommand = string.Empty;
            int counter = 1;
            while (command != "stop")
            {

                if (counter % 2 == 1)
                    namesAndEmails[command] = "";
                else
                    namesAndEmails[prevCommand] = command;

                prevCommand = command;
                counter++;
                command = Console.ReadLine();

            }

            foreach (var nameEmail in namesAndEmails.Where(kvp => !kvp.Value.EndsWith("us") || !kvp.Value.EndsWith("us"))
                .ToDictionary(k => k.Key, v => v.Value ))
            {
                var name = nameEmail.Key;
                var email = nameEmail.Value;

                Console.WriteLine($"{name} -> {email}");
            }

        }
    }
}
