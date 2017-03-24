using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_rectangle_area
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x1 = ");
            var x1 = double.Parse(Console.ReadLine());
            Console.Write("y1 = ");
            var y1 = double.Parse(Console.ReadLine());
            Console.Write("x2 = ");
            var x2 = double.Parse(Console.ReadLine());
            Console.Write("y2 = ");
            var y2 = double.Parse(Console.ReadLine());

            var  width = Math.Max(x1,x2) - Math.Min(x1,x2); // Math.Max(a,b) vzima nai golqmoto ot dvete chisla a Math.Min() vzima nai malkoto
            var  height = Math.Max(y1,y2) - Math.Min(y1,y2); 

            var plosht = (width*height);
            var perimetur = 2 * (width + height);
            Console.WriteLine("Plosht = {0}", plosht);
            Console.WriteLine("Perimetur = {0}", perimetur);

        }
    }
}
