using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int capacity = 0;

            for (int i = 0; i < n; i++)
            {
                int quantityOfWater = int.Parse(Console.ReadLine());
                
                if ((capacity + quantityOfWater)  > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                capacity += quantityOfWater;
            }

            Console.WriteLine(capacity);

        }
    }
}
