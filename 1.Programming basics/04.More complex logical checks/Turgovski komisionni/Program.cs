using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turgovski_komisionni
{
    class Program
    {
        static void Main(string[] args)
        {

            string grad = Console.ReadLine().ToLower();
            double prodajbi = double.Parse(Console.ReadLine());

            double komisionni = -1;

            if (grad == "sofia" && prodajbi >= 0 && prodajbi <= 500) { komisionni = prodajbi / 20; } //5%
            else if (grad == "sofia" && prodajbi >= 500 && prodajbi <= 1000) { komisionni = (prodajbi / 20) + (prodajbi / 50); } //7%
            else if (grad == "sofia" && prodajbi >= 1000 && prodajbi <= 10000) { komisionni = (prodajbi / 10) - (prodajbi / 50); } // 8%
            else if (grad == "sofia" && prodajbi > 10000) { komisionni = (prodajbi / 10) + (prodajbi / 50); }//12%

            else if (grad == "varna" && prodajbi >= 0 && prodajbi <= 500) { komisionni = (prodajbi / 20) - (prodajbi / 200); } //4.5%
            else if (grad == "varna" && prodajbi >= 500 && prodajbi <= 1000) { komisionni = (prodajbi / 20) + (prodajbi / 50) + (prodajbi / 200); } //7.5%
            else if (grad == "varna" && prodajbi >= 1000 && prodajbi <= 10000) { komisionni = (prodajbi / 10); } //10%
            else if (grad == "varna" && prodajbi > 10000) { komisionni = (prodajbi / 10) + (prodajbi / 20) - (prodajbi / 50); } //13% 

            else if (grad == "plovdiv" && prodajbi >= 0 && prodajbi <= 500) { komisionni = (prodajbi / 20) + (prodajbi / 200); } //5.5%
            else if (grad == "plovdiv" && prodajbi >= 500 && prodajbi <= 1000) { komisionni = (prodajbi / 10) - (prodajbi / 50); } // 8%
            else if (grad == "plovdiv" && prodajbi >= 1000 && prodajbi <= 10000) { komisionni = (prodajbi / 10) + (prodajbi / 50); } //12%
            else if (grad == "plovdiv" && prodajbi > 10000) { komisionni = (prodajbi / 10) + (prodajbi / 20) - (prodajbi / 200); } //14.5% 

            if (komisionni > 0 && prodajbi > 0) {// || prodajbi > 0 || (!(grad == "sofia")) || (!(grad == "varna")) || (!(grad == "plovdiv"))) {
                
                Console.WriteLine("{0:f2}", komisionni);
            }
            else { Console.WriteLine("error"); }
            
        }
    }
}
