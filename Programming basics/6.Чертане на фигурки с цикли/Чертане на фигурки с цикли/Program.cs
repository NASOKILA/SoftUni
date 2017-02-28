using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Чертане_на_фигурки_с_цикли
{
    class Program
    {
        static void Main(string[] args)
        {

            var text = new string('*',5);
            /*new e ot OOP, string e text, 
              ('*',5)  v sluchaq * e v '' znachi e sinvol,
              s 5 mu kazvame da go otpechata 5 puti !!!
             
            shte izvede:   *****
             */
            Console.WriteLine(text);

            /* v  '' se priema samo edinichen sinvol, nemoje da 
             slagame string ili nqkolko sinvola IMP !!!*/

            var text2 = new string('*', 0); // shte dade prazen str i shte mine na nov red
            // var text3 = new string('*', -1); // shte dade greshka


            for (var i = 0; i <= 10; i++){
                var text4 = new string('*', i);
                Console.WriteLine(text4);
            }

            Console.WriteLine("");

            int num = int.Parse(Console.ReadLine());
            for (var i = 1; i<=num;i++) {
                var text5 = new string('*', num);
                Console.WriteLine(text5);
            }

            Console.WriteLine("");

            // Vlojen cikul oznachava cikul v cikul

            for (int row = 1; row <= 5; row++) {

                for (int col = 1; col <= 5; col++) {

                    Console.WriteLine("i = {0}, j = {1}",row,col);
                }
            } // SUS CTRL + R SE SMENQVAT IMENATA NA VSICHKI PROMENLIVI S EDNAKVO IMA EDNOVREMENNO



            Console.WriteLine("");

            // shte napravim kvadrat n na n sus vlijen cikul

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }

        }
    }
}
