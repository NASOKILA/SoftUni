using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MainProgram
{
    static void Main(string[] args)
    {

        var box = new Box<int>();
        var box2 = new Box<Dog>();

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("Element added: " + i);
            box.Add(i);
        }

        //za da pokajem elementite ne mojem da foreachnem prosto si pishem kutiikata
        Console.WriteLine(box); // NESHTO NE STAVA

        //sega shte premahvame 20 elements
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine("Removed element: " + box.Remove());
        }


        //shte slojim 5 obekta ot klasa Dog !!!
        for (int i = 0; i < 5; i++)
        {
            box2.Add(new Dog("Spaik" + i.ToString(), 5 + i, 35 - i));
        }
        Console.WriteLine(box2);

    }
}

