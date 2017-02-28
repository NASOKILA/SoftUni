using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_1_Razstoqnie
{
    class Program
    {
        static void Main(string[] args)
        {

            int purvonachalnaSkorost = int.Parse(Console.ReadLine());
            int purvoVreme = int.Parse(Console.ReadLine());
            int vtoroVreme = int.Parse(Console.ReadLine());
            int tretoVreme = int.Parse(Console.ReadLine());

            double purvoVremeVChasove = purvoVreme / 60.00;
            double vtoroVremeVChasove = vtoroVreme / 60.00;
            double tretoVremeVChasove = tretoVreme / 60.00;

            double razstoqnieSPurvonachalnaSkorost = 0.00;
            double sledUvelichavaneto = purvonachalnaSkorost + (purvonachalnaSkorost / 10); // + 10%   
            double sledNamalqvaneto = sledUvelichavaneto - (sledUvelichavaneto / 20); // - 5%   

            razstoqnieSPurvonachalnaSkorost = purvonachalnaSkorost * purvoVremeVChasove; // purvo vreme                 
            sledUvelichavaneto = sledUvelichavaneto * vtoroVremeVChasove; // vtoro vreme               
            sledNamalqvaneto = sledNamalqvaneto * tretoVremeVChasove; // treto vreme                   

            double izminaliKilometri = razstoqnieSPurvonachalnaSkorost + sledUvelichavaneto + sledNamalqvaneto;

            Console.WriteLine("{0:f2}",izminaliKilometri);

        }
    }
}
