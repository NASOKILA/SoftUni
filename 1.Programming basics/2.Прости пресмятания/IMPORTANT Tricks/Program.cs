using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMPORTANT_Tricks
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 2;
            var b = 5;
            

            Console.WriteLine(" " + a + b); // kogato ima string otpred schita chislata za stringove     vadi 25
            Console.WriteLine(a + b);// tuk sa si integeri    vadi 7
            //mojem da polzvame placeholder

            Console.WriteLine(b/2);  // vadi zakrugleen integer  ednoto chislo trqbva da e double
            var r = (double)b / 2; // rezultata ot delenieto na cqlo i drobno chislo, e drobno
            Console.WriteLine(r);  // tuk vadi 2,5 zashtoto ednoto chislo e double
            //Console.WriteLine(a/0); // dava greshka


            // control + k + c    argumentirame selekcioniranoto  
            // control + k + u    dizargumentirame 

            var v = -15;
            var d = 5;
            Console.WriteLine(v + d); // dava -10
            Console.WriteLine(Math.Abs(v + d)); // dava 10 zashtoto namira absolutnata stoinots na presmqtaneto na dvete chisla
           

        }
    }
}
