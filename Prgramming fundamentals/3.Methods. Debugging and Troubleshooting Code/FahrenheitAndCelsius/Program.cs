using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrenheitAndCelsius
{
    class Program
    {
        static double FahrenheitToCelsius(double degreesF) {
            double celsius = (degreesF - 32) * 5 / 9;
            return celsius;
        }

        static double CelsiusToFahrenheit(double degreesC)
        {
            double fahrenheit = degreesC * 9 / 5 - 32;
            return fahrenheit;
        }

        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
        }
    }
}
