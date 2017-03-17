using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfThreeNumbers
{
    class SumOfThreeNumbers
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            //if (first < 1 || first > 1000 || second < 1 || second > 1000 || third < 1 || third > 1000)
            //    return;

                if (first + second == third)
                Console.WriteLine($"{first} + {second} = {third}");
            else if (first + third == second)
                Console.WriteLine($"{third} + {first} = {second}");
            else if (second + first == third)
                Console.WriteLine($"{first} + {second} = {third}");
            else if (second + third == first)
                Console.WriteLine($"{third} + {second} = {first}");
            else if (third + first == second)
                Console.WriteLine($"{first} + {third} = {second}");
            else if (third + second == first)
                Console.WriteLine($"{second} + {third} = {first}");
            else
                Console.WriteLine("No");
        }
    }
}
