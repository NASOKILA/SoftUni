using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            char[] separator = { ' ', '=' };
            string input = Console.ReadLine();

            List<string> IPs = new List<string>();
            


            SortedDictionary<string, Dictionary<string, int>> UserIp = new SortedDictionary<string, Dictionary<string, int>>();

            while (!input.Equals("end"))
            {
                List<string> inputStr = input
                    .Split(separator)
                    .ToList();

                string IP = inputStr[1];
                string message = inputStr[3];
                string user = inputStr[5];


                Dictionary<string, int> IpCount = new Dictionary<string, int>(); // suzdavame malkiq rechnik



                if (!UserIp.ContainsKey(user)) // Ako takuv user ne sushtestvuva
                {

                    IpCount[IP] = 1;      // soalgame Ip adresa i edinica za count v malkiq
                    UserIp.Add(user, IpCount);  // slagame malkiq v golqmiq

                }

                else   // ako veche tozi uzer sushtestvuva
                {

                    if (!UserIp[user].ContainsKey(IP)) // ako usera e sushtiq no ipa ne e 
                    {

                        IpCount = UserIp[user];   // slagame starite stoinosti
                        IpCount[IP] = 1;                                     //POSTOQNNO RABOTIM SAMO S MALKIQ I NAKRAQ GO SLAGAME V GOLEMIQ
                        UserIp[user] = IpCount; // slagame malkiq v golqmiq
                    }
                    else  // Ako usera e sushtiq i Ip adresa e sushtiq
                    {
                        IpCount = UserIp[user];
                        if (IpCount.ContainsKey(IP))
                        {
                            IpCount[IP]++;
                            UserIp[user] = IpCount;
                        }

                    }

                }

                input = Console.ReadLine();
            }


            PrintResult(UserIp);
        }


        private static void PrintResult(SortedDictionary<string, Dictionary<string, int>> UserIp)
        {
         

            foreach (var user in UserIp)
            {
                string userName = user.Key;
                
                Dictionary<string, int> IPCount2 = UserIp[user.Key];

                Console.WriteLine("{0}: ", userName);
                
                int counter = 0;
                List<string> allUserIpsAndCountsToList = new List<string>(); // tova e za nakraq za printiraneto
                foreach (var  item in IPCount2)
                {
                    List<string> allUserIps = UserIp[user.Key].Keys.ToList();
                    List<int> allUserIpsCount = UserIp[user.Key].Values.ToList();
                    string allUserIpsAndCounts = allUserIps[counter] + " => " + allUserIpsCount[counter];
                    allUserIpsAndCountsToList.Add(allUserIpsAndCounts);
                    counter++;              
                }
                Console.WriteLine("{0}.", string.Join(", ", allUserIpsAndCountsToList));

            }  
        }

    }
}
/*
 using System;
using System.Collections.Generic;
using System.Linq;


namespace UserLogs
{
    class UserLogs
    {
        static void Main(string[] args)
        {

       

            SortedDictionary<string, List<string>> UserIP = new SortedDictionary<string, List<string>>();
            Dictionary<string, long> IPCount = new Dictionary<string, long>();


            char[] separator = { ' ', '=' };            
            string input = Console.ReadLine();

            List<string> IPs = new List<string>();

           
            while (!input.Equals("end"))
            {
                List<string> inputStr = input
                    .Split(separator)

                    .ToList();

                string IP = inputStr[1];
                string message = inputStr[3];
                string user = inputStr[5];




                if (!UserIP.ContainsKey(user)) // Ako takuv user ne sushtestvuva
                {
                    UserIP.Add(user, new List<string>()); // nova instanciq
                     // dobavqme Ip adresa v spisuka
                    UserIP[user].Add(IP); // dobavqme spisuka kum rechnika

                    IPCount[IP] = 1;

                }
                else   // ako veche tozi uzer sushtestvuva
                {
                    IPs.Add(IP);
                        if (!UserIP[user].Contains(IP)) // ako v spisuka NE se sudurja tozi Ip
                        {
                            UserIP[user].Add(IP); // Dobavi Ipa ku spisuka
                            IPCount[IP] = 1; // slagame stoinosta na Ipa da e 1

                            IPs = new List<string>(); // Chistim spisuka IPs
                        }
                        else  // Ako usera e sushtiq i Ip adresa e sushtiq
                        {
                            IPCount[IP]++; 
                            // uvelichavame stoinosta na ipa s 1 vseki put kato tozi user vlezne sus sushtiq Ip
                        }               

                }            

                input = Console.ReadLine();
            }

               PrintUserLogs(UserIP, IPCount); // printirame

            }


        private static void PrintUserLogs(SortedDictionary<string, List<string>> UserIP,
            Dictionary<string, long> IPCount)
        {

            byte counterForComas = 0;
            foreach (var user in UserIP.Keys) // za vseki user
            {
                Console.WriteLine("{0}: ", user); // printirame usera

                foreach (var Ip in IPCount) // za vseki ip v rechnika s ip adresite
                {
                    //foreach (var item in IPCount.Where( x => UserIP[user].Contains(Ip.Key)))
                    //{
                    //    Console.WriteLine("{0} => {1}",item.Key, item.Value);
                    //}

                    if (UserIP[user].Contains(Ip.Key)) // Ako tozi user sudurja kato stoinost tozi ip
                    {
                        counterForComas++;
                        if (UserIP[user].Count.Equals(1))
                        {
                            Console.WriteLine("{0} => {1}", Ip.Key, Ip.Value + ".");                          
                        }
                        else
                        {
                            if (counterForComas == UserIP[user].Count )
                            {
                                Console.WriteLine("{0} => {1}", Ip.Key, Ip.Value + ".");
                            }
                            else
                            {
                                Console.Write("{0} => {1}", Ip.Key, Ip.Value + ", ");
                            }
                            
                        }
                        
                    }
                    
                }

            }

        }
        
    }
}

 */
