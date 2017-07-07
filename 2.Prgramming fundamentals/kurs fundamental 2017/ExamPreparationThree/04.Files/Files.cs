using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Files
{
    class File
    {

        public string Root { get; set; }
        public decimal FileSize { get; set; }
        public string FileName { get; set; }
        public string Exstention { get; set; }
        public List<string> Folders { get; set; }

    }
    class Files
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<File> allFies = new List<File>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                .Split(new string[] { @"\", ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

                string root = command[0];
                decimal fileSize = decimal.Parse(command[command.Length-1]);
                string[] fileNameAndExtention = command[command.Length - 2].Split('.').ToArray();
                if (fileNameAndExtention.Length != 2)
                    continue;
                string fileName = fileNameAndExtention[0];
                string exstention = fileNameAndExtention[1];
                List<string> folders = command.Skip(1).Take(command.Length - 3).ToList();

                if (allFies.Any(f => f.Root == root && f.FileName == fileName && f.Exstention == exstention))
                {
                    File file2 = allFies.Where(f => f.Root == root && f.FileName == fileName && f.Exstention == exstention).FirstOrDefault();

                    allFies.Remove(file2);
                }
               
                    File file = new File
                    {
                        Root = root,
                        FileSize = fileSize,
                        FileName = fileName,
                        Exstention = exstention,
                        Folders = folders
                    };

                    allFies.Add(file);
                
                

            }

             string[] query = Console.ReadLine().Split(' ').ToArray();
            string exstentionToSearch = query[0];
            string rootToSearch = query[2];

            List<File> result = allFies
                .Where(f => f.Exstention == exstentionToSearch && f.Root == rootToSearch)
                .OrderByDescending(f => f.FileSize)
                .ThenBy(f => f.FileName)
                .ToList();

            foreach (File file in result)
            {
                Console.WriteLine($"{file.FileName}.{file.Exstention} - {file.FileSize} KB");
            }

            if(result.Count == 0)
                Console.WriteLine($"No");

        }
    }
}
