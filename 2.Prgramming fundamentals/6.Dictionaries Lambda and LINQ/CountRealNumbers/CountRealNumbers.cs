using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double[] numbers = input.Split(' ').Select(double.Parse).ToArray();

            
            var counts = new SortedDictionary<double, int>();
            foreach (var num in numbers)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++; 
                    // ako veche sudurja dumata ovelichi stoinostite s 1
                }
                else
                {
                    // ako ne sudurja dumata q dobavi sus stoinost 1
                    counts[num] = 1;
                }
            }

            foreach (var pair in counts)
            {
                // printirame klucha i stoinosta t.e. koe chislo e i kolko puti se e poqvqvalo !
                Console.WriteLine("{0} -> {1}",pair.Key, pair.Value);
                //PODREDENI SA OT NAI MALKO KUM NAI GOLQMO !
            }
            
        }
    }
}
