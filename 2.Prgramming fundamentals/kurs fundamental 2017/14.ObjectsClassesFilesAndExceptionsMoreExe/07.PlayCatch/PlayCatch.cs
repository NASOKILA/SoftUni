using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int countOfExceptions = 0;

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();
                if (command[0] == "Replace")
                {
                    int indexOne = int.Parse(command[1]);
                    int indexTwo = int.Parse(command[2]);

                    try
                    {
                        nums[indexOne] = indexTwo;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("The index does not exist!");
                        countOfExceptions++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        countOfExceptions++;
                    }

                    if (countOfExceptions == 3)
                        break;

                }
                else if (command[0] == "Show")
                {

                    try
                    {
                        int indexToShow = int.Parse(command[1]);
                        Console.WriteLine(nums[indexToShow]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        countOfExceptions++;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("The index does not exist!");
                        countOfExceptions++;
                    }

                    if (countOfExceptions == 3)
                        break;
                }
                else if (command[0] == "Print")
                {
                    try
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        List<int> printNums = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                            printNums.Add(nums[i]);
                        Console.WriteLine(string.Join(", ", printNums));
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("The index does not exist!");
                        countOfExceptions++;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("The variable is not in the correct format!");
                        countOfExceptions++;
                    }

                    if (countOfExceptions == 3)
                        break;
                }
                
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
