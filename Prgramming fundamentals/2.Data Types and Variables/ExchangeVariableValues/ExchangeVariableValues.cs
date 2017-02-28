using System;


namespace ExchangeVariableValues
{
   public class ExchangeVariableValues
    {
       public static void Main(string[] args)
        {

            int a = 5;
            int b = 10;
            int c = 0;

            Console.WriteLine("Before: ");
            Console.WriteLine("a = {0}",a);
            Console.WriteLine("b = {0}",b);

            c = b;
            b = a;
            a = c; 
            Console.WriteLine("After: ");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);


        }
    }
}
