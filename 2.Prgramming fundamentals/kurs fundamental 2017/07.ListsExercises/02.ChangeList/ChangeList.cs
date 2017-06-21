using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List <int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();


            string[] command = Console.ReadLine().Split(' ').ToArray();

            while (command[0] != "Even" && command[0] != "Odd")
            {

                if (command[0] == "Delete")
                {
                    int numToDelete = int.Parse(command[1]);
                    numbers.RemoveAll(e => e == numToDelete);
                }
                else if (command[0] == "Insert")
                {
                    int element = int.Parse(command[1]);
                    int position = int.Parse(command[2]);
                    numbers.Insert(position, element);

                }

                command = Console.ReadLine().Split(' ').ToArray();
            }

            if(command[0] == "Even")
                Console.WriteLine(string.Join(" ", numbers.Where(e => e%2 == 0)));
            else if(command[0] == "Odd")
                Console.WriteLine(string.Join(" ", numbers.Where(e => e%2 == 1)));


        }
    }
}
