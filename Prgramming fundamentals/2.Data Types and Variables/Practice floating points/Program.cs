using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_floating_points
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Be sure that
            each value is stored in the correct variable type (try to find the most suitable variable type in order to save
            memory). Finally, you need to print all variables to the console.
            
            3.141592653589793238
            1.60217657
            7.8184261974584555216535342341*/


            decimal n1 = 3.141592653589793238M; // slagame 'M' za da pokajem che chisloto e decimal,  'f' e za float, 'D' e za double.
            double n2 = 1.60217657; // nqma nujda da slagame D zashtoto go razbira po default
            decimal n3 = 7.8184261974584555216535342341M;
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);


        }
    }
}
