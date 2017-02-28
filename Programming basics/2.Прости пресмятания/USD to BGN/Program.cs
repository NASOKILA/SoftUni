using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USD_to_BGN
{
    class Program
    {
        static void Main(string[] args)
        {
            // fiksiran kurs : 1 USD = 1.79549 BNG

            Console.Write("Input amount USD : ");
            var usd = double.Parse(Console.ReadLine());
            var bng = usd * 1.79549;
            Console.WriteLine("In BNG = " + Math.Round(bng, 2));

        }
    }
}
