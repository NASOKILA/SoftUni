using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Weather
{
    class Weather
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string patt = @"(?<city>[A-Z]{2})(?<temperature>\d+\.\d+)(?<weather>[A-Za-z]+)\|";
            Regex reg = new Regex(patt);

            var citiesAndTemps = new Dictionary<string, double>();
            var citiesAndWeathers = new Dictionary<string, string>();


            while (input != "end")
            {

                var match = reg.Match(input);
                if (match.Success)
                {
                    string nameOfCity = match.Groups["city"].ToString();
                    double averageTemperature = double.Parse(match.Groups["temperature"].ToString());
                    string typeOfWeather = match.Groups["weather"].ToString();

                    citiesAndTemps[nameOfCity] = averageTemperature;
                    citiesAndWeathers[nameOfCity] = typeOfWeather;

                }

                input = Console.ReadLine();
            }


            foreach (var item in citiesAndTemps.OrderBy(v => v.Value))
            {
                string city = item.Key;
                double temperature = item.Value;
                var weather = citiesAndWeathers.Where(k => k.Key == city).Select(d => d.Value).ToArray();
                Console.WriteLine($"{city} => {temperature:F2} => {weather[0]}");
            }


        }
    }
}
