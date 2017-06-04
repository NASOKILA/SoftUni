using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Different_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (Math.Abs(a - b) < 5)
            {//ako mejdu dvete cisla ima po malko ot 5 chila znchi pishem "no"
                Console.WriteLine("No");
            }
            else
            {
                for (int i = a; i <= b; i++)
                {
                    for (int j = a; j <= b; j++)
                    {
                        for (int k = a; k <= b; k++)
                        {
                            for (int l = a; l <= b; l++)
                            {
                                for (int m = a; m <= b; m++)
                                {
                                    // pravim 5 cikula ot "a" do "b"

                                    if (j <= i || k <= j || l <= k || m <= l) continue;
                                    // ako edno ne otgovarq na uslovito ne pishem nishto
                                    else
                                    {
                                        Console.Write(i + " ");
                                        Console.Write(j + " ");
                                        Console.Write(k + " ");
                                        Console.Write(l + " ");
                                        Console.WriteLine(m);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
    }
}