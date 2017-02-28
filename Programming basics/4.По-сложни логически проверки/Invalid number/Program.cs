using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invalid_number
{
    class Program
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            if(!((num >= 100 && num <= 200) || num == 0)){
                Console.WriteLine("invalid");
            }
        }
    }
}
