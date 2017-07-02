using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();

             while (input != "END")
            {
                Dictionary<string, string> keysAndValues = new Dictionary<string, string>();

                string[] pairs = input
                .Split(new char[] { '&', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

                foreach (var kvp in pairs)
                {
                    string[] keysValues = kvp
                        .Split(new string[] {"=","+","%20" },StringSplitOptions.RemoveEmptyEntries)
                        .Select(a => a.Trim())
                        .ToArray();

                    if (keysValues.Length > 1)
                    {
                        string key = keysValues[0];
                        string value = keysValues[1];

                        if (keysValues.Length > 2)
                        {
                            string joinValues = "";
                            for (int i = 1; i < keysValues.Length; i++)
                            {
                                joinValues += keysValues[i] + " ";
                            }
                            value = joinValues.Remove(joinValues.Length-1 , 1);
                        }

                        if (!keysAndValues.ContainsKey(key))
                            keysAndValues[key] = value;
                        else
                        {
                            string newValue = keysAndValues[key] + ", " + value;
                            keysAndValues[key] = newValue;
                        }
                    }
                }

                PrintPairs(keysAndValues);
                input = Console.ReadLine().Trim();
            } 


        }

        private static void PrintPairs(Dictionary<string, string> keysAndValues)
        {
            foreach (var pair in keysAndValues)
            {
                string key = pair.Key;
                string value = pair.Value;
                Console.Write($"{key}=[{value}]");
            }
            Console.WriteLine();
        }
    }
}
