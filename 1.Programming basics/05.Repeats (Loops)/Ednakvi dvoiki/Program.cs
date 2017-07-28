using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ednakvi_dvoiki
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine()); //2

            var currSum = 0.0;
            var prevSum = 0.0;
            var diff = 0.0;
            var maxDiff = 0.0;

            for (int i = 0; i < numbersCount; i++) { // 4 puti

                prevSum = currSum;
                currSum = 0;

                int num = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                currSum = currSum + num + num2;

                if (i != 0)
                {
                    diff = Math.Abs(currSum - prevSum);

                    if (diff != 0 && diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }
            }


            if (prevSum == currSum || numbersCount == 1)
            {
                Console.WriteLine("Yes, value={0}", currSum);
            }
            else
            {
                Console.WriteLine("No, maxdiff={0}", maxDiff);
            }


        }
    }
}
