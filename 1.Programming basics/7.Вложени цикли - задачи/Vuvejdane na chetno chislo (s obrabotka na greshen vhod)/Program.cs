using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuvejdane_na_chetno_chislo__s_obrabotka_na_greshen_vhod_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter even number: ");         

            while (true)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    if (n % 2 == 0) { Console.WriteLine("The number entered: {0}", n); break; }
                    // pri chetno chislo izlizame ot cikula

                    else if (!(n % 2 == 0))// pri nechetno chislo vuvejdame na novo 
                    {
                        Console.WriteLine("The number is not even.");
                        Console.WriteLine("Enter even number: ");
                        continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid number!");  // ako se schupi neshto da produljava na novo
                    continue;
                }
            }
            
        }
    }
}
