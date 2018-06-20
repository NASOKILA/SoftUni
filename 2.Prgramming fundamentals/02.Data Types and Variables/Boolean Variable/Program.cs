using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringOne = Console.ReadLine().ToLower();

            bool isConverted = Convert.ToBoolean(stringOne); 
           
            if(isConverted)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

        }
    }
}
