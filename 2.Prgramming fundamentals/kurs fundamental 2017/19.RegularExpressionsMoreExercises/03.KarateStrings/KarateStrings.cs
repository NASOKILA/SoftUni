using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.KarateStrings
{
    class KarateStrings
    {
        static void Main(string[] args)
        {
            string punches = Console.ReadLine();
            int totalPunches = 0;
            for (int i = 0; i < punches.Length; i++)
            {
                if (punches[i] == '>')
                {
                    
                    totalPunches += int.Parse(punches[i+1].ToString());
                    int lettersToRemove = totalPunches;
                    for (int j = i+1; j < i+1 + totalPunches; j++)
                    {
                        try
                        {
                            if (punches[j] != '>')
                            {
                                punches = punches.Remove(j, 1);
                                totalPunches--;
                                j--;
                            }
                        }
                        catch
                        { }
                    }
                    
                }
            }


            Console.WriteLine(punches);
        }
    }
}
