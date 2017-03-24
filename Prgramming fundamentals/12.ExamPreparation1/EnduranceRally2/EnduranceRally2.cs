using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally2
{
    class EnduranceRally2
    {
        static void Main(string[] args)
        {

            string[] partecipants = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            double[] trackLayout = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            int[] checkPoints = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            foreach (var partecipant in partecipants)
            {
                bool reachedZero = false;
                double fuel = partecipant.First();

                for (int i = 0; i < trackLayout.Length; i++)
                {

                    var currentZoneFuel = trackLayout[i];

                    if (checkPoints.Contains(i))
                        fuel += currentZoneFuel;
                    else
                        fuel -= currentZoneFuel;

                    if (fuel <= 0)
                    {
                        reachedZero = true;
                        Console.WriteLine($"{partecipant} - reached {i}");
                        break;
                    }
                }
            
                if (!reachedZero)
                    Console.WriteLine($"{partecipant} - fuel left {fuel:f2}");

            }
        }
    }
}
