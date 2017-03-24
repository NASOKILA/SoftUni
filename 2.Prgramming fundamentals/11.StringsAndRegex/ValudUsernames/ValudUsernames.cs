using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValudUsernames
{
    class ValudUsernames
    {
        static void Main(string[] args)
        {

            //char[] separator = { ' ','\\','/','(',')'};
            string usernames = Console.ReadLine();

            string pattern = @"\b[a-zA-Z][a-zA-Z0-9_]{2,24}\b";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(usernames);


            Dictionary<int, string> lengthAndUsers = new Dictionary<int, string>();     

            int maxLength = 0;
            int length1 = 0;
            string userPairNames = "";

            for (int i = 1; i < matches.Count; i=i+2)
            {
                
                length1 = matches[i-1].Length + matches[i].Length;
                userPairNames = matches[i-1].ToString() + " " + matches[i].ToString();
              

                lengthAndUsers.Add(length1, userPairNames);

                if (maxLength < length1)
                    maxLength = length1;

                

            }


            foreach (var pair in lengthAndUsers)
            {
                if (pair.Key.Equals(maxLength))
                {
                    string[] names = pair.Value.Split().ToArray();
                    Console.WriteLine(names[0]);
                    Console.WriteLine(names[1]);
                }
            }


        }
    }
}
