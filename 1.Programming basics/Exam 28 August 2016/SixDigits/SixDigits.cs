using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixDigits
{
    class SixDigits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] num = n.ToString().ToCharArray();

            if (n < 100 && n > 999)
                return;

            int newNum = n;
            int forOne = int.Parse(num[0].ToString()) + int.Parse(num[1].ToString());
            int forTwo = int.Parse(num[0].ToString()) + int.Parse(num[2].ToString());


            for (int i = 0; i < forOne; i++)
            {

                for (int j = 0; j < forTwo; j++)
                {

                    if (newNum % 5 == 0)
                        newNum = newNum - int.Parse(num[0].ToString());
                    else if (newNum % 3 == 0)
                        newNum = newNum - int.Parse(num[1].ToString());
                    else
                        newNum = newNum + int.Parse(num[2].ToString());

                    Console.Write(newNum + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
