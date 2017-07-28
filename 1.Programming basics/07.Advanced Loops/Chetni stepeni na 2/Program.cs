using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chetni_stepeni_na_dve
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int num = 1;
            int count = 0;

            
            while (count <= n)         //for (var i = 1; i <= n; i+=2){}  i taka stava
            {
                
                
                Console.WriteLine(num);
                num = num * 2 * 2;
                count += 2;
            }




        }
    }
}
