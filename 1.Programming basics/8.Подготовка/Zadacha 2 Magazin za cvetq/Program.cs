using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_2_Magazin_za_cvetq
{
    class Program
    {
        static void Main(string[] args)
        {

            int broiMagnoli = int.Parse(Console.ReadLine());
            int broiZiumbiuli = int.Parse(Console.ReadLine());
            int broiRozi = int.Parse(Console.ReadLine());
            int broiKaktosi = int.Parse(Console.ReadLine());
            double cenaPodaruk = double.Parse(Console.ReadLine());

            double sumaOtPoruchkata = 0.00;
            double ostanaliPari = 0.00;
            double nedostigashtiPari = 0.00;

            double obshtaCenaMagnoli = broiMagnoli * 3.25;
            double obshtaCenaZiumbiuli = broiZiumbiuli * 4.00;
            double obshtaCenaRozi = broiRozi * 3.50;      
            double obshtaCenaKaktosi = broiKaktosi * 8.00;

            sumaOtPoruchkata = obshtaCenaMagnoli + obshtaCenaZiumbiuli +
                obshtaCenaRozi + obshtaCenaKaktosi;

            sumaOtPoruchkata = sumaOtPoruchkata - (sumaOtPoruchkata / 20);// -5% za danuci

            ostanaliPari =  sumaOtPoruchkata - cenaPodaruk;
            nedostigashtiPari = cenaPodaruk - sumaOtPoruchkata;

            if (cenaPodaruk <= sumaOtPoruchkata)
            {
                Console.WriteLine("She is left with {0} leva.", Math.Floor(ostanaliPari));
            }
            else if(cenaPodaruk > sumaOtPoruchkata)
            {
                Console.WriteLine("She will have to borrow {0} leva.",Math.Ceiling(nedostigashtiPari));
            }
             

        }
    }
}
