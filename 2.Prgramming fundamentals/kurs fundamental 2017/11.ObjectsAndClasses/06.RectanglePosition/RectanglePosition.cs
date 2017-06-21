using System;
using System.Linq;

namespace _06.RectanglePosition
{

    class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public double  Right()
        {   
                return Left + Height; // Tova go pravim na metod     
        }

        public double Bottom
        {
            get  // a tova na ger metod
            {
                return Top + Width;
            }

        }
    }

    class RectanglePosition
    {
        static void Main(string[] args)
        {

            int[] firstRect = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] secondRect = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

            var rectOne = SetRectangle(firstRect);
            var rectTwo = SetRectangle(secondRect);
            
            bool result = IsInside(rectOne, rectTwo);
            Console.WriteLine(result == true ? "Inside" : "Not inside");

        }

        private static Rectangle SetRectangle(int[] Rect)
        {
            Rectangle rect = new Rectangle()
            {
                Top = Rect[0],
                Left = Rect[1],
                Width = Rect[2],
                Height = Rect[3],            
            };

            return rect;
        }

        private static bool IsInside(Rectangle r1, Rectangle r2)
        {
            bool isInsade = false;

            if (r1.Left >= r2.Left && r1.Right() <= r2.Right() // vikame right kato funkciq, narochno taka sme go napravili
                && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
                isInsade = true;

            return isInsade;
        }
    }
}
