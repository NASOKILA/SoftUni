using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_6_MaksimalenBroiKombinacii
{
    class Program
    {
        static void Main(string[] args)
        {
            int nachalo = int.Parse(Console.ReadLine());
            int krai = int.Parse(Console.ReadLine());
            int maxBroiKombinacii = int.Parse(Console.ReadLine());

            if (nachalo < 1 || nachalo > 200)
            { Console.WriteLine("Input error!"); }
            else
            {
                if(krai < nachalo || krai > 200)
                {
                    for (;;)
                    {
                        Console.WriteLine("Input error!");
                        krai = int.Parse(Console.ReadLine());
                        if (krai >= nachalo && krai < 200) { break; }
                    }
                }

                if (maxBroiKombinacii < 1 || maxBroiKombinacii > 50000) { Console.WriteLine("Input error!"); }
                else
                {

                    // OT TUK ZAPOCHVA PROGRAMATA !

                    int counter = 0;
                    for (int i = nachalo; i <= krai; i++) // 4 puti
                    {
                        for (int j = nachalo; j <= krai; j++) // 4 puti
                        {
                            if(counter == maxBroiKombinacii) { break; }
                            Console.Write("<" + i + "-" + j + ">");
                            counter++;
                        }
                        if (counter == maxBroiKombinacii) { break; }
                    }

                }

            }
        }
    }
}
