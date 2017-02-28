using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metric_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            //AKO EDIN STRING E NAPISAN S GOLQMI BUKVI  ToLower(str) GO PREOBRAZUVA DA E S MALKI, ToUpper() E OBRATNOTO !!!

            /*DEBUGVANETO E MNOGO VAJNO I MNOGO POMAGA !!!   otvarqsh v meniuto : degug + windols + locals ili   ctrl+alt+V+L
            s   F10 se hoidi na pred !!!*/
            double numInMeters = double.Parse(Console.ReadLine());
            string vhod = Console.ReadLine().ToLower();
            string izhod = Console.ReadLine().ToLower();

            var mm = numInMeters * 1000;
            var cm = numInMeters * 100;
            var mi = numInMeters * 0.000621371192;
            var In = numInMeters * 39.3700787;
            var km = numInMeters * 0.001;
            var ft = numInMeters * 3.2808399;
            var yd = numInMeters * 1.0936133;

            if (vhod == "mm")
            {
                if (izhod == "mm") { Console.WriteLine(numInMeters * (mm / mm) + " " + izhod ); }
                else if (izhod == "cm") { Console.WriteLine(numInMeters * (cm / mm) + " " + izhod); }
                else if (izhod == "mi") { Console.WriteLine(numInMeters * (mi / mm) + " " + izhod); }
                else if (izhod == "In") { Console.WriteLine(numInMeters * (In / mm) + " " + izhod); }
                else if (izhod == "km") { Console.WriteLine(numInMeters * (km / mm) + " " + izhod); }
                else if (izhod == "ft") { Console.WriteLine(numInMeters * (ft / mm) + " " + izhod); }
                else if (izhod == "yd") { Console.WriteLine(numInMeters * (yd / mm) + " " + izhod); }
            }
            if (vhod == "cm")
            {
                if (izhod == "mm") { Console.WriteLine(numInMeters * (mm / cm) + " " + izhod); }
                else if (izhod == "cm") { Console.WriteLine(numInMeters * (cm / cm) + " " + izhod); }
                else if (izhod == "mi") { Console.WriteLine(numInMeters * (mi / cm) + " " + izhod); }
                else if (izhod == "In") { Console.WriteLine(numInMeters * (In / cm) + " " + izhod); }
                else if (izhod == "km") { Console.WriteLine(numInMeters * (km / cm) + " " + izhod); }
                else if (izhod == "ft") { Console.WriteLine(numInMeters * (ft / cm) + " " + izhod); }
                else if (izhod == "yd") { Console.WriteLine(numInMeters * (yd / cm) + " " + izhod); }
            }
            if (vhod == "mi")
            {
                if (izhod == "mm") { Console.WriteLine(numInMeters * (mm / mi) + " " + izhod); }
                else if (izhod == "cm") { Console.WriteLine(numInMeters * (cm / mi) + " " + izhod); }
                else if (izhod == "mi") { Console.WriteLine(numInMeters * (mi / mi) + " " + izhod); }
                else if (izhod == "In") { Console.WriteLine(numInMeters * (In / mi) + " " + izhod); }
                else if (izhod == "km") { Console.WriteLine(numInMeters * (km / mi) + " " + izhod); }
                else if (izhod == "ft") { Console.WriteLine(numInMeters * (ft / mi) + " " + izhod); }
                else if (izhod == "yd") { Console.WriteLine(numInMeters * (yd / mi) + " " + izhod); }
            }
            if (vhod == "In")
            {
                if (izhod == "mm") { Console.WriteLine(numInMeters * (mm / In) + " " + izhod); }
                else if (izhod == "cm") { Console.WriteLine(numInMeters * (cm / In) + " " + izhod); }
                else if (izhod == "mi") { Console.WriteLine(numInMeters * (mi / In) + " " + izhod); }
                else if (izhod == "In") { Console.WriteLine(numInMeters * (In / In) + " " + izhod); }
                else if (izhod == "km") { Console.WriteLine(numInMeters * (km / In) + " " + izhod); }
                else if (izhod == "ft") { Console.WriteLine(numInMeters * (ft / In) + " " + izhod); }
                else if (izhod == "yd") { Console.WriteLine(numInMeters * (yd / In) + " " + izhod); }
            }
            if (vhod == "km")
            {
                if (izhod == "mm") { Console.WriteLine(numInMeters*(mm/km) + " " + izhod); }
                else if (izhod == "cm") { Console.WriteLine(numInMeters*(cm/km) + " " + izhod); }
                else if (izhod == "mi") { Console.WriteLine(numInMeters*(mi/km) + " " + izhod); }
                else if (izhod == "In") { Console.WriteLine(numInMeters*(In/km) + " " + izhod); }
                else if (izhod == "km") { Console.WriteLine(numInMeters*(km/km) + " " + izhod); }
                else if (izhod == "ft") { Console.WriteLine(numInMeters*(ft/km) + " " + izhod); }
                else if (izhod == "yd") { Console.WriteLine(numInMeters*(yd/km) + " " + izhod); }
             }
                if (vhod == "ft")
                {
                    if (izhod == "mm") { Console.WriteLine(numInMeters * (mm / ft) + " " + izhod); }
                    else if (izhod == "cm") { Console.WriteLine(numInMeters * (cm / ft) + " " + izhod); }
                    else if (izhod == "mi") { Console.WriteLine(numInMeters * (mi / ft) + " " + izhod); }
                    else if (izhod == "In") { Console.WriteLine(numInMeters * (In / ft) + " " + izhod); }
                    else if (izhod == "km") { Console.WriteLine(numInMeters * (km / ft) + " " + izhod); }
                    else if (izhod == "ft") { Console.WriteLine(numInMeters * (ft / ft) + " " + izhod); }
                    else if (izhod == "yd") { Console.WriteLine(numInMeters * (yd / ft) + " " + izhod); }
                }
                if (vhod == "yd")
                {
                    if (izhod == "mm") { Console.WriteLine(numInMeters * (mm / yd) + " " + izhod); }
                    else if (izhod == "cm") { Console.WriteLine(numInMeters * (cm / yd) + " " + izhod); }
                    else if (izhod == "mi") { Console.WriteLine(numInMeters * (mi / yd) + " " + izhod); }
                    else if (izhod == "In") { Console.WriteLine(numInMeters * (In / yd) + " " + izhod); }
                    else if (izhod == "km") { Console.WriteLine(numInMeters * (km / yd) + " " + izhod); }
                    else if (izhod == "ft") { Console.WriteLine(numInMeters * (ft / yd) + " " + izhod); }
                    else if (izhod == "yd") { Console.WriteLine(numInMeters * (yd / yd) + " " + izhod); }
                }
            }
        }
    }
