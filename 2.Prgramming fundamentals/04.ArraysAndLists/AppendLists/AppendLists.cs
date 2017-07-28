using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
           
            List<string> items = Console.ReadLine().Split('|').ToList();

            items.Reverse();  // OBRUSHTAME items
            var result = new List<string>(); // suzdavame si nov list za rezultata
           
            // nqma da gi pasrvame vuv chisla, ne ni e nujno
            foreach (var item in items)
            {


                List<string> nums = item.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList(); // splitvame chislata s intervali
                result.AddRange(nums); // TAKA SLAGAME nums VUV result

                // StringSplitOptions.RemoveEmptyEntries   NI MAHA PRAZNITE MESTA !!! VAJNO !
            }

           

            Console.WriteLine(string.Join(" ",result));

        }
    }
}
