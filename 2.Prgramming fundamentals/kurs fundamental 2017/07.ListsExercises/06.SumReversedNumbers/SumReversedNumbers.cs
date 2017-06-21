using System;
using System.Collections.Generic;
using System.Linq;


namespace _06.SumReversedNumbers
{
    class SumReversedNumbers
    {
        static void Main(string[] args)
        {

            List<string> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)                
                .ToList();

            long sum = 0;
            
            string number = string.Empty;
            foreach (var item in numbers)
            {
                for (int i = item.Length-1; i >= 0; i--)
                {
                    number += item[i];
                }
                sum += long.Parse(number);
                number = string.Empty;
            }


            Console.WriteLine(sum);
        }
    }
}
