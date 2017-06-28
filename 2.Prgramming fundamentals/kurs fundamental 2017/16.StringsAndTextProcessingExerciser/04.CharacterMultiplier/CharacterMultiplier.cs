using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            string str1 = input[0];
            string str2 = input[1];


            int result =  Multiplier(str1, str2);

            Console.WriteLine(result);
        }

        private static int Multiplier(string str1, string str2)
        {
            // sum characters of first and then second and then multiply them

            string longerStr = string.Empty;
            string shorterStr = string.Empty;

            int totalSum = 0;

            if (str1.Length >= str2.Length)
            {
                longerStr = str1;
                shorterStr = str2;
            }
            else
            {
                longerStr = str2;
                shorterStr = str1;
            }


            for (int i = 0; i < shorterStr.Length; i++)
                totalSum += str1[i] * str2[i];

            if (longerStr != shorterStr)
            {
                longerStr = longerStr.Remove(0, shorterStr.Length);
                foreach (var ch in longerStr)
                    totalSum += (int)ch;
                
            }

            return totalSum;
        }
    }
}
