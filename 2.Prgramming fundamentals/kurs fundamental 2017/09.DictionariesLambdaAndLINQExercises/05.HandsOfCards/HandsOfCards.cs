using System;
using System.Collections.Generic;
using System.Linq;


namespace _05.HandsOfCards
{
    class HandsOfCards
    {
        static void Main(string[] args)
        {
            List<string> nameAndCards = Console.ReadLine()
                .Split(':')
                .Select(a => a.Trim())
                .ToList();

            Dictionary<string, int> nameAndPoints = new Dictionary<string, int>();

            Dictionary<string, List<string>> nameAndListOfCards = new Dictionary<string, List<string>>();

            SetNamesAndCards(nameAndCards, nameAndListOfCards);

            PrintResult(nameAndListOfCards);     
        }

        private static void PrintResult(Dictionary<string, List<string>> nameAndListOfCards)
        {
            foreach (var kvp in nameAndListOfCards)
            {
                string name = kvp.Key;
                var cards = kvp.Value;
                int totalSum = GetTotalSumOfCards(cards, name);
                Console.WriteLine($"{name}: {totalSum}");
            }
        }

        private static void SetNamesAndCards(List<string> nameAndCards, Dictionary<string, List<string>> nameAndListOfCards)
        {

            while (nameAndCards[0] != "JOKER")
            {

                string name = nameAndCards[0];

                List<string> cardsAndSuits = nameAndCards[1]
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim())
                    .Distinct()
                    .ToList();




                foreach (var card in cardsAndSuits)
                {
                    if (!nameAndListOfCards.ContainsKey(name))
                    {
                        nameAndListOfCards[name] = cardsAndSuits;
                        break;
                    }
                    else
                        if (!nameAndListOfCards[name].Contains(card))
                        nameAndListOfCards[name].Add(card);
                }

                nameAndCards = Console.ReadLine()
                .Split(':')
                .Select(a => a.Trim())
                .ToList();
            }
        }

        private static int GetTotalSumOfCards(List<string> cards, string name)
        {

            int totalSum = 0;
            int card = 0;
            string suite = string.Empty;
            foreach (var item in cards)
            {
                
                switch (item.First())
                {
                    case 'J':
                        card = 11;
                        break;
                    case 'Q':
                        card = 12;
                        break;
                    case 'K':
                        card = 13;
                        break;
                    case 'A':
                        card = 14;
                        break;
                    default:
                        card = int.Parse(item.Remove(item.Length - 1));
                        break;
                }

                suite = item.Last().ToString();

                switch (suite)
                {
                    case "S":
                        totalSum += (card * 4);
                        break;
                    case "H":
                        totalSum += (card * 3);
                        break;
                    case "D":
                        totalSum += (card * 2);
                        break;
                    case "C":
                        totalSum += (card * 1);
                        break;
                }


            }

            return totalSum;
        }
    }
}
