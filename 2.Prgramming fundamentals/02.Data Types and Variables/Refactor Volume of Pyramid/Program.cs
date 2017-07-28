using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            /*You are given a working code that finds the volume of a pyramid. However, you should consider that the
            variables exceed their optimum span and have improper naming. Also, search for variables that have
            multiple purpose.*/

            
            Console.Write("Length: ");
            double lenght = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());

            double volume = (lenght * width * height) / 3;   // tova e formulata !!!
        
            Console.WriteLine( "Pyramid Volume: {0:f2}",volume);

            /*Reduce the span of the variables by declaring them in the moment they receive a value, not before
            Rename your variables to represent their real purpose 
            Search for variables that have multiple purpose. If you find any, introduce a new variable.*/

        }
    }
}
