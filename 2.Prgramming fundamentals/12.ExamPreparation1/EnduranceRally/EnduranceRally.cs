using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduranceRally
{
    class EnduranceRally
    {
        static void Main(string[] args)
        {

            string[] partecipants = Console.ReadLine()
                .Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToArray();

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

                foreach (double track in trackLayout)
                {
                    
                    if (checkPoints.Any( z => z == Array.IndexOf(trackLayout, track)))
                        fuel += track;
                    else
                        fuel -= track;

                    if (fuel <= 0)
                    {
                        reachedZero = true;
                        Console.WriteLine($"{partecipant} - reached {Array.IndexOf(trackLayout, track)}");
                        break;
                    }
                }

                if(!reachedZero)
                Console.WriteLine($"{partecipant} - fuel left {fuel:f2}");

            }
        }
    }
}
