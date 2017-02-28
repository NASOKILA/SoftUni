using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Histograma
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());

            int num = 0;

            double p1 = 0.00;
            double p2 = 0.00;
            double p3 = 0.00;
            double p4 = 0.00;
            double p5 = 0.00;

            double p1Percentage = 0.00;
            double p2Percentage = 0.00;
            double p3Percentage = 0.00;
            double p4Percentage = 0.00;
            double p5Percentage = 0.00;

            for (var i = 0; i < numCount; i++)
            {

                num = int.Parse(Console.ReadLine());


                if (num >= 0 && num < 200) { p1++; }
                else if (num >= 200 && num < 400) { p2++; }
                else if (num >= 400 && num < 600) { p3++; }
                else if (num >= 600 && num < 800) { p4++; }
                else if (num >= 800 && num <= 1000) { p5++; }

            }

            p1Percentage = p1 / numCount * 100;
            p2Percentage = p2 / numCount * 100;
            p3Percentage = p3 / numCount * 100;
            p4Percentage = p4 / numCount * 100;
            p5Percentage = p5 / numCount * 100;


            if ((numCount < 0 || numCount > 1000) || (num < 0 || num > 1000)) { Console.WriteLine("Error!"); }
            else {
                Console.WriteLine("{0:f2}%", p1Percentage);
                Console.WriteLine("{0:f2}%", p2Percentage);
                Console.WriteLine("{0:f2}%", p3Percentage);
                Console.WriteLine("{0:f2}%", p4Percentage);
                Console.WriteLine("{0:f2}%", p5Percentage);
            }






        }
      
    }
}
