using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {
        

         
            DateTime startTime = DateTime.ParseExact(
                Console.ReadLine(),
                "HH:mm:ss",
                CultureInfo.InvariantCulture);

            int numberOfSteps = int.Parse(Console.ReadLine());
            int secondsPerStep = int.Parse(Console.ReadLine());
            long initialSeconds = startTime.Hour*60*60
                +startTime.Minute*60 + startTime.Second;


            ulong secondsToAdd = (ulong)numberOfSteps * (ulong)secondsPerStep;
            ulong totalSeconds = (ulong)initialSeconds + secondsToAdd;
            var seconds = totalSeconds % 60;
            var totalMinutes = totalSeconds / 60;
            var minutes = totalMinutes % 60;
            var totalHours = totalMinutes / 60;
            var hours = totalHours % 24;


            Console.WriteLine($"Time Arrival: {hours:00}:{minutes:00}:{seconds:00}");

            // STAVA I S TIMESPAN:

            /*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class SinoTheWalker
    {
        static void Main(string[] args)
        {
            int[] timeSinoLaves = Console.ReadLine().Split(':').Select(int.Parse).ToArray();
            int numberOfSteps = int.Parse(Console.ReadLine());
            int secondsForEachStep = int.Parse(Console.ReadLine());

            int hours = timeSinoLaves[0];
            int minutes = timeSinoLaves[1];
            int seconds = timeSinoLaves[2];

            int totlSecondsSinoWlks = secondsForEachStep * numberOfSteps;

            TimeSpan sinoLeavesSoftuni = new TimeSpan(hours,minutes,seconds+totlSecondsSinoWlks);

            string h = sinoLeavesSoftuni.Hours.ToString();
            string m = sinoLeavesSoftuni.Minutes.ToString();
            string s = sinoLeavesSoftuni.Seconds.ToString();

            if (h.Length == 1)
                h = "0" + h;

            if (m.Length == 1)
                m = "0" + m;

            if (s.Length == 1)
                s = "0" + s;




            Console.WriteLine($"Time Arrival: {h}:{m}:{s}");
        }
    }
}*/

        }
    }
}
