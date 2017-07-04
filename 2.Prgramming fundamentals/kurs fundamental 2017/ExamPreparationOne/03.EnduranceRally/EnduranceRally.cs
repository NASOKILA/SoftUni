using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EnduranceRally
{
    class EnduranceRally
    {
        static void Main(string[] args)
        {

            string[] driversNames = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<double> trackZones = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();


            List<long> checkPointIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            foreach (var driver in driversNames)
            {
                bool reachedZero = false;
                double fuel = driver.First();

                for (int i = 0; i < trackZones.Count; i++)
                {

                    double currentZoneFuel = trackZones[i];

                    if (checkPointIndexes.Contains(i))
                        fuel += currentZoneFuel;
                    else
                        fuel -= currentZoneFuel;

                    if (fuel <= 0)
                    {
                        reachedZero = true;
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }

                if (!reachedZero)
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");


            }

        }
    }
}
