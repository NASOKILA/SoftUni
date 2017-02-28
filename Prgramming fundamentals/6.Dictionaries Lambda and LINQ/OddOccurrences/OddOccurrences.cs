using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();  // slagame ToLower()
            string[] words = input.Split(' ').ToArray();



            Dictionary<string, int> counts = new Dictionary<string, int>(); // rechnika e absolutno prazen
            // suzdavame rechnik sus v sluchaq dumi i broi povtoreniq

            foreach (var word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++; // ako sudurja dumata  dobavi 1
                }
                else
                {
                    counts[word] = 1;  // ako ne sudurja dumata, q dobavi i napravi stoinosta na 1
                }
            }

            var results = new List<string>();
            foreach (var pair in counts)
            {
                if (pair.Value % 2 == 1) // ako Stoinosta e nechetna 
                {
                    results.Add(pair.Key);
                }              
            }

            Console.WriteLine(string.Join(", ",results));
        }
        
    }
}
