using System;


namespace CalculateTriangleArea
{
    class Program
    {

        static double CalculateTriangleArea(){

           double w = double.Parse(Console.ReadLine());
           double h = double.Parse(Console.ReadLine());
           return  ((w * h) / 2);
            
        }


        static void Main(string[] args)
        {
            double area = CalculateTriangleArea();
            Console.WriteLine(area );
        }
    }
}
