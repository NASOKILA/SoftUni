    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _05.ArrayManipulator
    {
        class ArrayManipulator
        {
            static void Main(string[] args)
            {
                List<int> numbers = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                string[] command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();



                int index = 0;
                int position = 0;
                int element = 0;

                while (command[0] != "print")
                {

                    if (command[0] == "add")
                    {
                        index = int.Parse(command[1]);
                        element = int.Parse(command[2]);

                        numbers.Insert(index, element);
                    }
                    else if (command[0] == "addMany")
                    {
                        index = int.Parse(command[1]);
                        List<int> numstoInsert = command
                             .Skip(2)
                             .Take(command.Length - 2)
                             .Select(int.Parse)
                             .ToList();

                        numbers.InsertRange(index, numstoInsert);

                    }
                    else if (command[0] == "contains")
                    {
                        element = int.Parse(command[1]);
                        if (numbers.Contains(element))
                            Console.WriteLine(numbers.IndexOf(element));
                        else
                            Console.WriteLine("-1");
                    }
                    else if (command[0] == "remove")
                    {
                        index = int.Parse(command[1]);
                        numbers.RemoveAt(index);

                    }
                    else if (command[0] == "shift")
                    {
                         int first = 0;
                         position = int.Parse(command[1]);
                         for (int i = 0; i < position; i++)
                         {
                             first = numbers[0];
                             numbers.RemoveAt(0);
                             numbers.Add(first);
                         }

                    }
                    else if (command[0] == "sumPairs")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] = numbers[i] + numbers[i + 1];
                            numbers.Remove(numbers[i + 1]);
                        }
                    }

                    command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                }

                Console.WriteLine("[" + string.Join(", ", numbers) + "]");
            }
        }
    }
