using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.
            GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        decimal length = decimal.Parse(Console.ReadLine());
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());

        Box box = new Box(length, width, height);

        Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
        Console.WriteLine($"Lateral Surface Area - {box.LateralSurface():f2}");
        Console.WriteLine($"Volume - {box.Volume():f2}");


    }


}

