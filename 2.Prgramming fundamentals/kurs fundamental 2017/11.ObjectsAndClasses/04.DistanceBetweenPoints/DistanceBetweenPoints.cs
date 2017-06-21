using System;
using System.Linq;

namespace _04.DistanceBetweenPoints
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

    }

    class DistanceBetweenPoints
    {
        static void Main(string[] args)

        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] inputTwo = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Point p1 = new Point() { X = input[0], Y = input[1] };
            Point p2 = new Point() { X = inputTwo[0], Y = inputTwo[1] };

            double distanceBetweenPoints = CalcDistance(p1,p2);

            Console.WriteLine($"{distanceBetweenPoints:F3}");
        }

        private static double CalcDistance(Point p1, Point p2)
        {
            double sideA = p1.X - p2.X;
            double sideB = p1.Y - p2.Y;
            double distance = Math.Sqrt((sideA*sideA) + (sideB*sideB));

            return distance;
        }
    }
}
 