using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine()
               .Split(' ')
               .Select(double.Parse)
               .ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    list[i] += list[i];
                    list.Remove(list[i + 1]);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
