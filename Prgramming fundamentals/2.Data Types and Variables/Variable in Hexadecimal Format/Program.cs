using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable_in_Hexadecimal_Format
{
    class Program
    {
        static void Main(string[] args)
        {

            string variableInHex = Console.ReadLine();   // 254
          //  string string2 = "0x37";   // 55
         //   string string3 = "0x10";   // 16

            int variableInHexInNum = Convert.ToInt32(variableInHex, 16);  // TAKA GI PREOBRAZUVAME  v 16ticha b.s. !!!
            // ak nakraq napishem 2 a ne 16 shte chaka da mu podadem nuli i edinici zashtoto go preobrazuvame v dvoichna b.s. !!!
            // ToInt32()  moje da preobrazuva na 2 , 8 , 10 i 16  b.s
            Console.WriteLine(variableInHexInNum);

        }
    }
}
