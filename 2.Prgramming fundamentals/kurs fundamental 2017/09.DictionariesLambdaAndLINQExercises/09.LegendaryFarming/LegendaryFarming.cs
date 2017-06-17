using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {

            List<string> input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.ToLower())
                .ToList();

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            SortedDictionary<string, int> junk = new SortedDictionary<string, int>();

            // 250 key materials winds the race


            string legendaryItem = string.Empty;

            int fragentsCount = 0;
            int shardsCount = 0;
            int motesCount = 0;

            for (int i = 0; i < input.Count-1; i += 2)
            {
                int quantity = int.Parse(input[i]);
                string resourse = input[i + 1];

                if (resourse == "fragments" || resourse == "shards"
                    || resourse == "motes")
                {
                    switch (resourse)
                    {
                        case "fragments":
                            fragentsCount += quantity;
                            if (fragentsCount >= 250)
                            {
                                legendaryItem = "Valanyr";
                                fragentsCount -= 250;
                                quantity = fragentsCount;
                            }
                            break;
                        case "shards":
                            shardsCount += quantity;
                            if (shardsCount >= 250)
                            {
                                legendaryItem = "Shadowmourne";
                                shardsCount -= 250;
                                quantity = shardsCount;
                            }
                            break;
                        case "motes":
                            motesCount += quantity;
                            if (motesCount >= 250)
                            {
                                legendaryItem = "DragonWrath";
                                motesCount -= 250;
                                quantity = motesCount;
                            }
                            break;
                    }
                    
                    if (!keyMaterials.ContainsKey(resourse)) // ako ne sudurja tozi kluch samo go sloji
                        keyMaterials[resourse] = quantity;
                    else
                    {               //ako veche go sudurja tozi kluch dobavi kum sumata
                        if(legendaryItem != string.Empty)
                            keyMaterials[resourse] = quantity;
                        else
                            keyMaterials[resourse] += quantity;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(resourse)) // ako ne sudurja tozi kluch samo go sloji
                        junk[resourse] = quantity;
                    else                                 //ako veche go sudurja tozi kluch dobavi kum sumata
                        junk[resourse] += quantity;
                }
                
            }


            if (!keyMaterials.ContainsKey("fragments"))
                keyMaterials["fragments"] = 0;
            if (!keyMaterials.ContainsKey("shards"))
                keyMaterials["shards"] = 0;
            if (!keyMaterials.ContainsKey("motes"))
                keyMaterials["motes"] = 0;


            Console.WriteLine($"{legendaryItem} obtained!");
            foreach (var kvp in keyMaterials.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");

            }
            foreach (var kvp in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
