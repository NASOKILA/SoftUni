using System;
using System.Collections.Generic;
using System.Linq;


namespace _01.RemoveNegativesAndReverse
{
    class RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> reversedList = new List<int>();

            for (int i = list.Count - 1; i >= 0; i--)
            {

                if (list[i] >= 0)
                {
                    reversedList.Add(list[i]);
                }

            }


            if (reversedList.Count < 1)
                Console.WriteLine("empty");
            else
                Console.WriteLine(string.Join(" ", reversedList));
        }
    }
}
