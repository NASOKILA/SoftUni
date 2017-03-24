using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_figure
{
    class Program
    {
        static void Main(string[] args)
        {
            // CTRL + K + T    NI PODREJDA KODA

            var blockSize = int.Parse(Console.ReadLine());
            var pointToCheckX = int.Parse(Console.ReadLine());
            var pointToCheckY = int.Parse(Console.ReadLine());

            var lowerRectangleLowerLeftPointX = 0;
            var lowerRectangleLowerLeftPointY = 0;
            var lowerRectangleUpperRightPointX = 3 * blockSize;
            var lowerRectangleUpperRightPointY = blockSize;

            // dali tochkata e v dolniq pravougulnik horizontalno
            var isPointHorizontallyInsadeLowerRectangle =
                lowerRectangleUpperRightPointX < pointToCheckX &&
                pointToCheckX < lowerRectangleUpperRightPointX;

            // dali tochkata e v dolniq pravougulnik vertikalno
            var isPointVerticallyInsadeLowerRectangle =
                lowerRectangleLowerLeftPointY < pointToCheckY &&
                pointToCheckY < lowerRectangleUpperRightPointY;

            // dali tochkata e v dolniq pravougulnik kato cqlo
            var isPointInsadeLowerRectangle =
                isPointHorizontallyInsadeLowerRectangle &&
                isPointVerticallyInsadeLowerRectangle;

            // dali tochkata e izvun dolniq pravougulnik horizontalno
            var isPointHorizontalyOutsideLowerRectangle =
                pointToCheckX < lowerRectangleLowerLeftPointX ||
                lowerRectangleUpperRightPointX < pointToCheckX;

            // dali tochkata e izvun dolniq pravougulnik vertikalno
            var isPointVerticallyOutsideLowerRectangle =
                pointToCheckY < lowerRectangleLowerLeftPointY ||
                lowerRectangleUpperRightPointY < pointToCheckY;


            // dali tochkata e izvun dolniq pravougulnik, 
            //trqbva da ne suvpara vertikaln ili horizontalno
            var isPointOutsideLowerRectangle =
                isPointHorizontalyOutsideLowerRectangle ||
                isPointVerticallyOutsideLowerRectangle;

            // dali tochkata e na borda na dolniq pravougulnik
            var isPointOnBorderOfLowerRectangle =
                !isPointInsadeLowerRectangle &&
                !isPointOutsideLowerRectangle;


            // zapochvame s gorniq pravougulnik :

            var isPointInsadeOfUpperRectangle = true;
            var isPointOutsideOfUpperRectangle = false;
            var isPointOnBorderOfUpperRectangle = false;

            // tova e za obshtata cherta koqto suedinqva dvata pravougulnika
            var isPointOnCommonSideOfTheRectangles =
                blockSize <= pointToCheckX &&
                pointToCheckX <= 2 * blockSize &&
                pointToCheckY == blockSize;

            //dali kato cqlo tochkata e vuv figurata
            var isPointInsadeFigure = isPointInsadeLowerRectangle ||
                isPointInsadeOfUpperRectangle ||
                isPointOnCommonSideOfTheRectangles;

            //dali kato cqlo tochkata e izvun figurata
            var isPointOutsideFigure = isPointOutsideLowerRectangle &&
                isPointOutsideOfUpperRectangle;

            //dali kato cqlo tochkata e na borda na figurata
            var isPointOnBorderOfFigure = !isPointOutsideFigure &&
                !isPointInsadeFigure;

            if (isPointInsadeFigure)
            {
                Console.WriteLine("insade");
            }
            else if (isPointOutsideFigure)
            {
                Console.WriteLine("outside");
            }
            else if (isPointOnBorderOfFigure)
            {
                Console.WriteLine("border");
            }



        }
    }
}
