using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosti_Presmqtaniq
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello");
            Console.Write("world");

            Console.WriteLine();

            Console.Write("Hello");
            Console.WriteLine("C sharp");    // tuk e zaedno Console.WriteLine(); minava na nov red sled izpulnenieto mu

            Console.WriteLine();




            // Chetene na chisla ot konzolata
            Console.Write("a =");
            var a = int.Parse(Console.ReadLine()); // Vuvejdame chislo ot konzolata ako ne go parsnem shte go smqta za string
            Console.Write("square of a = ");
            var square = a * a;
            Console.WriteLine(square); // cw+tab+tab               // ZA ARGUMENTIRANE SELEKTIRAME I CTRL+K+C

            var area = Math.Pow(a,2); // I TAKA STAVA
            Console.Write("with Math.Pow() : ");
            Console.WriteLine(area); 
        }
    }
}
