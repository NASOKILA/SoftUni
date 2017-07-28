using System;

namespace GreatherOfTwoValues
{
    class Program
    {
        static int Print(int a, int b) {
            return Math.Max(a, b);
        }

        static string Print(string a, string b){
            string result = "";
            if (a.Length <= b.Length) { result = b; }
            else { result = a; }
            
            return result;

           /*Here we can use CompareTi();
             You need to use the method &quot;CompareTo()&quot;, which returns an integer value (greater than zero if the
             compared object is greater, less than zero if the compared object is lesser and zero if the two objects are
             equal.*/
        }

        static char Print(char a, char b)
        {
            //int aToInt = Convert.ToInt32(a);
            //int bToInt = Convert.ToInt32(b);
            //int intMax =  Math.Max(aToInt, bToInt);
            //char result = (char)intMax;
            char result = a;
            if (a < b) { result = b; }
            return result;
        }

      
        static void Main(string[] args)
        {
            // input data type:
            string dataType = Console.ReadLine();

            //  MOJE DA IMA MNOGO METODI S EDNO I SUSHTO IME NO DA PRAVQT RAZLICHNI NESHTA RAZLICHAVAT SE PO PARAMETRITE !!!

            if (dataType == "int") {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int result = Print(a, b);
                Console.WriteLine(result);
            }
            else if (dataType == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string result = Print(a, b);
                Console.WriteLine(result);
            }
            else if (dataType == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                char result = Print(a, b);
                Console.WriteLine(result);
            }
            
        }
    }
}
