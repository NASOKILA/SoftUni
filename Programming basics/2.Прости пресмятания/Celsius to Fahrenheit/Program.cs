using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {

            // Formula : (n *1.8)+32

            Console.Write("Celsius = ");
            var celsiusDegrees = double.Parse(Console.ReadLine());
            var fahrenheitDegrees = (celsiusDegrees * 1.8) + 32;
            Console.WriteLine("In Fahrenheit = " + Math.Round(fahrenheitDegrees, 2));
        }
    }
}
