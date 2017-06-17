using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();

            Dictionary<string, string> nameAndNumber = new Dictionary<string, string>();
            
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

                    if(nameAndNumber.ContainsKey(name))
                        Console.WriteLine($"{name} -> {nameAndNumber[name]}");
                    else
                        Console.WriteLine($"Contact {name} does not exist.");
                }

                input = Console.ReadLine().Split(' ').ToList();
            }
            
        }
    }
}
