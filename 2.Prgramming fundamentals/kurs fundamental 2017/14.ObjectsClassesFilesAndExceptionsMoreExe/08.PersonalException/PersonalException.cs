using System;
using System.Collections.Generic;
using System.Linq;


namespace _08.PersonalException
{
    class PersonalException
    {
        class NegativeNumberException : Exception // nasledqvame klasa Excption
        {
            // pishem si konstruktora i si slagame message vutre v base 
            public NegativeNumberException(): base("My first exception is awesome!!!")
            {}

        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input < 0)
                        throw new NegativeNumberException();
                    else
                        Console.WriteLine(input);

                }
                catch (NegativeNumberException a)
                {
                    Console.WriteLine(a.Message);
                    break;
                }
            }

        }
    }
}
