using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, Dictionary<string, int>>> typeNameAndInfo = new Dictionary<string, Dictionary<string, Dictionary<string,int>>>();
            Dictionary<string, Dictionary<string, int>> nameAndInfo = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> info = new Dictionary<string, int>();

            //IMAME RECHNIK VUV RECHNIK VUV RECHNIK

            for (int i = 0; i < n; i++)
            {
                int damage = 0;
                int health = 0;
                int armor = 0;

                List<string> command = Console.ReadLine().Split().ToList();
                string typeOfDragon = command.First();

                string nameOfDragon = command[1];

                if(command[2] == "null")
                    damage = 45;
                else
                    damage = int.Parse(command[2]);

                if (command[3] == "null")
                    health = 250;
                else
                    health = int.Parse(command[3]);

                if (command.Last() == "null")
                    armor = 10;
                else
                    armor = int.Parse(command.Last());

               //IMAME RECHNIK VUV RECHNIK VUV RECHNIK

                if (!typeNameAndInfo.ContainsKey(typeOfDragon))
                {
                    nameAndInfo = new Dictionary<string, Dictionary<string, int>>();
                    info = new Dictionary<string, int>();
                }
                else
                {
                    // we overwrite if we get the same dragon 
                    nameAndInfo = typeNameAndInfo[typeOfDragon];
                    info = new Dictionary<string, int>();
                }

                // dobavqme si neshtata v rechnika info
                info["damage"] = damage;
                info["health"] = health;
                info["armor"] = armor;

                // dobavqme info kum rechnika nameAndInfo
                nameAndInfo[nameOfDragon] = info;
  
                // nakraq dobavqme nameAndInfo kum glavniq rechnik
                typeNameAndInfo[typeOfDragon] = nameAndInfo;
            }




            //1.We have to get the average damage, health and armor
            //2.dragons are sorted alphabetically by name
            //3.we print the dragons

            foreach (var type in typeNameAndInfo)
            {
                double averageDamage = 0.0;
                double averageHealth = 0.0;
                double averageArmor = 0.0;

                foreach (var dragon in type.Value)
                {
                    // weth the counter we increase the right average
                    int counter = 0;
                    foreach (var information in dragon.Value)
                    {
                        if (counter == 0)
                            averageDamage += information.Value;
                        else if (counter == 1)
                            averageHealth += information.Value;
                        else if (counter == 2)
                            averageArmor += information.Value;
                        counter++;
                    }
                }
                //we get the average by dividing the average by the number of dragons
                averageDamage = averageDamage / type.Value.Count;
                averageHealth = averageHealth / type.Value.Count;
                averageArmor = averageArmor / type.Value.Count;



                // we print the type with the average values
                Console.WriteLine($"{type.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                // we print the dragons in that type with the information
                foreach (var dragon in type.Value.OrderBy(a => a.Key))
                {
                    Console.Write($"-{dragon.Key} -> ");
                    List<string> dragonValues = new List<string>();
                    foreach (var information in dragon.Value)
                        dragonValues.Add($"{information.Key}: {information.Value}");
                    Console.WriteLine(string.Join(", ", dragonValues));
                }
            }
        }
    }
}
