using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacah_za_izpit_Zelenchukova_borsa
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Cena v lv na kg zelenchuci : ");
            var cenaLvNaKgZelenchuci = double.Parse(Console.ReadLine());
            Console.WriteLine("Cena v lv na kg plodove : ");
            var cenaLvNaKgPlodove = double.Parse(Console.ReadLine());
            Console.WriteLine("kg na zelenchuci : ");
            var KgZelenchuci = double.Parse(Console.ReadLine());
            Console.WriteLine("kg na plodove : ");
            var KgPlodove = double.Parse(Console.ReadLine());

            int cenaLvNaKgPlodove2 = (int)cenaLvNaKgPlodove;
            int cenaLvNaKgZelenchuci2 = (int)cenaLvNaKgZelenchuci;

            if ((cenaLvNaKgPlodove2 < 0 || cenaLvNaKgPlodove2 > 1000) || (cenaLvNaKgZelenchuci2 < 0 || cenaLvNaKgZelenchuci2 > 1000) || (KgPlodove < 0 || KgPlodove > 1000) || (KgZelenchuci < 0 || KgZelenchuci > 1000)) {
       
                Console.WriteLine("Error! Chislata trqbva da sa mejdu 0 i 1000!");
             
            }
            else {
                double prihodiLvZelenchuci = cenaLvNaKgZelenchuci * KgZelenchuci;
                double prihodiLvPlodove = cenaLvNaKgPlodove * KgPlodove;

                double prihodiLv = prihodiLvPlodove + prihodiLvZelenchuci;
                double prihodiEvro = prihodiLv / 1.94;

                Console.WriteLine(prihodiEvro);
            }


        }
    }
}
