using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            bool sumFound = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                long sumOfLeft = 0;
                long sumOfRight = 0;
               

                for (int j = 0; j < i; j++)
                {
                    sumOfLeft += numbers[j];
                }

                for (int j = i+1; j < numbers.Length; j++)
                {
                    sumOfRight += numbers[j];
                }

                if (sumOfLeft == sumOfRight)
                {
                    sumFound = true;
                    Console.WriteLine(i);
                    break; 
                }        

            }

           
            if (sumFound == false ) { Console.WriteLine("no"); }

        }
    }
}
