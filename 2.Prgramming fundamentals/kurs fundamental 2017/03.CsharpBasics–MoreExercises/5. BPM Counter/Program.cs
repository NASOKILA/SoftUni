using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BPM_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int beatsPerMinute = int.Parse(Console.ReadLine());
            int numberOfBeats = int.Parse(Console.ReadLine());

            Console.Write($"{Math.Round(numberOfBeats / 4.0, 1)} bars ");

            double seconds = numberOfBeats * 60.0 / beatsPerMinute; 
            int minutes = (int)seconds / 60;
            seconds = seconds - minutes * 60;
          
            Console.WriteLine($"- {minutes}m {Math.Floor(seconds)}s");
      
        }
    }
}
