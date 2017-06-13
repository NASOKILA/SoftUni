using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grab_And_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            long sum = 0L;
            int index = 0;
            while (true)
            {
                // opitvame da skochim na lqvo
                int tempIndex = index;
                sum += input[index];
                index = tempIndex + input[index];

                if (index >= input.Length)
                {
                    // shte opitame da skochim na lqvo
                    index = tempIndex - input[tempIndex];
                    if (index < 0)
                        break;// ako ne stava breikvame
                }
            }

            Console.WriteLine(sum);
        }
    }
}
