using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            
            string model = string.Empty; 

            string biggestKeg = string.Empty;
            double prevVolume = 0;

            for (int i = 0; i < n; i++)
            {
              
                model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                long height = long.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (volume > prevVolume)
                {
                    biggestKeg = model;
                }
                prevVolume = volume;
            }

            Console.WriteLine($"{biggestKeg}");
        }
    }
}
