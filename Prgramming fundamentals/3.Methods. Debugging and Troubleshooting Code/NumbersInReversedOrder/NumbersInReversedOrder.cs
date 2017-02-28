using System;


namespace NumbersInReversedOrder
{
    public class NumbersInReversedOrder
    {

        static string PrintNumberInReversedOrder(string number)
        {

            // vsekistring e suvkupnost ot sinvoli MOJEM DADOSTUPVAME VSEKI EDIN ELEMENT PO OTDELNO

            string result = "";
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result = result + number[i]; // TAKA DOSTUPVAME DO ELEMENTITE NA STRINGA
            }         

            return result;
        }
        public static void Main(string[] args)
        {
           string n = Console.ReadLine();
           string result = PrintNumberInReversedOrder(n);
            Console.WriteLine(result);
        }
    }
}