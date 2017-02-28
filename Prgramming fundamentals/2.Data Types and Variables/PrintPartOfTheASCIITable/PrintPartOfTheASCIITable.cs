using System;

namespace PrintPartOfTheASCIITable
{
    public class PrintPartOfTheASCIITable
    {
        public static void Main(string[] args)
        {

            /*Find online more information about ASCII (American Standard Code for Information Interchange) 
              and write a program that prints part of the ASCII table of characters at the console.  
              On the first line of input you will receive the char index you should start with and on the 
              second line - the index of the last character you should print. */

            byte start = byte.Parse(Console.ReadLine());
            byte end = byte.Parse(Console.ReadLine());

            char startChr = (char)start;
            char endChr = (char)end;

            for (char i = startChr; i <= endChr; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }
    }
}
