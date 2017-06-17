using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SquareNumbers
{
    class SquareNumbers
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> squareNums = new List<int>();

            foreach (var num in numbers)
            {
                if (Math.Sqrt(num) == (int)Math.Sqrt(num))
                    squareNums.Add(num);
            }

            Console.WriteLine(string.Join(" ", squareNums.OrderByDescending(a => a)));
        }
    }
}
