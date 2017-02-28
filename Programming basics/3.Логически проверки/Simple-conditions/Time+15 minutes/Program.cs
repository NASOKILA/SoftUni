using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15_minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int chas = int.Parse(Console.ReadLine());
            int minuti = int.Parse(Console.ReadLine());
            var resultPlusPetnaise = 0.00;

            if (chas < 0 || chas > 23) { Console.WriteLine("ERROR!"); }
            else
            {
                if (minuti < 0 || minuti > 60) { Console.WriteLine("ERROR!"); }
                else
                {
                    resultPlusPetnaise = minuti + 15;
                    if (resultPlusPetnaise > 60) //74
                    {
                        chas++;//24
                        resultPlusPetnaise = resultPlusPetnaise - 60; //14
                        if (chas > 23) { chas = 0; }//0
                        
                        if (resultPlusPetnaise < 10) { Console.WriteLine(chas + ":0" + resultPlusPetnaise); }
                        else { Console.WriteLine(chas + ":" + resultPlusPetnaise); }

                        resultPlusPetnaise = resultPlusPetnaise + 60;

                     }
                    else if (resultPlusPetnaise == 60) {
                        
                        if (chas == 23 && resultPlusPetnaise == 60) {
                            resultPlusPetnaise = 0;
                            chas = 0;
                            Console.WriteLine(chas + ":0" + resultPlusPetnaise);
                        }
                        else
                        {
                            resultPlusPetnaise = 0;
                            chas++;
                            Console.WriteLine(chas + ":0" + resultPlusPetnaise);
                        }
                    }


                    if (resultPlusPetnaise>0 && resultPlusPetnaise<60) { Console.WriteLine(chas + ":" + resultPlusPetnaise); } 
                }
            }
        }
    }
}
