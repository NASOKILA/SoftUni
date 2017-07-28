using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Generator_na_tupi_paroli
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());



            if (n < 1 || n > 9 || l < 1 || l > 9) { Console.WriteLine("Input Error!"); }
            else
            {

                string a = "";

                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        
                        for (char h = (char)97; h < (char)97 + l; h++)
                        {
                            for (char g = (char)97; g < (char)97 + l; g++)
                            {
                         
                                for (int k = Math.Max(i, j) + 1; k <= n; k++)// k = 4    a    n = 3   i zatova ne trugva posledniq put
                                {/* polzvame Math.Max(i, j)  mejdu i   i   j  za da nameri nai golqmoto mejdu tqh takache 2 i 2 dava 2 
                                    dobavqme + 1, SLEDOVATELNO ZA NAKRAQ stava 3, a ne 4 ! I RABOTI !!! */ 

                                    
                                        Console.Write("{0}{1}{2}{3}{4}", i, j, h, g, k + " ");
                                }
                            }
                        }
                    }
                }
                
                              
            }

        }
    }
}
