using System;
using System.Collections.Generic;
using System.Text;

namespace _11.PokemonTrainer
{
    public class Trainer
    {
        //name, number of badges and a collection of pokemon
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(string name, int numberOfBadges, Pokemon pokemon)
        {
            this.Name = name;
            this.Badges = numberOfBadges;
            this.Pokemons = new List<Pokemon>();
            this.Pokemons.Add(pokemon);
        }

        public override string ToString()
        {
            return $"{Name} {Badges} {Pokemons.Count}";
        }
    }
}
