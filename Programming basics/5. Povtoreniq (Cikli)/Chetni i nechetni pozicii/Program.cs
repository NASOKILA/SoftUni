using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chetni_i_nechetni_pozicii
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());          

            var oddSumAsString = "0";
            var oddMinAsString = "No";
            var oddMaxAsString = "No";

            var evenSumAsString = "0";
            var evenMinAsString = "No";
            var evenMaxAsString = "No";


            if (numbersCount == 1)
            {
                var number = double.Parse(Console.ReadLine());
                oddSumAsString = number.ToString(); ;
                oddMinAsString = number.ToString();
                oddMaxAsString = number.ToString();

            }
            else if(numbersCount > 1)
                    {

                var currentOddSum = 0.0;
                var oddMin = double.MaxValue;
                var oddMax = double.MinValue;

                var currentEvenSum = 0.0;
                var evenMin = double.MaxValue;
                var evenMax = double.MinValue;

                for (var currentPosition = 1;
                    currentPosition <= numbersCount;
                    currentPosition++)
                {

                    var currentNumber = double.Parse(Console.ReadLine());

                    if (currentPosition % 2 == 1) // ako e current position e nechetno 
                    {
                        currentOddSum += currentNumber;
                        oddMin = Math.Min(oddMin, currentNumber);
                        oddMax = Math.Max(oddMax, currentNumber);
                    }
                    else
                    {  // ako e current position e chetno

                        currentEvenSum += currentNumber;
                        evenMin = Math.Min(evenMin, currentNumber);
                        evenMax = Math.Max(evenMax, currentNumber);
                    }
                }

                oddSumAsString = currentOddSum.ToString();
                oddMinAsString = oddMin.ToString();
                oddMaxAsString = oddMax.ToString();

                evenSumAsString = currentEvenSum.ToString();
                evenMinAsString = evenMin.ToString();
                evenMaxAsString = evenMax.ToString();
            }

            Console.WriteLine("OddSum={0}", 
             oddSumAsString);

            Console.WriteLine("OddMin={0}",
             oddMinAsString);

            Console.WriteLine("OddMax={0}",
             oddMaxAsString);

            Console.WriteLine("EvenSum={0}",
             evenSumAsString);

            Console.WriteLine("EvenMin={0}",
             evenMinAsString);

            Console.WriteLine("EvenMax={0}",
             evenMaxAsString);



        }
    }
}
