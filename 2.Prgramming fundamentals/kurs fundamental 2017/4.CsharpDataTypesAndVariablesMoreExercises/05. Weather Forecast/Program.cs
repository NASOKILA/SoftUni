using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            try
            {
                long predictionNumber = long.Parse(input);

                string weather = string.Empty;

                if (predictionNumber >= sbyte.MinValue && predictionNumber <= sbyte.MaxValue)
                    weather = "Sunny";
                else if (predictionNumber >= int.MinValue && predictionNumber <= int.MaxValue)
                    weather = "Cloudy";
                else if (predictionNumber >= long.MinValue && predictionNumber <= long.MaxValue)
                    weather = "Windy";


                Console.WriteLine(weather);
            }
            catch
            {
                Console.WriteLine("Rainy");
            }

        }
    }
}
