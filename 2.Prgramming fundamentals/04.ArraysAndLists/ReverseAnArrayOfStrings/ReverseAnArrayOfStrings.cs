using System;

namespace ReverseAnArrayOfStrings
{
    public class ReverseAnArrayOfStrings
    {

    

        public static void Main(string[] args)
        {
            string letters =  Console.ReadLine();
            string[] items = letters.Split(' ');

            for (int i = items.Length-1; i >= 0; i--)
            {
                Console.Write(items[i] + " ");
            }

 // WE CAN USE Reverse();
           
        }
    }
}
