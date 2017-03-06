using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfCircles
{
    class Point
    {
       public static bool Intersect(Circle c1, Circle c2, double distance) {

           
            if (distance > ((double)c1.radius + (double)c2.radius))
            {
                return false;
            }
            else
                return true;
        }
    }
}
