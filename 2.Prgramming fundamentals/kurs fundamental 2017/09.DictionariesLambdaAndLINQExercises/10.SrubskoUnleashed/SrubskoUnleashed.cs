using System;
using System.Collections.Generic;
using System.Linq;


namespace _10.SrubskoUnleashed
{
    class SrubskoUnleashed
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, long>> arenaSingersAndTotalPrices = new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, long> singersAndTotalPrices = new Dictionary<string, long>();

            SetVenueSingersAndTotalPrice(input, arenaSingersAndTotalPrices, singersAndTotalPrices);

            PrintResult(arenaSingersAndTotalPrices);
           

        }

        private static void SetVenueSingersAndTotalPrice(string input, Dictionary<string, Dictionary<string, long>> arenaSingersAndTotalPrices, Dictionary<string, long> singersAndTotalPrices)
        {

            while (input != "End")
            {
                string[] inputArr = input.Split('@').ToArray();

                string singer = inputArr[0];

                if (singer.Last() != ' ')// ako go nqmame tova znachi e nevaliden inputa 
                    input = Console.ReadLine();
                else
                {
                    singer = singer.Trim(); // we have the singer

                    List<string> remainingInfo = inputArr[1].Split(' ').ToList();

                    if (remainingInfo.Count < 3) // skipvame i drugiq nevaliden input
                        input = Console.ReadLine();
                    else
                    {
                        long ticketCount = long.Parse(remainingInfo.Last());
                        remainingInfo.RemoveAt(remainingInfo.Count - 1);

                        long ticketPrice = long.Parse(remainingInfo.Last());
                        remainingInfo.RemoveAt(remainingInfo.Count - 1);

                        string arena = string.Empty;
                        foreach (var item in remainingInfo)
                            arena += item.ToString() + " ";
                        arena = arena.Trim();

                        long totalMoney = ticketCount * ticketPrice;

                        if (!arenaSingersAndTotalPrices.ContainsKey(arena))
                            singersAndTotalPrices = new Dictionary<string, long>();
                        else // ako arenata e razlichna prosto refreshvame  singersAndTotalPrices
                            singersAndTotalPrices = arenaSingersAndTotalPrices[arena];



                        if (!singersAndTotalPrices.ContainsKey(singer))
                            singersAndTotalPrices[singer] = totalMoney;
                        else// ako nqma takuv pevec go slagame a ako ima prostosubirame cenata sus starata
                            singersAndTotalPrices[singer] += totalMoney;

                        // podrejdame si spisuka po cenata ot po golqmo kum po malko
                        singersAndTotalPrices = singersAndTotalPrices.OrderByDescending(pair => pair.Value)
                        .ToDictionary(pair => pair.Key, pair => pair.Value);

                        // dobavqme vsichko kum glavniq rechnik
                        arenaSingersAndTotalPrices[arena] = singersAndTotalPrices;

                        input = Console.ReadLine();
                    }
                }
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> arenaSingersAndTotalPrices)
        {
            foreach (var arena in arenaSingersAndTotalPrices)
            {
                Console.WriteLine(arena.Key);
                foreach (var singerAndPrice in arena.Value)
                {
                    Console.WriteLine($"#  {singerAndPrice.Key} -> {singerAndPrice.Value}");
                }
            }
        }

    }
}
