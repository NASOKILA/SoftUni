using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int sustezatel1 = int.Parse(Console.ReadLine());
            int sustezatel2 = int.Parse(Console.ReadLine());
            int sustezatel3 = int.Parse(Console.ReadLine());
            if ((sustezatel1 < 1 || sustezatel1 > 50) || (sustezatel2 < 1 || sustezatel2 > 50) || (sustezatel3 < 1 || sustezatel3 > 50))
            {
                Console.WriteLine("Error! Numbers must be 1...50 !");
            }
            else {
                int obshtovreme = sustezatel1 + sustezatel2 + sustezatel3;
                if (obshtovreme >= 0 && obshtovreme < 60) {
                    if (obshtovreme >= 0 && obshtovreme < 10)
                    {
                        Console.WriteLine("0:0" + obshtovreme);
                    }
                    else
                    {
                        Console.WriteLine("0:" + obshtovreme);
                    }
                }
                if (obshtovreme >= 60 && obshtovreme < 120)
                { //primer 30+20+15= 65s  =  1m i 05s
                    if (obshtovreme >= 60 && obshtovreme < 70) { Console.WriteLine("1:0" + (obshtovreme-60)); }
                    else
                    {
                        Console.WriteLine("1:" + (obshtovreme - 60));
                    }
                }
                if (obshtovreme >= 120 && obshtovreme < 180) {
                    if (obshtovreme >= 120 && obshtovreme < 130)
                    {
                        Console.WriteLine("2:0" + (obshtovreme - 120));
                    }
                    else
                    {
                        Console.WriteLine("2:" + (obshtovreme - 120));
                    }
                }
            }
        }
    }
}
