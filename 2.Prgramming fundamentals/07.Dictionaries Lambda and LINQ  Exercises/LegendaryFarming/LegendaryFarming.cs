using System;
using System.Collections.Generic;
using System.Linq;


namespace LegendaryFarming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> LegendaryItems = new Dictionary<string, string>();
            LegendaryItems["Shadowmourne"] = "shards";
            LegendaryItems["Valanyr"] = "fragments";
            LegendaryItems["Dragonwrath"] = "motes";

            
            Dictionary<string, int> MaterialsAndQuantity = new Dictionary<string, int>();
            Dictionary<string, int> KeyMaterialsAndQuantity = new Dictionary<string, int>();
            Dictionary<string, int> JunkAndQuantity = new Dictionary<string, int>();

            List<string> input = Console.ReadLine().Split(' ').ToList();
            List<int> inputInts = new List<int>();
            List<string> inputStrings = new List<string>();
            List<string> legendaryItem = new List<string>();



            GetAllMaterials(input, inputInts, inputStrings, MaterialsAndQuantity);
            

            SplitMaterialsIntoJunkAndKeyMaterials(MaterialsAndQuantity, KeyMaterialsAndQuantity, JunkAndQuantity);
           

            AddMissingKeyMaterial(KeyMaterialsAndQuantity);

            
            GetLegendaryItem(KeyMaterialsAndQuantity, legendaryItem, LegendaryItems);

            string legendaryItemStr = legendaryItem[0];
            PrintResult(legendaryItemStr, KeyMaterialsAndQuantity, JunkAndQuantity);
        }


        private static void GetAllMaterials(List<string> input, List<int> inputInts, List<string> inputStrings, Dictionary<string, int> MaterialsAndQuantity)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (i.Equals(18)) { break; } // ako ima poveche ot 9 elementa izlezni zashtoto ne te se ignorirat!

                if (i % 2 == 0)          // slagame vsichki nomera v spisuka inputInts
                    inputInts.Add(int.Parse(input[i]));
                else                       // slagame vsichki stringove v spisuka inputStrings
                    inputStrings.Add(input[i].ToLower());
            }

            for (int i = 0; i < inputInts.Count; i++) // slagame vsichki materiali v materials
            {
                if (MaterialsAndQuantity.Keys.Contains(inputStrings[i]))  // ako imeto se povtarq 
                {
                    MaterialsAndQuantity[inputStrings[i]] += inputInts[i];  // uvelichavame samo stoinostta
                }
                else
                    MaterialsAndQuantity[inputStrings[i]] = inputInts[i];

            }
        }


        private static void SplitMaterialsIntoJunkAndKeyMaterials(Dictionary<string, int> MaterialsAndQuantity,
            Dictionary<string, int> KeyMaterialsAndQuantity, Dictionary<string, int> JunkAndQuantity)
        {
            foreach (var material in MaterialsAndQuantity) // razdelqme materialite na junk i keyMaterial
            {
                if (material.Key.Equals("fragments") || material.Key.Equals("motes") || material.Key.Equals("shards"))
                    KeyMaterialsAndQuantity[material.Key] = material.Value;
                else
                    JunkAndQuantity[material.Key] = material.Value;
            }
        }


        private static void AddMissingKeyMaterial(Dictionary<string, int> KeyMaterialsAndQuantity)
        {
            if (KeyMaterialsAndQuantity.Count < 3) // ako lipsva Key MAterial go dobavqme s nuleva stoinost !
            {

                foreach (var material in KeyMaterialsAndQuantity)
                {
                    if (!KeyMaterialsAndQuantity.ContainsKey("fragments"))
                    {
                        KeyMaterialsAndQuantity["fragments"] = 0;
                        break;
                    }
                    else if (!KeyMaterialsAndQuantity.ContainsKey("shards"))
                    {
                        KeyMaterialsAndQuantity["shards"] = 0;
                        break;
                    }
                    else if (!KeyMaterialsAndQuantity.ContainsKey("motes"))
                    {
                        KeyMaterialsAndQuantity["motes"] = 0;
                        break;
                    }
                }
            }

        }


        private static void GetLegendaryItem(Dictionary<string, int> KeyMaterialsAndQuantity, List<string> legendaryItem, Dictionary<string, string> LegendaryItems)
        {

            foreach (var material in KeyMaterialsAndQuantity) // keep track of key materials and get LEGENDARY ITEM
            {
                if (material.Value >= 250)
                {
                    KeyMaterialsAndQuantity[material.Key] -= 250;
                    legendaryItem.Add(LegendaryItems.FirstOrDefault(x => x.Value.Contains(material.Key)).Key);

                    break;
                }

            }

        }


        private static void PrintResult( string legendaryItemStr, Dictionary<string, int> keyMaterialsAndQuantity, 
            Dictionary<string, int> junkAndQuantity)
        {

            Console.WriteLine("{0} obtained!", legendaryItemStr); // print legendary item
            foreach (var item in keyMaterialsAndQuantity.OrderByDescending(x => x.Value)) // print keymaterials by quantity
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }

            foreach (var item in junkAndQuantity.OrderBy(x => x.Key)) // print the junk ordered alphabetically
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }
    }
}
