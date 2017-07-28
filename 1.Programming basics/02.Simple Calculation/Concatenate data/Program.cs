using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concatenate_data
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var firstName = Console.ReadLine();
                var lastName = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());
                var town = Console.ReadLine();

                Console.WriteLine("You are {0} {1}, a {2} year old person from {3}. ", firstName, lastName, age, town);
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }

       }

    }
}
