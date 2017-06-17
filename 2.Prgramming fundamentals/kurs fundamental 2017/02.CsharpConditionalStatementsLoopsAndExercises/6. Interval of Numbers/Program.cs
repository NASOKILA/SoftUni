using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int min = Math.Min(firstNum,secondNum);
            int max = Math.Max(firstNum, secondNum);


            for (int i = min; i <= max; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
