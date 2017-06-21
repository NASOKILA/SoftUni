    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _05.ArrayManipulator
    {
        class ArrayManipulator
        {
            static void Main(string[] args)
            {
                List<int> list = Console.ReadLine()
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

                        list.Insert(index, element);
                    }
                    else if (command[0] == "addMany")
                    {
                        index = int.Parse(command[1]);
                        List<int> numstoInsert = command
                             .Skip(2)
                             .Take(command.Length - 2)
                             .Select(int.Parse)
                             .ToList();

                        list.InsertRange(index, numstoInsert);

                    }
                    else if (command[0] == "contains")
                    {
                        element = int.Parse(command[1]);
                        if (list.Contains(element))
                            Console.WriteLine(list.IndexOf(element));
                        else
                            Console.WriteLine("-1");
                    }
                    else if (command[0] == "remove")
                    {
                        index = int.Parse(command[1]);
                        list.RemoveAt(index);

                    }
                    else if (command[0] == "shift")
                    {
                         int first = 0;
                         position = int.Parse(command[1]) % list.Count;
                         for (int i = 0; i < position; i++)
                         {
                             first = list[0];
                             list.RemoveAt(0);
                             list.Add(first);
                         }

                    }
                    else if (command[0] == "sumPairs")
                    {

                    var sumPairs = new List<int>();

                        for (int i = 0; i < list.Count; i+=2)
                        {
                            var currentElement = list[i];
                            var nextElement = 0;

                            if(i < list.Count - 1)
                                nextElement = list[i + 1];

                            var elementsSum = currentElement + nextElement;
                            sumPairs.Add(elementsSum);
                        }
                    list = sumPairs;
                    }

                command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                }

                Console.WriteLine("[{0}]", string.Join(", ", list));
            }
        }
    }
