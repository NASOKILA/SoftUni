using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tourist_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string imperialUnit = Console.ReadLine();
            double valueToConvert = double.Parse(Console.ReadLine());
            string convertedUnit = string.Empty;
            double result = 0;

            switch(imperialUnit)
            {
                case "miles":
                    result = valueToConvert * 1.6;
                    convertedUnit = "kilometers";
                    break;
                case "inches":
                    result = valueToConvert * 2.54;
                    convertedUnit = "centimeters";
                    break;
                case "feet":
                    result = valueToConvert * 30;
                    convertedUnit = "centimeters";
                    break;
                case "yards":
                    result = valueToConvert * 0.91;
                    convertedUnit = "meters";
                    break;
                case "gallons":
                    result = valueToConvert * 3.8;
                    convertedUnit = "liters";
                    break;
            }


            Console.WriteLine($"{valueToConvert} {imperialUnit} = {result:f2} {convertedUnit}");
        }
    }
}
