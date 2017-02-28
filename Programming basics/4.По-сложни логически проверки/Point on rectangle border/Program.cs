using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_tochka_v_pravougulnik
{
    class Program
    {
        static void Main(string[] args)
        {
            //            zadacha tochka vurho strana na  pravougulnik :



            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            var isOnLeftOrRightBorder = (x == x1 || x == x2) && (y >= y1 && y <= y2);
            var isOnTopOrBottomBorder = (y == y1 || y == y2) && (x >= x1 && x <= x2);

            if (!(x1 < x2 && y1 < y2))
            {
                Console.WriteLine("Error");
            }
            else
            {

                if (isOnLeftOrRightBorder ||isOnTopOrBottomBorder) {

                    Console.WriteLine("border");
                }
                else {
                    Console.WriteLine("Inside / Outside");
                }
            }
        }
    }
}
