using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nai_golqmo_chislo
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiChisla = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());

            for (var i = 1; i <= broiChisla-1; i++) {

                int chislo = int.Parse(Console.ReadLine());
                if (chislo > max) { max = chislo; }
            }
            Console.WriteLine(max);

        }
    }
}
