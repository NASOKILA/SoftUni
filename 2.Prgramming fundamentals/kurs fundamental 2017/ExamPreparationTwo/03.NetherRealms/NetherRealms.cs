using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
           
            string[] deamons = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            foreach (var deamon in deamons.OrderBy(a => a))
            {
                long health = GetHealth(deamon);
                decimal damage = GetDamage(deamon);

                Console.WriteLine($"{deamon} - {health} health, {damage:f2} damage");
            }
            


        }

        private static decimal GetDamage(string deamon)
        {
            decimal result = 0;

            var matches = Regex.Matches(deamon, @"\-?[\d]+[\.?]\d+|\-?[\d]+")
                .Cast<Match>()
                .Select(a => a.Value)
                .ToArray();

            foreach (var item in matches)
            {
               
                result += decimal.Parse(item);

            }
           // result = 2;
            foreach (var item in deamon)
            {
                if (item == '*')
                    result *= 2;
                else if (item == '/')
                    result /= 2;
            }

            return result;
        }

        private static long GetHealth(string deamon)
        {
            long result = 0;

            var matches = Regex.Matches(deamon, @"[^\d+\-*\/\.]")
                .Cast<Match>()
                .Select(a => a.Value)
                .Select(a => Convert.ToChar(a))
                .ToArray();


            result = matches.Select(a => Convert.ToInt64(a)).Sum();

            return result;
        }
    }
}
