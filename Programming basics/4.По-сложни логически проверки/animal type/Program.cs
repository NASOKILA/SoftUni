using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animal_type
{
    class Program
    {
        static void Main(string[] args)
        {
            // goto case + number to case :  allows us to go back thrue cases 
            string animal = Console.ReadLine();

            switch (animal) {
                case "dog":
                    Console.WriteLine("mammal");
                    break;

                case "crocodile":
                    Console.WriteLine("reptile");
                    break;

                case "tortoise":
                    Console.WriteLine("reptile");
                    break;

                case "snake":
                    Console.WriteLine("reptile");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;

            }


        }
    }
}
