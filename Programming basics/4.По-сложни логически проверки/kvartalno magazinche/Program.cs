using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kvartalno_magazinche
{
    class Program
    {
        static void Main(string[] args)
        {
            //zadacha :  kvartalno magazinche

            string produkt = Console.ReadLine().ToLower();
            string grad = Console.ReadLine().ToLower();
            double amount = double.Parse(Console.ReadLine());
            double price = 0.00;
            double result = 0.00;

            // produkti : kafe, voda, sladki, fastuci
            //gradove : sofiq, plovdiv, varna


            if (produkt == "coffee")
            {
                if (grad == "sofia") { price = 0.50; result = amount * price; Console.WriteLine(result); }
                else if (grad == "plovdiv") { price = 0.40; result = amount * price; Console.WriteLine(result); }
                else if (grad == "varna") { price = 0.45; result = amount * price; Console.WriteLine(result); }
            }
            if (produkt == "water")
            {
                if (grad == "sofia") { price = 0.80; result = amount * price; Console.WriteLine(result); }
                else if (grad == "plovdiv") { price = 0.70; result = amount * price; Console.WriteLine(result); }
                else if (grad == "varna") { price = 0.70; result = amount * price; Console.WriteLine(result); }
            }
            if (produkt == "beer")
            {
                if (grad == "sofia") { price = 1.20; result = amount * price; Console.WriteLine(result); }
                else if (grad == "plovdiv") { price = 1.15; result = amount * price; Console.WriteLine(result); }
                else if (grad == "varna") { price = 1.10; result = amount * price; Console.WriteLine(result); }
            }
            if (produkt == "sweets")
            {
                if (grad == "sofia") { price = 1.45; result = amount * price; Console.WriteLine(result); }
                else if (grad == "plovdiv") { price = 1.30; result = amount * price; Console.WriteLine(result); }
                else if (grad == "varna") { price = 1.35; result = amount * price; Console.WriteLine(result); }
            }
            if (produkt == "peanuts")
            {
                if (grad == "sofia") { price = 1.60; result = amount * price; Console.WriteLine(result); }
                else if (grad == "plovdiv") { price = 1.50; result = amount * price; Console.WriteLine(result); }
                else if (grad == "varna") { price = 1.55; result = amount * price; Console.WriteLine(result); }
            }      
        }
    }
}
