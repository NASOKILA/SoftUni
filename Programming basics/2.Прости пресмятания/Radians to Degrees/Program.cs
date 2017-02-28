using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            // formula : (radians * 180) /PI
            Console.Write("Input radians : ");
            var rad = double.Parse(Console.ReadLine());
            var radInDegrees = (rad * 180) / Math.PI;
            Console.WriteLine("In degrees = " + Math.Round(radInDegrees, 1));

            
        }
    }
}
