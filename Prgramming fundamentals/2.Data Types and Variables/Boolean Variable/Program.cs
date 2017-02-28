using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringOne = Console.ReadLine().ToLower();

            bool isConverted = Convert.ToBoolean(stringOne);  // stringa stava na boolean i go printrame
            // DOBRE E BULEVITE PROMENLIVI DA ZAPOCHVAT S   is  ILI has !!!  VAJNO !!!
            if(isConverted)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            /*Kogato ifa e mnogo maluk moje da go otpechatame taka :
             Console.WriteLie(isConverted ? "Yes" : "No");   
             TOVA SE NARICHA TRENALEN OPERATOR!!!*/
        }
    }
}
