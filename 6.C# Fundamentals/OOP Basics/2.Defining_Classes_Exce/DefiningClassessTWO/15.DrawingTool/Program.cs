﻿using System;
class Program
{
    static void Main(string[] args)
    {
        string command = Console.ReadLine();

        if (command == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            CorDraw cor = new CorDraw(new Square(size));
            cor.square.Draw();
        }
        else if (command == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            CorDraw cor = new CorDraw(new Rectangle(width, height));
            cor.rectangle.Draw();
        }
    }
}

