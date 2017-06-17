using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('|')
                .ToList();

            Dictionary<string, Dictionary<string, long>> countryCityPolulation = new Dictionary<string, Dictionary<string, long>>();

            Dictionary<string, long> cityPolulation = new Dictionary<string, long>();

            Dictionary<string, long> countryTotalPopulation = new Dictionary<string, long>();


            SetCountryCityAndPopulation(input,countryCityPolulation, cityPolulation);
          
            SetCountryPopulation(countryCityPolulation, countryTotalPopulation);

            OrderAndPrint(countryTotalPopulation, countryCityPolulation);
            
        }

        private static void SetCountryCityAndPopulation(List<string> input
            ,Dictionary<string, Dictionary<string, long>> countryCityPolulation
            , Dictionary<string, long> cityPolulation)
        {
            while (input[0] != "report")
            {
                string country = input[1];
                string city = input[0];
                int population = int.Parse(input[2]);

                if (!countryCityPolulation.ContainsKey(country))
                    cityPolulation = new Dictionary<string, long>();
                else
                    cityPolulation = countryCityPolulation[country];

                cityPolulation[city] = population;

                countryCityPolulation[country] = cityPolulation;

                input = Console.ReadLine()
                .Split('|')
                .ToList();
            }

        }

        private static void OrderAndPrint(Dictionary<string, long> countryTotalPopulation, Dictionary<string, Dictionary<string, long>> countryCityPolulation)
        {
            var result = countryTotalPopulation.OrderByDescending(a => a.Value)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

            foreach (var country in result)
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");
                foreach (var city in countryCityPolulation[country.Key].OrderByDescending(a => a.Value)
            .ToDictionary(pair => pair.Key, pair => pair.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }

        private static void SetCountryPopulation(Dictionary<string, Dictionary<string, long>> countryCityPolulation, Dictionary<string, long> countryTotalPopulation)
        {
            foreach (var country in countryCityPolulation)
            {
                string countryName = country.Key;
                long sumOfPopulation = country.Value.Values.Sum();

                countryTotalPopulation[countryName] = sumOfPopulation;
            }
        }
    }
}
