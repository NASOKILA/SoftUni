using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class LogsAggregator
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            SortedDictionary<string, int> userDuration = new SortedDictionary<string, int>();
            SortedDictionary<string, List<string>> userIps = new SortedDictionary<string, List<string>>();

            int oldDuration = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputArr = input.Split(' ');

                string ip = inputArr[0];
                string name = inputArr[1];
                int duration = int.Parse(inputArr[2]);



                if (!userDuration.ContainsKey(name)) // ako tova ime go nqma 
                {
                    userDuration[name] = duration;
                     oldDuration = duration;

                    userIps[name] = new List<string>();
                    userIps[name].Add(ip);                
                }
                else
                {
                    if (!userIps[name].Contains(ip)) // ako ne sudirja takuv ip
                    {
                        userIps[name].Add(ip); // go sloji
                    }

                    duration += userDuration[name];
                    userDuration[name] = duration;

                }
                

            }


            PrintNameDurationIp(userDuration, userIps);
        }

        private static void PrintNameDurationIp(SortedDictionary<string, int> userDuration,
            SortedDictionary<string, List<string>> userIps)
        {
           // int counterforComas = 1;

            foreach (var user in userDuration)
            {
                string userName = user.Key;
                int totalDuration = userDuration[user.Key];
                List<string> allIps = userIps[user.Key].ToList();

                Console.WriteLine("{0}: {1} [{2}]", userName, totalDuration, string.Join(", ",allIps));





            //    Console.Write("{0}: {1} [",user.Key, user.Value);
            //    foreach (var ip in userIps[user.Key].OrderBy(x => x))
            //    {
            //        Console.Write(ip);

            //        if (!counterforComas.Equals(userIps[user.Key].Count))
            //        {
            //            Console.Write(", ");
            //            counterforComas++;
            //        }
                  


            //    }
            //    Console.WriteLine("]");
            //    counterforComas = 1;



            }
        }
    }
}
