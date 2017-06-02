using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            try
            {
                for (;;)
                {
                    int input = int.Parse(Console.ReadLine());
                    count++;
                }
            }
            catch
            {
                Console.WriteLine(count);
            }

        }
    }
}
