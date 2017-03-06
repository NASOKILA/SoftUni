using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            string[] Phases = {"Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product."};

            string[] Events = {"Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome."
                , "Try it yourself, I am very satisfied.", "I feel great!"};

            string[] Authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};

            string[] Cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            int n = int.Parse(Console.ReadLine());


            Random obj = new Random();

            for (int i = 0; i < n; i++)
            {
                var phaseIndex = obj.Next(0, Phases.Length);
                var eventsIndex = obj.Next(0, Events.Length);
                var authorIndex = obj.Next(0, Authors.Length);
                var cityIndex =  obj.Next(0, Cities.Length);

                Console.WriteLine($"{Phases[phaseIndex]}{Events[eventsIndex]}{Authors[authorIndex]} - {Cities[cityIndex]}");
            }

            

            



        }
    }
}
