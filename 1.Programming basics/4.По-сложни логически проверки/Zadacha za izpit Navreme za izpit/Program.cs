using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Navreme_za_izpit
{
    class Program
    {
        static void Main(string[] args)
        {
            int chasZaIzpita = int.Parse(Console.ReadLine());
            int minutiZaIzpita = int.Parse(Console.ReadLine());
            int chasNaPristigane = int.Parse(Console.ReadLine());
            int minutiNaPristigane = int.Parse(Console.ReadLine());
            var Min30PrediIzpita = minutiZaIzpita - 30;

            var result1 = "";

            double ostatukChasove = 0.00;
            double ostatukMinuti = 0.00;

            if (chasZaIzpita > 23 || chasZaIzpita < 0 || chasNaPristigane > 23 || chasNaPristigane < 0 ||
               minutiNaPristigane < 0 || minutiNaPristigane > 59 || minutiZaIzpita < 0 || minutiZaIzpita > 59)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                var ravnoVreme = (chasZaIzpita == chasNaPristigane && minutiZaIzpita == minutiNaPristigane );

                var rano30min = (chasZaIzpita == chasNaPristigane && minutiZaIzpita >= (minutiNaPristigane + 30)) ||
                    ((minutiZaIzpita < 30 && minutiNaPristigane >= (60 - (30 - minutiZaIzpita)) &&
                    chasNaPristigane == (chasZaIzpita - 1)));

                var ranoNad30min = ((chasZaIzpita == chasNaPristigane && minutiNaPristigane < (minutiZaIzpita - 30)) ||
                    (chasNaPristigane < chasZaIzpita) || (chasNaPristigane < chasZaIzpita && minutiZaIzpita < 30 &&
                    minutiNaPristigane < (60 - (30 - minutiZaIzpita))));










                if (chasNaPristigane > chasZaIzpita ||
                    (chasNaPristigane == chasZaIzpita && minutiNaPristigane > minutiZaIzpita))
                {
                    result1 = "Late";
                    if (minutiNaPristigane == 0) { minutiNaPristigane = 60; }
                    ostatukMinuti = minutiNaPristigane - minutiZaIzpita;
                    ostatukChasove = chasNaPristigane - chasZaIzpita;
                    ostatukMinuti = Math.Abs(ostatukMinuti);

                    if (chasZaIzpita < chasNaPristigane && minutiZaIzpita > minutiNaPristigane)
                    {
                        ostatukChasove--;
                        ostatukMinuti = 60 - ostatukMinuti;
                        if (ostatukChasove == 0) { Console.WriteLine(result1); Console.WriteLine("{0} minutes after the start", ostatukMinuti); }
                        else
                        {
                            Console.WriteLine(result1);
                            Console.WriteLine("{0}:{1} hours after the start", ostatukChasove, ostatukMinuti);
                        }
                    }
                    else if (chasZaIzpita < chasNaPristigane && minutiZaIzpita < minutiNaPristigane)
                    {
                        Console.WriteLine(result1);
                        Console.WriteLine("{0}:{1} hours after the start", ostatukChasove, ostatukMinuti);
                    }
                    else if (chasZaIzpita == chasNaPristigane)
                    {

                        Console.WriteLine(result1);
                        Console.WriteLine("{0} minutes after the start", ostatukMinuti);
                    }
                }





                else if (ravnoVreme || rano30min)
                {

                    

                    result1 = "On time";

                    
                    if (chasZaIzpita == chasNaPristigane && minutiNaPristigane == minutiZaIzpita) { Console.WriteLine(result1); }

                    if (minutiZaIzpita == 0) { minutiZaIzpita = 60; }
                    ostatukMinuti = minutiZaIzpita - minutiNaPristigane;
                    ostatukMinuti = Math.Abs(ostatukMinuti);

                    if ((chasZaIzpita == chasNaPristigane && minutiNaPristigane == minutiZaIzpita))
                    {
                        Console.WriteLine(result1);
                    }
                    else if ((chasZaIzpita == chasNaPristigane && minutiNaPristigane == (minutiZaIzpita - 30)) ||
                    (chasNaPristigane == (chasZaIzpita - 1) && minutiNaPristigane == (60 - ostatukMinuti)))
                    {

                        Console.WriteLine(result1);
                        Console.WriteLine("{0} minutes before the start", ostatukMinuti);
                    }
                    
                }


                else if (ranoNad30min)
                {
                    ostatukChasove = chasZaIzpita - chasNaPristigane;
                    ostatukMinuti = minutiZaIzpita - minutiNaPristigane;
                    ostatukMinuti = Math.Abs(ostatukMinuti);
                    ostatukChasove = Math.Abs(ostatukChasove);

                    if (chasNaPristigane < chasZaIzpita && minutiZaIzpita < 30)
                    {
                        ostatukMinuti = (60 - minutiNaPristigane) + minutiZaIzpita;
                    }
                    if (minutiZaIzpita == 30) { ostatukMinuti = 60 - minutiNaPristigane; }

                    result1 = "Early";
                    Console.WriteLine(result1);

                    if (!(chasZaIzpita == chasNaPristigane))
                    {

                        if (ostatukMinuti == 60)
                        {
                            ostatukMinuti = 0;
                            Console.WriteLine("{0}:0{1} hours before the start", ostatukChasove, ostatukMinuti);
                        }


                        else if (chasNaPristigane == (chasZaIzpita - 1) && ostatukMinuti <= 30)
                        {

                            if (minutiNaPristigane > minutiZaIzpita ) {

                                ostatukMinuti = 30 + ostatukMinuti;
                            }
                            Console.WriteLine("{0} minutes before the start", ostatukMinuti);
                        }       


                            else if (chasZaIzpita > chasNaPristigane && minutiZaIzpita > minutiNaPristigane) {

                            ostatukMinuti = minutiZaIzpita - minutiNaPristigane;
                            Console.WriteLine("{0}:{1} hours before the start", ostatukChasove, ostatukMinuti);
                        }
                        else
                        {

                            Console.WriteLine("{0}:{1} hours before the start", ostatukChasove, ostatukMinuti);
                        }
                    }
                    else
                    {

                        Console.WriteLine("{0} minutes before the start", ostatukMinuti);
                    }
                }

            }

        }
    }
}