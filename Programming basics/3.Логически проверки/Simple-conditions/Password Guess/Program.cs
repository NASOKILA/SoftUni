using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Guess
{
    class Program
    {
        static void Main(string[] args)
        {

            var password = Console.ReadLine();
            string rightPassword = "s3cr3t!P@ssw0rd";
            if (password == rightPassword) {
                Console.WriteLine("Welcome");
            }
            else {
                Console.WriteLine("Wrong password!");
            }

        }
    }
}
