using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            List<decimal> text = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(decimal.Parse).ToList();


            text.Sort();

            Console.WriteLine(string.Join(" <= ", text));
        }
    }
}
