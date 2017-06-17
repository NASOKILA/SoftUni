using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            long n;
            bool result = long.TryParse(input, out n);
            if(result)
                Console.WriteLine("integer");
            else
                Console.WriteLine("floating-point");
        }
    }
}
