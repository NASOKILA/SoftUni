using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Цена_за_транспорт
{
    class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string denIliNosht = Console.ReadLine().ToLower();

            if (km < 0 || km > 5000)
            {
                Console.WriteLine("ERROR !");
            }
            else
            {

                double nachalnaTsksaTaxy = 0.70;
                double dnevnaTarifaTaxy = 0.79;
                double noshtnaTarifaTaxy = 0.90;
                double avtobusObshtaTarifa = 0.09;
                double vlakObshtaTarifa = 0.06;

                double result = 0.0;
                if (km < 20 && denIliNosht == "day")
                {
                    // 0.70 + km * 0.79;
                    result = nachalnaTsksaTaxy + (km * dnevnaTarifaTaxy);
                }
                else if (km < 20 && denIliNosht == "night")
                {
                    // 0.70 + km * 0.90;
                    result = nachalnaTsksaTaxy + (km * noshtnaTarifaTaxy);
                }
                else if (km >= 20 && km < 100)
                {
                    // km * 0.09;
                    result = km * avtobusObshtaTarifa;
                }
                else if (km >= 100 && km < 5001)
                {
                    // km * 0.09;
                    result = km * vlakObshtaTarifa;
                }

                Console.WriteLine(result);
            }
        }
    }
}
