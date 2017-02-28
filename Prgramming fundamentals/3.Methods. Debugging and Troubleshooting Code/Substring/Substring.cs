using System;

public class Substring
{
    public static void Main()
    {
        


        string text = Console.ReadLine();
        int count = int.Parse(Console.ReadLine());
        
        const char search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)  // 3 puti
        {


            if (text[i] == search) // kato stigne do bukva p vliza vutre
            {
                hasMatch = true;

                int endIndex = count+1;

                if (endIndex > text.Length) // ako e po golqmo otduljinata 
                {
                    endIndex = text.Length;
                }
                if (endIndex > Math.Abs(i-text.Length)) // ako e poveche ot ostanalite bukvi
                {
                    endIndex = text.Length - i;
                }
                string matchedString = text.Substring(i, endIndex); // ot    i    do endIndex
                Console.WriteLine(matchedString);
                i += count;
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
