using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kushtichka
{
    class Program
    {
        static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());    
            var raz = 0;
            var zv = 0;
            var gorenCikul = 0;
            var dolenCikul = 0;
            if (n % 2 == 1)  // pri n nechetno
            {
                zv = 1;
                raz = (n - 1) / 2;
                gorenCikul = (n + 1) / 2;
                dolenCikul = (n - 1) / 2;
            }
            else if (n % 2 == 0) // pri n chetno
            {
                raz = (n / 2) - 1;
                zv = 2;
                gorenCikul = n / 2;
                dolenCikul = n / 2;
            }

            for (int i = 1; i <= gorenCikul; i++) // pokriv
            {
                Console.Write(new string('-', raz));
                Console.Write(new string('*', zv));
                Console.WriteLine(new string('-', raz));

                zv += 2;
                raz -= 1;
            }

            for (int i = 0; i < dolenCikul; i++)  // dolna chast
            {
                Console.Write("|");
                Console.Write(new string('*', (n - 2)));
                Console.WriteLine("|");

            }
        }
    }
}
        