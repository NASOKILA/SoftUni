using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInFigure
{
    class PointInFigure
    {
        static void Main(string[] args)
        {

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if(x >= 4 && x <= 10 && (y >= -5 && y <= 3))
                Console.WriteLine("in");
            else if((y >= -3 && y <= 1) && (x >= 2 && x <= 12))
                Console.WriteLine("in");
            else
                Console.WriteLine("out");
        }
    }
}
