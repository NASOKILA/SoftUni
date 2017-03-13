using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFilter
{
    class TextFilter
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ',',' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
           
            string text = Console.ReadLine();
            foreach (var  banword in bannedWords) // za vsqka zabranena duma
            {
                if (text.Contains(banword)) // ako texta sudurja zabranenata duma
                {
                    text = text.Replace(banword, new string('*',banword.Length));  
                    // zamenqme dumata s '*' do duljinata na zabranenata duma, suzdadohme nov masiv s '*' koito e dulug kolkoto zabranenata duma 
                }
            }// AKO DUMATA Q NQMA ZNACHI NQMA DA Q ZAMESTI !
            Console.WriteLine(text);

        }
    }
}
