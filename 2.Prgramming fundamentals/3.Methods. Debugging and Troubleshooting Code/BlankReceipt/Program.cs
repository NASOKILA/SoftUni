using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankReceipt
{
    class Program
    {   // ZA SEGA NQMA ZNACHENIE DALI DEKLARIRAME METODA PREDI MAIN ILI SLED NEGO !
        // SLED VREME SHTE IMA ZASHTOTO KODA SHTE SE IZPULNQVA RED PO RED, NQMA DA IMA KOMPILACIQ !

        static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        static void PrintBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        static void PrintFooter()
        {           
            Console.WriteLine("------------------------------");
            Console.WriteLine("© SoftUni");
        }
        static void PrintReceipt() {
            PrintHeader();
            PrintBody();
            PrintFooter();
        }
        static void Main(string[] args)
        {
            PrintReceipt();
        }


    }
}
