using System;


namespace GeometryCalculator
{
    public class GeometryCalculator
    {
        public static void Main(string[] args)
        {

            string typeOfFigure = Console.ReadLine().ToLower();

            if (typeOfFigure == "triangle") {

                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = GetAreaOfTriangle(side, height);
                Console.WriteLine("{0:f2}", area);
            }
            else if (typeOfFigure == "square") {

                double side = double.Parse(Console.ReadLine());
                double area = GetAreaOfSquare(side);
                Console.WriteLine("{0:f2}", area);
            }
            else if (typeOfFigure == "rectangle") {

                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = GetAreaOfRectangle(width, height);
                Console.WriteLine("{0:f2}", area);
            }
            else if (typeOfFigure == "circle")
            {               
                double radius = double.Parse(Console.ReadLine());
                double area = GetAreaOfCircle(radius);
                Console.WriteLine("{0:f2}", area);
            }

        }

        private static double GetAreaOfCircle(double radius)
        {
            double area = Math.PI * Math.Pow(radius, 2);
            return area;
        }

        private static double GetAreaOfRectangle(double width, double height)
        {
            double area = width * height;
            return area;
        }

        private static double GetAreaOfSquare(double side)
        {
            double area = side * side;
            return area;
        }

        private static double GetAreaOfTriangle(double side, double height)
        {
            double area = (side * height) / 2.00;
            return area;
        }
    }
}
