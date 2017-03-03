using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class UserLogs
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, long>> populations = new Dictionary<string, Dictionary<string, long>>();

        string input = Console.ReadLine();
        while (!input.Equals( "report"))
        {
            List<string> data = input.Split('|').ToList(); 
            string city = data[0];     
            string country = data[1];
            long population = long.Parse(data[2]);

            Dictionary<string, long> cityPopulation = new Dictionary<string, long>();   // suzdavame nov po maluk rechnik koito shte slagame v glavnata vseki cikul
        


            if (!populations.ContainsKey(country))  // ako durjavata ne sushtestvuva
            {

                cityPopulation[city] = population; // v malkiq rechnik dobavqma gradut i horata

                populations[country] = cityPopulation; //v golqmiq rechnik v klucha durjava, slagama po malkata i taka stavat dve direktorii v edno


            }
            else     // ako durjavata veche sushtestvuva
            {

                cityPopulation = populations[country]; // v malkiq rechnik si slagame si starite stoinosti grad i hora

                if (cityPopulation.ContainsKey(city))  // ako sudurja gradut 
                    cityPopulation[city] += population;        // samo uvelichavame horata v malkiq rechnik
                else                                      // ako ne
                    cityPopulation.Add(city, population);// dobavqme gradut


                populations[country] = cityPopulation;   // dobavqma malkiq rechnik kum golqmiq
            }

            input = Console.ReadLine();
        }

        foreach (var state in populations.OrderByDescending(x => x.Value.Sum(y => y.Value))) // podrejdame gi po goleminata na obshtata populaciq
        {
            List<long> cities = state.Value.Select(x => x.Value).ToList();
            long totalPolulation = cities.Sum();
            Console.WriteLine($"{state.Key} (total population: {totalPolulation})");

            Console.Write($"=>{string.Join("=>", state.Value.OrderByDescending(x => x.Value).Select(x => $"{x.Key}: {x.Value}\r\n"))}");
        }
    }
}






/*using System;
using System.Collections.Generic;
using System.Linq;


namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<string, List<string>> CountryCity = new SortedDictionary<string, List<string>>();
            Dictionary<string, long> CityPeople = new Dictionary<string, long>();
            Dictionary<string, long> OrderedCityPeople = new Dictionary<string, long>();
            Dictionary<string, long> countryTotalPopulation= new Dictionary<string, long>();
           

            while (!input.Equals("report"))
            {

                string[] info = input.Split('|').ToArray();


                string city = info[0];
                string country = info[1];
                long population = long.Parse(info[2]);

                if (!CountryCity.ContainsKey(country))
                {
                    CountryCity[country] = new List<string>();
                    CountryCity[country].Add(city);
                    CityPeople[city] = population;
                }
                else
                {
                    CountryCity[country].Add(city);
                    CityPeople[city] = population;
                }

                input = Console.ReadLine();
            }
            
            

            GetTotalPopulation(CountryCity, CityPeople, countryTotalPopulation );
            PrintResult(CountryCity, CityPeople, OrderedCityPeople, countryTotalPopulation );
        }




        private static void PrintResult(SortedDictionary<string, List<string>> countryCity, Dictionary<string, long> CityPeople,
            Dictionary<string, long> OrderedCityPeople, Dictionary<string, long> countryTotalPopulation)
        {
            
                
            foreach (var country in countryTotalPopulation.OrderByDescending(a => a.Value)) //podrejdame durjavite po stoinost , t.e. populaciq 
            {
                Console.WriteLine("{0} (total population: {1})",country.Key, country.Value); // printirame durjavata i obshtata populaciq

                foreach (var countries in countryCity.Keys) // obhojdame vsichki durjavi za da polzvame stoinostite im t.e. gradovete
                {

                    if (country.Key.Equals(countries)) // ako ima takava durjava v countryCity
                    {
                        foreach (var cities in  countryCity[country.Key]) //  Obhojdame gradovete 
                        {
                            // npulnim noviq spisuk 
                                OrderedCityPeople[cities] = CityPeople[cities];
                        }
                            
                            foreach (var city in OrderedCityPeople.OrderByDescending(a => a.Value)) // obhojdame go podreden po stoinosti
                            {
                                Console.WriteLine("=>{0}: {1}", city.Key, city.Value);
                            }
                       
                        OrderedCityPeople = new Dictionary<string, long>(); // izprazvame spisuka kato suzdavame nova instanciq 
                    }                     
                }
           }
      }


        

        private static void GetTotalPopulation(SortedDictionary<string, List<string>> countryCity, Dictionary<string, long> CityPeople,
            Dictionary<string, long> countryTotalPopulation)
    {

        countryCity.Select(a => a.Key.Reverse());
        foreach (var country in countryCity)
        {
                long totalPopulation = 0;
                int counter = 0;


            foreach (var city in CityPeople.Keys)
            {
                if (city.Equals(country.Value[counter]))
                {
                    totalPopulation += CityPeople[city];
                }

                counter++;
                if (counter == country.Value.Count) { counter = 0; }
            }

            countryTotalPopulation[country.Key] = totalPopulation;

        }

    }
        
    }
}
*/
