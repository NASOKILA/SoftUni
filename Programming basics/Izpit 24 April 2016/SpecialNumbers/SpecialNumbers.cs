using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i < 10000; i++)
            {

                
                bool isSpecial = true;
                int number = i;
                
                for (int j = 0; j < 4; j++) // we need to check every digit
                {
                    
                    int num = number % 10;
                    if (num.Equals(0))               // ako e 0 breikvame
                    {
                        isSpecial = false;
                        break;
                    }
                        if (!(n % num == 0))
                        {
                            isSpecial = false;
                            break;
                        }
                      
                    
                    number = number / 10;
                }

                if(isSpecial)
                    Console.Write(i + " ");
                
            }

        }
    }
}
