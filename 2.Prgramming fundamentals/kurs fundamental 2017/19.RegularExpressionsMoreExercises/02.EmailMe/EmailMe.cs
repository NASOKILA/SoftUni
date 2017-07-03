
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.EmailMe
{
    class EmailMe
    {
        static void Main(string[] args)
        {
            string[] email = Console.ReadLine()
                .Split(new char[] {'@'},StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            int before = 0;
            before = email[0].Length;

            int after = 0;
            after = email[1].Length;

            int result = before - after;
           
            if(result >= 0 )
                Console.WriteLine("Call her!");
            else
                Console.WriteLine("She is not the one.");
            

        }
    }
}
