using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PokemonEvolution
{

    class Pokemon
    {
        public string Name { get; set; }
        public string Evolutions { get; set; }
        public ulong Indexes { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', '-', '>' },StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            Dictionary<string, List<string>> NameAndEvolution = new Dictionary<string, List<string>>();
            Dictionary<string, List<ulong>> NameAndIndexes = new Dictionary<string, List<ulong>>();
            Dictionary<string, string> NamesAndEvolutionPlusIndexToStr = new Dictionary<string, string>();


            List<Pokemon> pokemons = new List<Pokemon>();

            while (input[0] != "wubbalubbadubdub")
            {
                if (input.Length == 3)
                {
                    string pokemonName = input[0];
                    string evolutionType = input[1];
                    ulong evolutionIndex = ulong.Parse(input[2]);

                    Pokemon pokemon = new Pokemon
                    {
                        Name = pokemonName,
                        Evolutions = evolutionType,
                        Indexes = evolutionIndex
                    };

                    pokemons.Add(pokemon);


                }
                else if (input.Length == 1)
                {
                    List<string> printedPokemons2 = new List<string>();
                    string pokemonN = input[0];
                    foreach (var item in pokemons)
                    {
                        if (item.Name == pokemonN)
                        {

                            if (!printedPokemons2.Contains(item.Name))
                            {
                                Console.WriteLine($"# {item.Name}");
                                foreach (var pok in pokemons.Where(p => p.Name == pokemonN))
                                {
                                    Console.WriteLine($"{pok.Evolutions} <-> {pok.Indexes}");
                                }

                                printedPokemons2.Add(item.Name);
                            }
                        }
                    }

                }




                input = Console.ReadLine()
                .Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Trim())
                .ToArray();

            }

            List<string> printedPokemons = new List<string>();
            foreach (var pokemon in pokemons.Distinct())
            {
                if (!printedPokemons.Contains(pokemon.Name))
                {
                    string name = pokemon.Name;
                    Console.WriteLine($"# {name}");

                    foreach (var pok in pokemons.Where(p => p.Name == name).OrderByDescending(a => a.Indexes))
                    {
                        Console.WriteLine($"{pok.Evolutions} <-> {pok.Indexes}");
                    }
                    printedPokemons.Add(pokemon.Name);
                }
            }  

        }

      
        }
   
}
