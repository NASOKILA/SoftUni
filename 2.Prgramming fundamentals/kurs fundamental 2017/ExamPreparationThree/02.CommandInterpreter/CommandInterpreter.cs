    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _02.CommandInterpreter
    {
        class CommandInterpreter
        {
            static void Main(string[] args)
            {
                string[] array = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim())
                    .ToArray();

                string[] command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim())
                    .ToArray();

                while (true)
                {

                    if (command[0] == "reverse")
                        Reverse(array, command);
                    else if (command[0] == "sort")
                        Sort(array, command);
                    else if (command[0] == "rollLeft")
                        array = RollLeft(array, command);
                    else if (command[0] == "rollRight")
                        array = RollRight(array, command);


                    command = Console.ReadLine()
                   .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(a => a.Trim())
                   .ToArray();
                }

                Console.WriteLine($"[{string.Join(", ", array)}]");


            }

            private static string[] RollLeft(string[] arr, string[] command)
            {
                try
                {
                    List<string> result = arr.ToList();
                    int count = int.Parse(command[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        return arr;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string first = result.First();
                            result.Skip(1);
                            result.Add(first);
                        }


                        arr = result.ToArray();
                    }
                    return arr;
                }
                catch
                {
                    Console.WriteLine("Invalid input parameters.");
                    return arr;
                }
            }

            private static string[] RollRight(string[] arr, string[] command)
            {
                try
                {
                    List<string> result = arr.ToList();
                    int count = int.Parse(command[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        return arr;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string last = result.Last();
                            result.Remove(last);
                            result.Insert(0, last);
                        }


                        arr = result.ToArray();
                    }
                    return arr;
                }
                catch
                {
                    Console.WriteLine("Invalid input parameters.");
                    return arr;
                }
            }



            private static void Sort(string[] array, string[] command)
            {
                try
                {


                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);

                    if (start < 0
                                || start > array.Length - 1
                                || (start + count - 1 < 0)
                                || start + count - 1 > array.Length - 1
                                || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        return;
                    }
                    Array.Sort(array, start, count);

                }
                catch
                {
                    Console.WriteLine("Invalid input parameters.");
                    return;
                }
            }

            private static void Reverse(string[] array, string[] command)
            {
                try
                {
                    int start = int.Parse(command[2]);
                    int end = int.Parse(command[4]);

                    if (start < 0
                                 || start > array.Length - 1
                                 || (start + end - 1 < 0)
                                 || start + end - 1 > array.Length - 1
                                 || end < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        return;
                    }

                    Array.Reverse(array, start, end);
                }
                catch
                {
                    Console.WriteLine("Invalid input parameters.");
                }
            }
        }

    }