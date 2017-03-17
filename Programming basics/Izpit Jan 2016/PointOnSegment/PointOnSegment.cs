using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOnSegment
{
    class PointOnSegment
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());

            int min = Math.Min(first, second);
            int max = Math.Max(first, second);
            int difference = max - min;
            double middlePoint = (min + difference/2);

            if (point >= min && point <= max)
            {
                Console.WriteLine("in");
                if(point < middlePoint)
                    Console.WriteLine(point - min);
                else if(point > middlePoint)
                    Console.WriteLine(max - point);
                else
                    Console.WriteLine(middlePoint);
            }
            else
            {
                Console.WriteLine("out");

                if (point < min)
                    Console.WriteLine(min - point);
                else if (point > max)
                    Console.WriteLine(point - max);
            }
        }
    }
}
