using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinacii_ot_bukvi
{
    class Program
    {
        static void Main(string[] args)
        {
            // ot ascii tablicata angliiskata azbuka s malki bukvi zapochva ot 97 do 122 !!

            char start = char.Parse(Console.ReadLine());
            int startInNum = (int)start;             // vzimame nomera ot tozi char,   ako e a  =>  a = 97;            

            char end = char.Parse(Console.ReadLine());
            int endInNum = (int)end;     

            if (startInNum < 97 || startInNum > 122 ||
               endInNum < 97 || endInNum > 122 )
            { Console.WriteLine("Input error! Must input lowcase letters!"); } // ako ne sa malki bukvi da dava greshka
            else
            {
                if (end < start)
                {
                    while (true)
                    {
                        end = char.Parse(Console.ReadLine());  // vtoriq sincol trqbva da e po golqm ot purviq
                        endInNum = (int)end;
                        if (end > start) { break; }
                    }
                }

                char toSkip = char.Parse(Console.ReadLine());
                int toSkipInNum = (int)toSkip;



                // ZADACHATA ZAPOCHVA OT TUKA:

                if (toSkip < 97 || toSkip > 122)
                { Console.WriteLine("Input error! Must input to skip letter in lowcase!"); } // ako ne sa malki bukvi da dava greshka
                else
                {
                    int combinations = 0;

                    for (char firstL = start; firstL <= end; firstL++)  // Ot start do end  
                    {

                        for (char secondL = start; secondL <= end; secondL++) // Ot start do end  
                        {

                            for (char thirdL = start; thirdL <= end; thirdL++) // Ot start do end  
                            {
                                if (firstL != toSkip && secondL != toSkip && thirdL != toSkip)
                                {
                                    Console.Write("{0}{1}{2}", firstL, secondL, thirdL + " ");
                                    combinations++;

                                }
                            }
                        }

                    }


                    Console.WriteLine(combinations);



                }
            }          
            
        }
    }
}
