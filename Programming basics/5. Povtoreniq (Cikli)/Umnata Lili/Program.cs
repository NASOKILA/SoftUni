using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umnata_Lili
{
    class Program
    {
        static void Main(string[] args)
        {

            int godiniLili = int.Parse(Console.ReadLine());
            double cenaPeralniq = double.Parse(Console.ReadLine());
            int cenaNaIgrachka = int.Parse(Console.ReadLine());

            var polucheniIgrachki = 0.00;
            var polucheniPari = 0.00;
            var spesteniPari = 0.00;
           

            for (var i = 1; i<=godiniLili; i++) {

                if (i % 2 == 1)                     
                {
                    //za nechetni godini
                    polucheniIgrachki++;
                }
                else {
                    //za chetni godini
                    polucheniPari = polucheniPari + 10;                    
                    spesteniPari += polucheniPari;
                    spesteniPari--;

                }

            }
            
            spesteniPari += polucheniIgrachki * cenaNaIgrachka; // Lili prodava igrachkite i spestqva parite


            if (godiniLili < 1 || godiniLili > 77
                || cenaPeralniq < 1.00 || cenaPeralniq > 10000.00
                || cenaNaIgrachka < 0 || cenaNaIgrachka > 40) { Console.WriteLine("Error!"); }
            else
            {

                if (spesteniPari >= cenaPeralniq)
                {

                    var ostatuk = spesteniPari - cenaPeralniq;
                    Console.WriteLine("Yes! {0:f2}", ostatuk);
                }
                else
                {
                    var nedostatuk = cenaPeralniq - spesteniPari;
                    Console.WriteLine("No! {0:f2}", nedostatuk);

                }

            }
        }
    }
}
