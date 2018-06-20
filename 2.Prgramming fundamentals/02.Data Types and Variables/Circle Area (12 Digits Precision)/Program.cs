using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_Area__12_Digits_Precision_
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double radius = double.Parse(Console.ReadLine());
            radius = Math.PI * radius * radius; // Formulata e Math.PI * radius * radius
            Console.WriteLine("{0:f12}", radius);

        }
    }
}
