using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vlojeni_cikli
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i+=3)   // tuk cikula vurti prez tri
            {
                Console.WriteLine(i);
            }


            // chisla ot 1 do 2 na nta stepen s for cikul :

            int stepen = int.Parse(Console.ReadLine());
            int num = 1;
            for (int i = 0; i <= stepen; i++)
            {
                Console.WriteLine(num);
                num = num * 2;
            }
            Console.WriteLine();
            num = 2;
            for (int i = 1; i < stepen; i++) // ne e dobre da polzvame for cikul za stepeni ili Math.Pow() mnogo e bavno
            {                
                num = num * 2;
            }
            Console.WriteLine(num);


            int nomer = int.Parse(Console.ReadLine());
            while (nomer < 5 || nomer > 15) {// while e bezkraen cikkul, izpolzvame go pred for kogato ne znaem kolko ni e n

                Console.WriteLine("Nomerat trqbva da e ot 5 do 15!");
                nomer = int.Parse(Console.ReadLine());
                // while e cikul na koito trqbva da slojim krai 
                //chesto e izpolzvan za pravene na igri
            }
            Console.WriteLine("success!");

            Console.WriteLine();
            var a = 1;
            while (true)
            {
                Console.WriteLine(a);
                a++;
                if(a>10) { break; } // mojem da slojim break kato krai na cikula

            }


            // vmesto while(){} mojem da polzvame       for(;;){}  tova sushto e bezkraen cikul
            // break izliza ot cikula
            // continue ne izliza ot cikula a prosto ne izpulnqva ostatuka ot koda v cikula i se vrushta obratno 



            Console.WriteLine();

            // Zadacha nai golqm obsht delitel :
            //NOD mejdu dve chisla e nai golqmoto chislo koeto deli i dvete chisla bez ostatuk

            int nn = int.Parse(Console.ReadLine());
            int mm = int.Parse(Console.ReadLine());
            
            while (mm != 0)
            {

                var temp = mm;
                mm = nn % mm;
                nn = temp;  
            }

            Console.WriteLine(nn); // kogato poluchin mm = 0 v while cikula znachi v nn imame NOD  !!!


            //VSQKA ZADACHA MOJE DA BUDE RESHENA S WHILE CIKUL I GO TO OPERATOR !!!!!


            /*DO Swile cikul:  purvo izpulnqva koda i posle gleda uslovieto !
             Koda se izpulnqva minimum vednuk. NE E MNOGO IZPOLZVAN*/

           


        }
    }
}
