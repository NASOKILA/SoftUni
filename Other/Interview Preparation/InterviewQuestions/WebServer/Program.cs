using System;
using System.Collections.Generic;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {

            //boxing and unboxing
            int age = 25;
            object ageObj = age; //boxing

            Console.WriteLine(ageObj);


            int unboxedAge = (int)ageObj; //unboxing
            Console.WriteLine(unboxedAge);


            Console.WriteLine();
            //value and referense 
            //value types cannot be changed directry
            //reference types are change directly

            int num = 10; //All structures like int double, bool ...
            var names = new List<string> { "Atanas", "Asen" }; //reference types, ALL CLASSES they use the new keyword
            

            Change(num, names);

            Console.WriteLine(num);
            Console.WriteLine(string.Join(",", names));




            Console.WriteLine();

            // Multiple types in an array
            object[] array = new object[5];
            array[0] = 5;
            array[1] = "mama";
            array[2] = true;
            array[3] = 35.543543643543;
            array[4] = string.Join("+", new List<string>() { "nasko", "asi", "toni"});

            Console.WriteLine(string.Join(",", array));

            //get the types
            Type t1 = array[0].GetType();
            Type t2 = array[1].GetType();
            Type t3 = array[2].GetType();

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3); 
            

        }

        public static void Change(int num, List<string> name)
        {
            num = 100;
            name.Add("Paco");
        }
    }
}
