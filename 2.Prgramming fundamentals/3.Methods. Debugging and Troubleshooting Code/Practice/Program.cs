using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
       
        
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double result = GetTriangleArea(width, height);
            Console.WriteLine(result);
        }

        private static double GetTriangleArea(double width, double height)
        {
            double area = (width * height) / 2.0;
            return area; 
        }
    }
}
