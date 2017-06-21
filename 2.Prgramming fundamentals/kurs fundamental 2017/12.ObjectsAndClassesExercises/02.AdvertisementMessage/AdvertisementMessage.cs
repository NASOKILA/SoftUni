using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string[] phases = {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };

            string[] events = {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors = {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva" };

            string[] cities = {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse" };


            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{phases[rnd.Next(0, phases.Length-1)]} {events[rnd.Next(0, events.Length-1)]} {authors[rnd.Next(0, authors.Length-1)]} {cities[rnd.Next(0, cities.Length-1)]}");
            }


        }
    }
}
