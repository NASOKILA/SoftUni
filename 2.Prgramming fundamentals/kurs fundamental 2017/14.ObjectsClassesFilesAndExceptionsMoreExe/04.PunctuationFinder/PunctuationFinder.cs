using System.IO;

namespace _04.PunctuationFinder
{
    class PunctuationFinder
    {
        static void Main(string[] args)
        {
            var text = File.ReadAllText("sample_text.txt");

            string result = string.Empty;

            foreach (var letter in text)
            {
                if (letter == '.' || letter == ',' || letter == '!' || letter == '?' || letter == ':')
                {
                    result = result + letter + ", ";
                }
            }

            result = result.Substring(0, result.Length-1);
            File.WriteAllText("output.txt", result);

        }
    }
}
