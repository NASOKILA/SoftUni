using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ClosestTwoPoints
{

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class ClosestTwoPoints
    {
        static void Main(string[] args)
        {
            int numOfPoints = int.Parse(Console.ReadLine());

            List<Point> allPoints = new List<Point>();
            Dictionary<double,  List<Point>> distancesPointXAndPointY = new Dictionary<double, List<Point>>();

            for (int i = 0; i < numOfPoints; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                Point p = new Point() { X = input[0], Y = input[1] };
                allPoints.Add(p);
            }

            double shortestDistance = 0.0;
            var closestPoints = FindClosesePoints(allPoints, distancesPointXAndPointY, shortestDistance);

            shortestDistance = distancesPointXAndPointY.Keys.Min();
            PrintResult(closestPoints, shortestDistance);

        }

        private static void PrintResult(List<Point> closestPoints, double shortestDistance)
        {
            Console.WriteLine($"{shortestDistance:F3}");
            foreach (var item in closestPoints)
            {
                Console.WriteLine($"({item.X}, {item.Y})");
            }
        }

        private static List<Point> FindClosesePoints(List<Point> allPoints, Dictionary<double, List<Point>> allDistances, double shortestDistance)
        {

            List<Point> pointXAndPointY = new List<Point>();
            for (int i = 0; i < allPoints.Count; i++)
            {
                for (int j = i+1; j < allPoints.Count; j++)
                {
                    pointXAndPointY = new List<Point>();
                    double distanceBetweenPoints = CalcDistance(allPoints[i], allPoints[j]);

                    if (!allDistances.ContainsKey(distanceBetweenPoints))
                    {
                        pointXAndPointY.Add(allPoints[i]);
                        pointXAndPointY.Add(allPoints[j]);

                        allDistances[distanceBetweenPoints] = pointXAndPointY;
                         //allDistances.Clear();
                         // allDistances.Clear();
                    }
                }

            }

            
            shortestDistance = allDistances.Keys.Min();
            // = allDistances.Where(k => k.Key == shortestDistance).ToList();
            List<Point> points = new List<Point>();
            foreach (var item in allDistances.Where(k => k.Key == shortestDistance))
            {
                points.Add(item.Value[0]);
                points.Add(item.Value[1]);
            }
            return points;
        }

        private static double CalcDistance(Point p1, Point p2)
        {
            double sideA = p1.X - p2.X;
            double sideB = p1.Y - p2.Y;
            double distance = Math.Sqrt((sideA * sideA) + (sideB * sideB));

            return distance;
        }
    }
}
