using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativesAndReverse
{
    class SortNumbers
    {
        static void Main(string[] args)
        {

            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            // taka vuvejdame string ot konzolata, splitvame s ' ' , selektirame i parsvame, i slagame nomerata na list


            List<int> result = new List<int>();

            

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] > 0)
                {
                    result.Add(numbers[i]);
                }

                
            }

            // sega imame celiq spisuk s pozitivnite chisla slojeni na obratno !!!

            if (result.Count < 1) { Console.WriteLine("empty"); }
            else {
                foreach (var item in result)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();

            }
           

        }
    }
}
