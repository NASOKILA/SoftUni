using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Започва се с 0 и 1, а всеки следващ член на редицата се получава като сума на предходните два. 
              Първите няколко числа на Фибоначи са 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89,...*/

            int n = int.Parse(Console.ReadLine());

            int purvoChislo = 0;
            int vtoroChislo = 1;

            int counter = 0;
            int fibonacci = 0;
            
            while (counter <= n)
            {
                
                fibonacci = purvoChislo + vtoroChislo;
                purvoChislo = vtoroChislo;
                vtoroChislo = fibonacci;               
                counter++;
                if (counter==1) { n = n - 1; }
            }
            Console.WriteLine(fibonacci);
        }
    }
}
