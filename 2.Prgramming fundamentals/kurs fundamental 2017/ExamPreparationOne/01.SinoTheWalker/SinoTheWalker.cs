using System;
using System.Globalization;
using System.Linq;

namespace _01.SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {

            int[] time = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            ulong numberOfSteps = ulong.Parse(Console.ReadLine());
            ulong timeForEachStepInSeconds = ulong.Parse(Console.ReadLine());

            ulong timeInSeconds = (ulong)(time[0]*60*60) + (ulong)(time[1]*60) + (ulong)(time[2]);
            ulong secondsToAdd = numberOfSteps * timeForEachStepInSeconds;

            decimal resultInSeconds = timeInSeconds + secondsToAdd;

            ulong hours = (ulong)(resultInSeconds / 60 / 60);
            resultInSeconds = resultInSeconds % 3600;
            ulong minutes = (ulong)(resultInSeconds / 60);
            ulong seconds = (ulong)(resultInSeconds % 60);

            if (hours >= 24)
                hours = hours % 24;
            if (minutes >= 60)
                minutes = minutes % 60;

            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
