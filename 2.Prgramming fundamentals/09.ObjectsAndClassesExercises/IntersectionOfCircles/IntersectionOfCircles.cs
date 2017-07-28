using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfCircles
{
   public class IntersectionOfCircles
    {
       public static void Main(string[] args)
        {
            int[] inputCircleOne = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Circle circleOne = SetCircleProperties(inputCircleOne);
           

            int[] inputCircleTwo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Circle circleTwo = SetCircleProperties(inputCircleTwo);           

            double distace = CalculateDistance(circleOne, circleTwo);

            bool result = Point.Intersect(circleOne, circleTwo, distace);

            PrintResult(result);
            
        }

        private static Circle SetCircleProperties(int[] inputCircle)
        {
            Circle circle = new Circle{
            centerPointX = inputCircle[0],
            centerPointY = inputCircle[1],
            radius = inputCircle[2],
            };

            return circle;
        }

        private static void PrintResult(bool result)
        {
            if (result)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        private static double CalculateDistance(Circle p1, Circle p2)
        {
            /* Za reshenieto se suzdava desen triugulnik !!!
               formilata e koren kvadrat ot razlikata ot hiksovete na 
               kvadrat po razlikata ot igrecite na kvadrat.   
             */
            int sideA = Math.Abs(p1.centerPointX - p2.centerPointX);
            int sideB = Math.Abs(p1.centerPointY - p2.centerPointY);
            double sideC = Math.Pow(sideA, 2) + Math.Pow(sideB, 2);
            double distance = Math.Sqrt(sideC);

            return distance;
        }
    }
}
