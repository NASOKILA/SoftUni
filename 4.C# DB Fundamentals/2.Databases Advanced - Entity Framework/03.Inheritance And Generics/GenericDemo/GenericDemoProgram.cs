using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class GenericDemoProgram
    {
        static void Main(string[] args)
        {
            /*
             Generic e tova koeto pishem v <> skobki, primerno v 
             List<...> nie trqbva da pokajem kakuv tip danni iskame da 
             slojim tam. PrimTOVA E KONVENCIQ, MOJEM DA SI SLOJIM KAKVOTO
             SI ISKAME TAM .
             
            PRIMERNO TypeOf<T>(T num1) */

            Dog dog = new Dog("Spaik", 10, 50);

            //kato izvikvame metoda kazvame kakvoe tova 'Thing'
            TypeOf<Dog>(dog);
            

            //PRI KLASOVETE RABOTI PO SUSHTIQ NACHIN !!!
        }

        //Suzdavame si metod polzvaiki Generi collection
        //V sluchaq si pishem 'Thing' kato konvenciq, mojem da si pishem kakvoto si 
        //poiskame.
        static void TypeOf<Thing>(Thing num1)
        {
            Console.WriteLine(num1.GetType().ToString());
        }
    }
}








