using System;
using System.Linq;

namespace _03.CirclesIntersection
{
    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class CirclesIntersection
    {
        static void Main(string[] args)
        {
            int[] inputOne = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            int[] inputTwo = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            Point circleOneCenter = new Point()
            {
                X = inputOne[0],
                Y = inputOne[1]
            };

            Point circleTwoCenter = new Point()
            {
                X = inputTwo[0],
                Y = inputTwo[1]
            };

            Circle circleOne = new Circle
            {
                Center = circleOneCenter,
                Radius = inputOne[2]
            };

            Circle circleTwo = new Circle
            {
                Center = circleTwoCenter,
                Radius = inputTwo[2]
            };

            bool intersect = Intersect(circleOne, circleTwo);

            if(intersect)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

        }


        private static bool Intersect(Circle circleOne, Circle circleTwo)
        {
            bool result = false;

            double distance = DistanceBetweenTwoPoints(circleOne.Center, circleTwo.Center);
            if (distance <= (circleOne.Radius + circleTwo.Radius))
                result = true;

            return result;
        }

        private static double DistanceBetweenTwoPoints(Point center1, Point center2)
        {
            double sideA = center1.X - center2.X;
            double sideB = center1.Y - center2.Y;
            double distance = Math.Sqrt((sideA * sideA) + (sideB * sideB));
            return distance;
        }
    }
}
