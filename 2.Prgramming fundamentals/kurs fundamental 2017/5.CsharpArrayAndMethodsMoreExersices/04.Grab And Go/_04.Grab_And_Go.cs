using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grab_And_Go
{
    class Grab_And_Go
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberToSearch = int.Parse(Console.ReadLine());

            if (!input.Contains(numberToSearch))
            {
                Console.WriteLine("No occurrences were found!");
                return;
            }

            int index = Array.LastIndexOf(input, numberToSearch);
            

            int sum = 0;
            for (int i = 0; i < index; i++)
            {
                sum += input[i];
            }

            Console.WriteLine(sum);
        }
    }
}
