using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumStep3
{
    class SumStep3
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                numbers[i] = num;
            }


            for (int i = 0; i < numbers.Length; i = i + 3)
            {
                sum1 += numbers[i];
            }
            for (int i = 1; i < numbers.Length; i = i + 3)
            {
                sum2 += numbers[i];
            }
            for (int i = 2; i < numbers.Length; i = i + 3)
            {
                sum3 += numbers[i];
            }

            Console.WriteLine($"sum1 = {sum1}");
            Console.WriteLine($"sum2 = {sum2}");
            Console.WriteLine($"sum3 = {sum3}");
        }
    }
}
