using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            int[] inputArr = input.Split().Select(int.Parse).ToArray();

            int maxEvenNum = 0;
            int maxOddNum = 0;
            int minEvenNum = 500000;
            int minOddNum = 500000;
            while (true)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                
                if (command[0].Equals("end"))
                    break;


                if (command.Contains("exchange"))
                {
                    int index = int.Parse(command[1]);
                    inputArr = Exchange(inputArr, index);
                   
                }
                else if (command.Contains("max"))
                {

                    if (command.Contains("even"))
                        MaxEvenNum(inputArr, maxEvenNum);
                    else if (command.Contains("odd"))
                        MaxOddNum(inputArr, maxOddNum);

                }
                else if (command.Contains("min"))
                {

                    if (command.Contains("even"))
                        MinEvenNum(inputArr, minEvenNum);
                    else if (command.Contains("odd"))
                         MinOddNum(inputArr, minOddNum);

                }
                else if (command.Contains("first"))
                {
                    int count = int.Parse(command[1]);
                    if (command.Contains("even"))
                    {
                        FirstEven(inputArr,count);
                    }
                    else if (command.Contains("odd"))
                    {
                        FirstOdd(inputArr, count);
                    }
                }
                else if (command.Contains("last"))
                {
                    int count = int.Parse(command[1]);
                    if (command.Contains("even"))
                    {
                        LastEven(inputArr, count);
                    }
                    else if (command.Contains("odd"))
                    {
                        LastOdd(inputArr, count);
                    }
                }
            }
           
            Console.WriteLine("[" + string.Join(", ",inputArr) + "]");

        }

        private static void LastOdd(int[] inputArr, int count)
        {
            if (count > inputArr.Length)
                Console.WriteLine("Invalid count");
            else if(count.Equals(0))
                Console.WriteLine("[]");
            else
            {
                List<int> lastOddElements = new List<int>();
                int counter = 0;
                for (int i = inputArr.Length - 1; i >= 0; i--)
                {
                    if (inputArr[i] % 2 == 1)
                    {
                        lastOddElements.Add(inputArr[i]);
                        counter++;
                        if (counter == count)
                            break;
                    }
                }
                lastOddElements.Reverse();
                Console.WriteLine("[" + string.Join(", ", lastOddElements) + "]");
            }
        }

        private static void LastEven(int[] inputArr, int count)
        {
            if (count > inputArr.Length)
                Console.WriteLine("Invalid count");
            else if (count.Equals(0))
                Console.WriteLine("[]");
            else
            {
                List<int> lastEvenElements = new List<int>();
                int counter = 0;
                for (int i = inputArr.Length - 1; i >= 0; i--)
                {
                    if (inputArr[i] % 2 == 0)
                    {
                        lastEvenElements.Add(inputArr[i]);
                        counter++;
                        if (counter == count)
                            break;
                    }
                }
                lastEvenElements.Reverse();
                Console.WriteLine("[" + string.Join(", ", lastEvenElements) + "]");
            }
        }

        private static void FirstOdd(int[] inputArr, int count)
        {
            if (count > inputArr.Length)
                Console.WriteLine("Invalid count");
            else if (count.Equals(0))
                Console.WriteLine("[]");
            else
            {
                List<int> firstOddElements = new List<int>();
                int counter = 0;
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (inputArr[i] % 2 == 1)
                    {
                        firstOddElements.Add(inputArr[i]);
                        counter++;
                        if (counter == count)
                            break;
                    }
                }

                Console.WriteLine("[" + string.Join(", ", firstOddElements) + "]");
            }
        }

        private static void FirstEven(int[] inputArr, int count)
        {
            if (count > inputArr.Length)
                Console.WriteLine("Invalid count");
            else if (count.Equals(0))
                Console.WriteLine("[]");
            else
            {
                List<int> firstEvenElements = new List<int>();
                int counter = 0;
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (inputArr[i] % 2 == 0)
                    {
                        firstEvenElements.Add(inputArr[i]);
                        counter++;
                        if (counter == count)
                            break;
                    }
                }

                Console.WriteLine("[" + string.Join(", ", firstEvenElements) + "]");
            }
        }

        private static void MaxEvenNum(int[] inputArr, int maxEvenNum)
        {

           
                int indexOfMaxEvenNum = 0;
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (inputArr[i] % 2 == 0)
                    {
                        if (maxEvenNum <= inputArr[i])
                        {
                            maxEvenNum = inputArr[i];
                            indexOfMaxEvenNum = i;
                        }
                    }
                }

                if(maxEvenNum != 0)
                    Console.WriteLine(indexOfMaxEvenNum);
                else
                    Console.WriteLine("No matches");

        }

        private static void MaxOddNum(int[] inputArr, int maxOddNumber)
        {
            int indexOfMaxOddNum = 0;
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] % 2 == 1)
                {
                    if (maxOddNumber <= inputArr[i])
                    {
                        maxOddNumber = inputArr[i];
                        indexOfMaxOddNum = i;
                    }
                 }
            }

                if(maxOddNumber == 0)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(indexOfMaxOddNum);
        
            
        }

        private static void MinEvenNum(int[] inputArr, int minEvenNumber)
        {
            int indexOfMinEvenNum = 0;
            for (int i = 0; i < inputArr.Length; i++)
            {
                if (inputArr[i] % 2 == 0)
                {
                    if (minEvenNumber >= inputArr[i])
                    {
                        minEvenNumber = inputArr[i];
                        indexOfMinEvenNum = i;
                    }
                }
            }
                if(minEvenNumber == 500000)
                    Console.WriteLine("No matches");
                else
                Console.WriteLine(indexOfMinEvenNum);
 
        }

        private static void MinOddNum(int[] inputArr, int minOddNumber)
        {
            int indexOfMinOddNumber = 0;
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (inputArr[i] % 2 == 1)
                    {
                        if (minOddNumber >= inputArr[i])
                        {
                            minOddNumber = inputArr[i];
                            indexOfMinOddNumber = i;
                        }
                    }
                }
          
                if (minOddNumber == 500000)
                    Console.WriteLine("No matches");
                else
                    Console.WriteLine(indexOfMinOddNumber);            
        }

        private static int[] Exchange(int[] inputArr, int index)
        {         

            if (index >= inputArr.Length || index < 0)
            {
                Console.WriteLine("Invalid index");
                return inputArr;
            }
            else
            {
                List<int> newArr = new List<int>();
                int[] elements = inputArr.Take(index + 1).ToArray();
                newArr = inputArr.Skip(index + 1).ToList();
                foreach (var elem in elements)
                {
                    newArr.Add(elem);
                }

                return newArr.ToArray();
            }                       
        }
    }
}
