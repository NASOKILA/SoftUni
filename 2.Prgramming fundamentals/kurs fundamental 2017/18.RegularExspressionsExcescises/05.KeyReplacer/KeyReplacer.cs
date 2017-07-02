using System;
using System.Linq;


namespace _05.KeyReplacer
{
    class KeyReplacer
    {
        static void Main(string[] args)
        {
            string keysInput = Console.ReadLine();
            string startKey = string.Empty;
            string endKey = string.Empty;

            for (int i = 0; i < keysInput.Length; i++)
            {
                if (keysInput[i] != '|' && keysInput[i] != '<' && keysInput[i] != '\\')
                    startKey += keysInput[i];
                else
                    break;
            }

             keysInput = new string(keysInput.ToCharArray().Reverse().ToArray());
            for (int i = 0; i < keysInput.Length; i++)
            {
                if (keysInput[i] != '|' && keysInput[i] != '<' && keysInput[i] != '\\')
                    endKey += keysInput[i];
                else
                    break;
            }

            endKey = new string(endKey.ToCharArray().Reverse().ToArray());

            string text = Console.ReadLine();
            string result = string.Empty;

            while (true)
            {

                int startIndex = text.IndexOf(startKey) + startKey.Length;
                int endIndex = text.IndexOf(endKey);
                int lettersToTake = endIndex - startIndex;
                result += text.Substring(startIndex, lettersToTake);

                text = text.Substring(endIndex + endKey.Length);
                if (text.Length < 1)
                    break;
            }

            if(result == "")
                Console.WriteLine("Empty result");
            else
                Console.WriteLine(result);

        }
    }
}




