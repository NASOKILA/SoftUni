using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sumirane_na_cifrite_na_chislo
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int oldNum = num;
            int result = 0;
            int chislo = 0;
                                               
            while (true)
            {
                chislo = num % 10;  // namirame poslednata cifra  ot num      
                result += chislo; // vkarvame q v result  
                num = num / 10; // mahame poslednata cifra              
                if (num == 0) { break; }
            }
            Console.WriteLine(result);



        }
    }
}
