using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int maxNum = int.Parse(Console.ReadLine());
            int combinations = 0;
            double sum = 0;

            for (int i = N; i >= 1; i--)
            {
                for (int j = 1; j <= M; j++)
                {
                   
                   sum = sum + (3 * (i * j));
                    combinations++;
                    if (sum >= maxNum)
                        break;
                }

                if (sum >= maxNum)
                    break;
            }

            Console.WriteLine(combinations + " combinations");

            if (sum >= maxNum)
                Console.WriteLine($"Sum: {sum} >= {maxNum}");
            else
                Console.WriteLine($"Sum: {sum}");
            
        }
    }
}


