using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer());
                }

                trainers[trainerName].AddPockemon(pokemon);

                input = Console.ReadLine();
            }

            string element = Console.ReadLine();

            while (element != "End")
            {
                if (element == "Fire" || element == "Water" || element ==	"Electricity")
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Value.PokemonsContainElement(element))
                        {
                            trainer.Value.Badges++;
                        }
                        else
                        {
                            trainer.Value.DecreeseHealth();
                        }
                    }
                }

                element = Console.ReadLine();
            }


            var orderedTrainers = trainers.OrderByDescending(t => t.Value.Badges);

            foreach (var kvp in orderedTrainers)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.Badges} {kvp.Value.Pokemons.Count}");
            }
        }
    }
}
