using System;

namespace DifferentIntegersSize
{
   public class DifferentIntegersSize
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                long n = long.Parse(input); // parsvame stringa !!! ELEMENTARNO
                
            if (n >= -128 && n <= 0) {
                    Console.WriteLine("{0} can fit in:",n);
                    Console.WriteLine("* sbyte");
                    Console.WriteLine("* short");
                    Console.WriteLine("* int");
                    Console.WriteLine("* long");
                }
                else if (n >= 0 && n <= 127)
                {
                    Console.WriteLine("{0} can fit in:", n);
                    Console.WriteLine("* sbyte");
                    Console.WriteLine("* byte");
                    Console.WriteLine("* short");
                    Console.WriteLine("* unshort");
                    Console.WriteLine("* int");
                    Console.WriteLine("* uint");
                    Console.WriteLine("* long");                  
                }
                else if (n >= 128 && n <= 255)
                {
                    Console.WriteLine("{0} can fit in:", n);                 
                    Console.WriteLine("* byte");
                    Console.WriteLine("* short");
                    Console.WriteLine("* unshort");
                    Console.WriteLine("* int");
                    Console.WriteLine("* uint");
                    Console.WriteLine("* long");
                }
                else if (n >= -32768 && n <= -129   )
                {
                    Console.WriteLine("{0} can fit in:", n);           
                    Console.WriteLine("* short");                  
                    Console.WriteLine("* int");                  
                    Console.WriteLine("* long");                 
                }
                else if (n >= 256 && n <= 32767)
                {
                    Console.WriteLine("{0} can fit in:", n);                 
                    Console.WriteLine("* short");
                    Console.WriteLine("* unshort");
                    Console.WriteLine("* int");
                    Console.WriteLine("* uint");
                    Console.WriteLine("* long");
                }
                else if (n >= 32768 && n <= 65535)
                {
                    Console.WriteLine("{0} can fit in:", n);                   
                    Console.WriteLine("* unshort");
                    Console.WriteLine("* int");
                    Console.WriteLine("* uint");
                    Console.WriteLine("* long");
                }
                else if (n >= -2147483648 && n <= -32769)
                {
                    Console.WriteLine("{0} can fit in:", n);                
                    Console.WriteLine("* int");
                    Console.WriteLine("* long");                 
                }
                else if (n >= 65536 && n <= 2147483647)
                {
                    Console.WriteLine("{0} can fit in:", n);                   
                    Console.WriteLine("* int");
                    Console.WriteLine("* uint");
                    Console.WriteLine("* long");
                }
                else if (n >= 2147483648 && n <= 4294967295)
                {
                    Console.WriteLine("{0} can fit in:", n);                 
                    Console.WriteLine("* uint");
                    Console.WriteLine("* long");
                }
                else if (n >= -9223372036854755808 && n <= -2147483649)
                {
                    Console.WriteLine("{0} can fit in:", n);               
                    Console.WriteLine("* long");
                }
                else if (n >= 4294967296 && n <= 9223372036854755807)
                {
                    Console.WriteLine("{0} can fit in:", n);
                    Console.WriteLine("* long");
                }
            }
            catch (OverflowException)
            {// if it breaks it will show me this !!!
                Console.WriteLine("{0} can't fit in any type", input);
            }
        }
    }
}
