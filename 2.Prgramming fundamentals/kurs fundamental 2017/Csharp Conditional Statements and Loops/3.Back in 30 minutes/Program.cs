using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Back_in_30_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if(minutes < 30)
            {
                minutes = minutes + 30;
            }
            else if (minutes >= 30)
            {               
                hours++;
                minutes = minutes - 30;
            }

            if (hours > 23)
                hours = 0;

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
