using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanglePosition
{
    class RectanglePosition
    {
        static void Main(string[] args)
        {
            int[] rectOnePoints = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();

            Rectangle rectangleOne = new Rectangle
            {
                Top = rectOnePoints[1],    //-5
                Left = rectOnePoints[0],   // 4
                Width = rectOnePoints[2],  // 6 
                Height = rectOnePoints[3], // 10
                
                 //Bottom = ...  NE RABOTI TO E READ ONLY
                 //napravihme si dadenite tochki
            };

            rectangleOne.Bottom = Math.Abs(rectangleOne.Top) - rectangleOne.Height; // 5
            rectangleOne.Bottom = Math.Abs(rectangleOne.Bottom);

            rectangleOne.Right= rectangleOne.Width + rectangleOne.Left;  // 10



            int[] rectTwoPoints = Console.ReadLine()
                .Split(' ').Select(int.Parse).ToArray();

            Rectangle rectangleTwo = new Rectangle
            {
                Top = rectTwoPoints[1],
                Left = rectTwoPoints[0],
                Width = rectTwoPoints[2],
                Height = rectTwoPoints[3],

                // Bottom = ...  NE RABOTI TO E READ ONLY
                // napravihme si dadenite tochki
            };

       //     if()
            rectangleTwo.Bottom = Math.Abs(rectangleTwo.Top) - rectangleTwo.Height;
            rectangleTwo.Bottom = Math.Abs(rectangleTwo.Bottom);

            rectangleTwo.Right = rectangleTwo.Width + rectangleTwo.Left;


            var result = FirstInsadeSecond(rectangleOne, rectangleTwo).ToString(); // vkarvame i dvate pravougulnika i pravim otgovora da e tiString()

            if(result == "False")
                Console.WriteLine("Not inside");
            else
                Console.WriteLine("Inside");
        }



        public static bool FirstInsadeSecond(  // proverqvame dali ediniq e v drugiq
            Rectangle first,
            Rectangle second)
        {
            var leftIsCorrect = first.Left >= second.Left;
            var rightIsCorrect = first.Right <= second.Right;
            var bottomIsCorrect = first.Bottom <= second.Bottom;
            var topIsCorrect = first.Top <= second.Top;

            return leftIsCorrect && rightIsCorrect && bottomIsCorrect && topIsCorrect;
        }

    }
}
