using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    class StartUp
    {
        static void Main()
        {
            //“<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string[] tokens = input.Split();
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(t => t.Name == trainerName))
                {
                    int trainerId = trainers.FindIndex(t => t.Name == trainerName);
                    trainers[trainerId].Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName, 0, pokemon);
                    trainers.Add(trainer);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                //“Fire”, “Water”, “Electricity”

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(e => e.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;

                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }                

                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}
