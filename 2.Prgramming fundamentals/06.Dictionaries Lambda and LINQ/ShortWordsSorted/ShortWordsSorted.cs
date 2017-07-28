using System;
using System.Collections.Generic;
using System.Linq;


namespace ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            char[] separators = { ' ','.', ',', ';', ':', '(', ')', '[', ']', '"', '/', '\\', '!', '?' };

            string[] text = Console.ReadLine()
                .ToLower()          
                .Split(separators)           
                .ToArray();// VZIMAME TEZI KOITO NE SA PRAZNI ZA DA IZBEGNEM MALKI PARAZITNI SINVOLCHETA!

                text = text
                .Where(f => f.Length < 5) // vzimame samo tezi koito sa s duljina < 5
                .OrderBy(x => x)
                .Distinct()
                .ToArray();
               

            Console.WriteLine(string.Join(" ",text));
            
            }
    }
}
