using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Split( new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                    

            
            string[] command = Console.ReadLine().Split().ToArray();

            while (!command[0].Equals("end"))
            {

                

                List<string> newList = new List<string>();

                switch (command[0])
                {

                    case "reverse":
                        int start = int.Parse(command[2]);
                        int end = int.Parse(command[4]);

                        // proverqvame za nevalidni ili negativni elementi
                        if (start < 0  
                            || start >= nums.Count
                            || end < 0 
                            || (start + end) > nums.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        newList = nums
                              .Skip(start)    // skopvame vsichko do start
                              .Take(end)      // vzimame vsichko do end
                              .Reverse()     // reversvame
                              .ToList();

                        nums.RemoveRange(start, end);
                        nums.InsertRange(start, newList);
                        break;
                    case "sort":
                        start = int.Parse(command[2]);      // VUV SWITCH NQMA NUJDA PAK DA INICIALIZIRAME PROMENLIVITE, ZA TOVA NQMA INT OTPRED
                        end = int.Parse(command[4]);

                        // proverqvame za nevalidni ili negativni elementi
                        if (start < 0
                            || start >= nums.Count
                            || end < 0
                            || (start + end) > nums.Count)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        newList = nums
                             .Skip(start)    // skopvame vsichko do start
                             .Take(end)      // vzimame vsichko do end
                             .OrderBy(e => e)   // TAKA GO SORTIRAME             
                             .ToList();

                        
                        nums.RemoveRange(start, end);
                        nums.InsertRange(start, newList);

                        break;
                    case "rollLeft":
                        int count = int.Parse(command[1]);

                        if(count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < (count % nums.Count); i++)  // MAHAME PURVIQ I GO SLAGAME NAKRAQ
                        {
                            string element = nums.First();
                            nums.Remove(nums.First());
                            nums.Add(element);
                        }

                        break;
                    case "rollRight":
                        count = int.Parse(command[1]);

                        if (count < 0)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            break;
                        }

                        for (int i = 0; i < (count % nums.Count); i++)  // MAHAME POSLEDNIQ I GO SLAGAME NAKRAQ
                        {
                           string element = nums.Last();
                            nums.Remove(nums.Last());
                            nums.Insert(0, element);
                        }
                        break;
                    default:                      
                        break;
                }


                command = Console.ReadLine().Split();

            }
                

            string output = string.Join(", ", nums);
            Console.WriteLine($"[{output}]");               // printirame si nums


        }
    }
}
