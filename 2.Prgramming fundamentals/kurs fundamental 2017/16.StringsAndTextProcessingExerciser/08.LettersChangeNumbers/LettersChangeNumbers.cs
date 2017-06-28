using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            decimal totalSum = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
               
                string currentInput = input[i];

                char firstLetter = input[i].First();
                char lastLetter = input[i].Last();

                currentInput  = currentInput.Remove(0, 1);
                currentInput = currentInput.Remove(currentInput.Length-1,1);
                decimal number = decimal.Parse(currentInput);

                int positionToFirstLetter = char.ToLower(firstLetter) - 96;
                int positionToSecondLetter = char.ToLower(lastLetter) - 96;

                if (char.IsUpper(firstLetter))
                    number /= positionToFirstLetter;
                else
                    number *= positionToFirstLetter;


                if (char.IsUpper(lastLetter))
                    number -= positionToSecondLetter;
                else
                    number += positionToSecondLetter;


                totalSum += number;
            }


            Console.WriteLine($"{totalSum:F2}");

        }

       
    }
}
