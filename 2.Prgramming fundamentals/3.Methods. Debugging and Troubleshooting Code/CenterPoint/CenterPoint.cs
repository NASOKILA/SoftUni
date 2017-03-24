using System;

namespace CenterPoint
{
    class CenterPoint
    {
        static void Main(string[] args)
        {

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            PrintCenterPoint(x1,y1,x2,y2);

        }

        static void PrintCenterPoint(double X1, double Y1, double X2, double Y2) {

            double resultX = Math.Min(Math.Abs(X1), Math.Abs(X2)); 
            double resultY = Math.Min(Math.Abs(Y1), Math.Abs(Y2)); 

            if (X1 < 0  && resultX == Math.Abs(X1)) { resultX = resultX -(resultX * 2.00); }
            else if (X2 < 0 && resultX == Math.Abs(X2)) { resultX = resultX - (resultX * 2.00);}
            else if (Y1 < 0 && resultY == Math.Abs(Y1)) { resultY = resultY - (resultY * 2.00);}
            else if (Y2 < 0 && resultY == Math.Abs(Y2)) { resultY = resultY - (resultY * 2.00); }

            if (resultX == resultY) { Console.WriteLine("(" + X1 + ", " + Y1 + ")"); }  // ako sa ravni printirame purvoto
            else { Console.WriteLine("(" + resultX + ", " + resultY + ")"); }
            
        }
    }
}
