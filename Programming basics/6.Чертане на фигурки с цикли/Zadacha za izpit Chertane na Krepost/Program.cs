using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_izpit_Chertane_na_Krepost
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = int.Parse(Console.ReadLine());

            if (n < 3 || n > 1000) { Console.WriteLine("Error!"); }
            else
            {

                var width = 2 * n;
                var height = n;
                var shirinaNaKolkoni = n / 2;

                char character = (char)92; //   tova e tozi znak "\"
                char character2 = (char)124; //   |


                var sredniChertichki = (n / 2) - 2;
                var raztoqniqVSredataNaKushtata = n + (n / 2);

                if (n % 2 == 1)
                {// ako n e nechetno 
                    raztoqniqVSredataNaKushtata = n + ((n - 1) / 2);
                    shirinaNaKolkoni = (n - 1) / 2;
                    sredniChertichki = ((n + 1) / 2) - 2;
                }



                for (int i = 1; i <= 2; i++) // gorna chast
                {
                    Console.Write("/");
                    Console.Write(new string('^', shirinaNaKolkoni));
                    Console.Write(character); //   \ 
                    if (i == 1) { Console.Write(new string('_', sredniChertichki*2)); };
                }
                Console.WriteLine();

                for (int i = 0; i < n - 2; i++) // sredna chast
                {
                    if (i == n - 3 && n>4)
                    {
                        if (n%2==1) {
                            Console.Write(character2); //   |
                            Console.Write(new string(' ', shirinaNaKolkoni +1));
                            Console.Write(new string('_', sredniChertichki*2));
                            Console.Write(new string(' ', shirinaNaKolkoni + 1));
                            Console.WriteLine(character2); //   |
                        }
                        else if (n%2==0) {
                            Console.Write(character2); //   |
                            Console.Write(new string(' ', shirinaNaKolkoni + 1));
                            Console.Write(new string('_', sredniChertichki*2));
                            Console.Write(new string(' ', shirinaNaKolkoni + 1));
                            Console.WriteLine(character2); //   |
                        }

                     } 
                    else // tova e za n = 3 ili 4
                    {   

                        Console.Write(character2); //   |
                        Console.Write(new string(' ', (width-2 )));                        
                        Console.WriteLine(character2); //   |
                    }
                }

                for (int i = 1; i <= 2; i++)     // dolna chast
                {
                    Console.Write(character); //   \ 
                    Console.Write(new string('_', shirinaNaKolkoni));
                    Console.Write("/");
                    if (i == 1) { Console.Write(new string(' ', sredniChertichki*2)); };
                }
                Console.WriteLine();

            }
            // CTRL + K + T    NI PODREJDA KODA
        }
    }
}
