using System;

namespace LongerLine
{
   public class Program
    {
        public static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());

            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());


            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());      

            double firstLineLeght = FindDistanceBetweenTwoPoints( x1, y1, x2, y2);
            double SecondLineLenght = FindDistanceBetweenTwoPoints(x3, y3, x4, y4);
           // PrintLongerLinePoints(x1, y1, x2, y2, x3, y3, x4, y4, firstLineLeght, SecondLineLenght);

            if (firstLineLeght >= SecondLineLenght)
            {
                PrintLongerLinePoints(x1, y1, x2, y2);
            }
            else
            {
                PrintLongerLinePoints(x3, y3, x4, y4);

            }

           


        }

        private static void PrintLongerLinePoints(double x1, double y1, double x2, double y2)
        {
            double distanceToZero = FindDistanceBetweenTwoPoints(x1, y1, 0, 0);
            double distanceToZero2 = FindDistanceBetweenTwoPoints(x2, y2, 0, 0);

            if (distanceToZero < distanceToZero2)
            {
                Console.WriteLine("(" + x2 + ", " + y2 + ")(" + x1 + ", " + y1 + ")");

            }
            else
            {

                Console.WriteLine("(" + x1 + ", " + y1 + ")(" + x2 + ", " + y2 + ")");

            }
        }

        static double FindDistanceBetweenTwoPoints(double X1, double Y1, double X2, double Y2) {
            
            double distance = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1,2));
           
            return distance;
        }

      

        
    }
}
