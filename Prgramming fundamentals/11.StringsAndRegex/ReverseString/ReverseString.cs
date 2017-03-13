using System;

namespace ReverseString
{
   public class ReverseString
    {
        static void Main(string[] args)
        {

            string inputString = Console.ReadLine();
            string result = "";
         
                for (int i = inputString.Length-1; i >= 0; i--)
                {
                 result = string.Concat(result, inputString[i]);
                }

            Console.WriteLine(result);
        }
    }
}
