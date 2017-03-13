using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumBigNumbers
{
    class SumBigNumbers
    {
        static void Main(string[] args)
        {

            string firstNumber = Console.ReadLine();  // 923847238931983192462832102
            string secondNumber = Console.ReadLine(); // 934572893617836459843471846187346

            if (firstNumber.Length > secondNumber.Length)
            {
                secondNumber = secondNumber.PadLeft(firstNumber.Length, '0');
            }   // padLeft() adds spaces or whatever we tell it, to the left side of the string, padRight() dss them to the right 
            else
            {
                firstNumber = firstNumber.PadLeft(secondNumber.Length, '0');
                // dobavq 6 nuli ot lqvo na firstNumber zashtoto duljinata na secondNumber : 33 - duljinata na firstNumber: 27  =  6

            }


            byte sum = 0;
            byte numberInMind = 0;
            byte remainder = 0;
            StringBuilder result = new StringBuilder();


            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                sum = (byte)(byte.Parse(firstNumber[i].ToString()) + byte.Parse(secondNumber[i].ToString()) + numberInMind);
                numberInMind = (byte)(sum / 10);        // ako smata e nad 10 znaci numberInMind shte bute != 0
                remainder = (byte)(sum % 10);
                result.Append(remainder);

                 if (i == 0 && numberInMind != 0)
                {
                    result.Append(numberInMind);
                }

            }
            // OTGOVORA E NA OBRATNO I TRQBVA DA GO ZAVURTIM

            char[] resultToChar = result.ToString().ToCharArray(); // PRAVIM GO NA MASIV OT CHAROVE
            Array.Reverse(resultToChar);           // SEGA OBURNAHME MAIVA OT CHAROVE I POLUCHIHME OTGOVORA
            Console.WriteLine(new string(resultToChar));

        }
    }
}
