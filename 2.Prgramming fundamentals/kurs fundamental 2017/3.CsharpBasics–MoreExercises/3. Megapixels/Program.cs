using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            double resut = width * height;
            resut = resut / 1000000;  
            Console.WriteLine($"{width}x{height} => {Math.Round(resut,1)}MP");
        }
    }
}
