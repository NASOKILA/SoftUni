using System;
using System.Linq;

namespace _02.Manipulate_Array
{
    class Manipulate_Array
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {
                string[] command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)    
                .ToArray();

                if (command[0] == "Reverse")
                    input = input.Reverse().ToArray();
                else if (command[0] == "Distinct")
                    input = input.Distinct().ToArray();
                else if (command[0] == "Replace" && command.Length == 3)
                {

                    input[int.Parse(command[1])] = command[2];
                } 
            }

            Console.WriteLine(string.Join(", ", input));


        }
    }
}
