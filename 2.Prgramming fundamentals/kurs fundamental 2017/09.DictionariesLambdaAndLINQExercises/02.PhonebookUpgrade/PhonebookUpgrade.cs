using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PhonebookUpgrade
{
    class PhonebookUpgrade
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            SortedDictionary<string, string> nameAndNumber = new SortedDictionary<string, string>();

            while (input[0] != "END")
            {

                if (input[0].Equals("A"))
                {
                    string name = input[1];
                    string number = input[2];

                    nameAndNumber[name] = number;
                }
                else if (input[0].Equals("S"))
                {
                    string name = input[1];

                    if (nameAndNumber.ContainsKey(name))
                        Console.WriteLine($"{name} -> {nameAndNumber[name]}");
                    else
                        Console.WriteLine($"Contact {name} does not exist.");
                }
                else if (input[0].Equals("ListAll"))
                {
                    foreach (var item in nameAndNumber)
                    {
                        Console.WriteLine(item.Key + " -> " + item.Value);
                    }
                }

                input = Console.ReadLine().Split(' ').ToList();
            }

        }
    }
}
