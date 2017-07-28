using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectanglePosition
{
    public class Rectangle
    {
        public int Top { set; get; }

        public int Left { set; get; }

        public int Width { set; get; }

        public int Height { set; get; }

        public int Bottom { set; get; }

        public int Right { set; get; }

        //public int Bottom => Top - Height; // Bottom se smqta taka Top - Heigth
        ///*
        // Tova e READ ONLY PROPERTY I NE MOJEM DA GO PREZAPISVAME,
        // NO TO SE IZCHISLQVA T:E: RABOTI SI.
        // public int Bottom()
        // { 
        // return Top - Heigth;
        // }

        //  */

        //public int Right => Width + Left;


        //public int Area => Width - Height;



        ////PRIMERNO
        ////rectangle.Bottom = 100   PAK NE STAVA TO E READ ONLY

        ////NO MOJEM DA GO IZPOZVAME V Console.ReadLine(rectangle.Bottom)


    }
}
