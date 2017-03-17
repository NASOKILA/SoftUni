using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperaciiMejduChisla
{
    class OperaciiMejduChisla
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            string operatoR = Console.ReadLine();
            double result = 0.00;
            var oddOrEven = "";

            if (operatoR == "+") { result = n + m; }
            else if (operatoR == "-") { result = n - m; }
            else if (operatoR == "*") { result = n * m; }
            else if (operatoR == "/") { result = (double)n / (double)m; } // Drobno delenie
            else if (operatoR == "%")
            {

                try { result = n % m; }
                catch { Console.WriteLine("Cannot divide {0} by zero", n); }

            }


            if (operatoR == "+" || operatoR == "-" || operatoR == "*")
            {
                if (result % 2 == 0) { oddOrEven = "even"; } else { oddOrEven = "odd"; }
                Console.WriteLine("{0} {1} {2} = {3} - {4}", n, operatoR, m, result, oddOrEven); // chetno ili nechetno
            }
            else if (operatoR == "/")
            {
                if (m == 0) { Console.WriteLine("Cannot divide {0} by zero", n); }
                else
                { Console.WriteLine("{0} {1} {2} = {3:f2}", n, operatoR, m, result); }// do 2 chisle sled zapetaqta
            }
            else if (operatoR == "%" && !(m == 0))
            {
                Console.WriteLine("{0} {1} {2} = {3}", n, operatoR, m, result);
            }
        }
    }
}
