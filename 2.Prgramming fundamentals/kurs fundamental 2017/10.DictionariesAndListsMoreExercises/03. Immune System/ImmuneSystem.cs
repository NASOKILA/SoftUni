using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Immune_System
{
    class ImmuneSystem
    {
        static void Main(string[] args)
        {

            int initialHealth = int.Parse(Console.ReadLine());
            int initialHealthCopy = initialHealth;
            bool isItDefeated = false;

            string virusName = Console.ReadLine();
            List<string> pastViruses = new List<string>();

            while (virusName != "end")
            {

                //We have to get virus strength
                double virusStrength = 0.00;
                foreach (var ch in virusName)
                    virusStrength += ch;


                virusStrength = Math.Floor(virusStrength / 3.0);


                //We have to get virus time
                double timeInSeconds = 0.0;

                if (pastViruses.Contains(virusName))
                    timeInSeconds = Math.Floor((virusStrength * virusName.Length) / 3); // ako veche sme go imali tozi virus vremeto se deli na 3
                else
                { // ako ne go sudurja go dobavqme i opravqme vremeto da e po dulgo
                    timeInSeconds = virusStrength * virusName.Length;
                    pastViruses.Add(virusName);
                }

                Console.WriteLine($"Virus {virusName}: {virusStrength} => {timeInSeconds} seconds");
                TimeSpan timeinMinutes = TimeSpan.FromSeconds(timeInSeconds);
                // MOJE DA SE NAPRAVI I SUS (timeInSeconds / 60) za minutite i (timeInSeconds % 60) za sekundite


                if (initialHealth > timeInSeconds)
                {
                    Console.WriteLine($"{virusName} defeated in {Math.Floor(timeinMinutes.TotalMinutes)}m {timeinMinutes.Seconds}s.");
                    initialHealth -= (int)timeInSeconds;
                    Console.WriteLine($"Remaining health: {initialHealth}");
                    initialHealth = initialHealth + (initialHealth / 5);
                    if (initialHealth > initialHealthCopy)
                        initialHealth = initialHealthCopy;
                }
                else
                {
                    isItDefeated = true;
                    Console.WriteLine("Immune System Defeated.");
                    break;
                }
                
                virusName = Console.ReadLine();
            }

            if(!isItDefeated)
            Console.WriteLine($"Final Health: {initialHealth}");
        }
    }
}
