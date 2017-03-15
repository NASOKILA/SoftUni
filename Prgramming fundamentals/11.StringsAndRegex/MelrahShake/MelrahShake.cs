using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelrahShake
{
    class MelrahShake
    {
        static void Main(string[] args)
        {


            string input = Console.ReadLine();
            string pattern = Console.ReadLine();
            int partternLengthDevidedByTwo = 0;
            int countgroups = 0;
            string inputTest = input;

            while (true)
            {


                while (inputTest.Contains(pattern))
                {
                    countgroups++;
                    int pos2 = inputTest.IndexOf(pattern);
                    inputTest = inputTest.Remove(pos2, pattern.Length);
                }
                // namerihme broq na grupite



                if (countgroups >=2 && !pattern.Equals(""))
                {
                    
                    input = input.Replace(pattern, "");
                    Console.WriteLine("Shaked it.");

                    partternLengthDevidedByTwo = pattern.Length / 2;
                    pattern = pattern.Remove(partternLengthDevidedByTwo, 1);
                    countgroups = 0;
                    inputTest = input;
                }              
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    break;
                }




            }
        }
    }
}
