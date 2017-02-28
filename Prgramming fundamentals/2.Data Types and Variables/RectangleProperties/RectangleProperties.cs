using System;


namespace RectangleProperties
{
    public class RectangleProperties
    {
        public static void Main(string[] args)
        {

            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            // perimeter =2(h + w)    area = h * w
            // diagonal = koren kvadraten ot hna vtora + w na vtora 
            // squrt ni dava koren kvadraten a pow povdiga na podadenata stepen


            double perimeter = 2 * (height + width);
            double area = (double)(width * height);
            double diagonal = (double)(Math.Sqrt(Math.Pow(height,2) + Math.Pow(width,2)));
            
            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);

        }
    }
}
