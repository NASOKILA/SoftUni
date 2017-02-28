using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figura = Console.ReadLine().ToLower();
            double area = 0.00;


            if (figura == "square") {
                double duljinaNaStrana = double.Parse(Console.ReadLine());
                area = duljinaNaStrana * duljinaNaStrana;

            }
            else if (figura == "rectangle")
            {
                double strana1 = double.Parse(Console.ReadLine());
                double strana2 = double.Parse(Console.ReadLine());
                area = strana1 * strana2;
            }
            else if (figura == "circle")
            {
                double radius= double.Parse(Console.ReadLine());
                area = Math.PI * radius * radius;
            }
            else if (figura == "triangle")
            {
                double duljinaNaStrana2 = double.Parse(Console.ReadLine());
                double duljinaNaVisochinaNaStrana = double.Parse(Console.ReadLine());
                area = (duljinaNaStrana2 * duljinaNaVisochinaNaStrana)/ 2;

            }
            Console.WriteLine(Math.Round(area, 3));


        }
    }
}
