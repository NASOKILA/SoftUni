using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Логически_проверки
{
    class Program
    {
        static void Main(string[] args)
        {
            // logicheski izrazi i operatori : <, >, ==, !=     != e obratnoto na ==
            //konstrukcii: if, if-else
            // bool e promenliva samo za istina ili luja

            // imame if    if + else   i   if + else if + else


            var a = 6;
            if (a < 5)
            {

                Console.WriteLine("a < 5");
            }
            else if (a > 5)
            {
                Console.WriteLine("a > 5");
            }
            else {
                Console.WriteLine("a = 5");
            }


            // ima variant za if ili for cikul bez {}

            if(a == 6)
                Console.WriteLine("a e  ravno na 6");


            // % izvejda statuka
            int num = 3;
            int num2 = 11;
            int result = 11 % 3; // sledovatelno kazvame :kolko puti 3 se pobira v 11 i ni izvejda ostatuka    11%3 = 3 s ostatuk 2
            int result2 = 3  % 11; 
            Console.WriteLine("11 % 3 = " + result);
            Console.WriteLine("3 % 11 = " + result2);
            // 3%11 = 0  0*11=0  3-0=3    zatova izvajda 3  KOGATO IMAME MALKO I POSLE GOLQMO CHISLO REZULTATA E VINAGI MALKOTO CHISLO


            //Proverka za chetno i nechetno:
            int num3 = int.Parse(Console.ReadLine());
            if (num3 % 2 == 1)
            {
                Console.WriteLine("odd");
            }
            else  // stava i taka: (num3 % 2 == 0)   za chetno
            {
                Console.WriteLine("even");
            }


            //zadacha Po golqmo ot dvete chisla

            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            if (firstNum > secondNum)
            {
                Console.WriteLine(firstNum);
            }
            //else if (firstNum == secondNum) { Console.WriteLine("ravni sa"); }
            else {
                Console.WriteLine(secondNum);
            }



            //Promenlivi:
            /*Promenlivite jiveqt samo v blokovete v koito sa suzdadeni*/








        }
    }
}
