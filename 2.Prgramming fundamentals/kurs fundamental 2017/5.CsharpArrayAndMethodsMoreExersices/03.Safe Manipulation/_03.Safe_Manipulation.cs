using System;
using System.Linq;


namespace _03.Safe_Manipulation
{
    class Safe_Manipulation
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] command = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (command[0] != "END")
            {
                try
                {
                    if (command[0] == "Reverse")
                        input = input.Reverse().ToArray();
                    else if (command[0] == "Distinct")
                        input = input.Distinct().ToArray();
                    else if (command[0] == "Replace" && command.Length == 3)
                        input[int.Parse(command[1])] = command[2];
                    else
                        Console.WriteLine("Invalid input!");
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();
            }

            Console.WriteLine(string.Join(", ",input));

        }
    }
}
