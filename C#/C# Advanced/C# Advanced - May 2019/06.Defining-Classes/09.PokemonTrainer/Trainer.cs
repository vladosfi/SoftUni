using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private int badges;
        private List<Pokemon> pokemons;

        public Trainer()
        {
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public int Badges { get => badges; set => badges = value; }
        public List<Pokemon> Pokemons { get => pokemons; private set => pokemons = value; }

        public void AddPockemon(Pokemon pokemon)
        {
            this.Pokemons.Add(pokemon);
        }

        public void DecreeseHealth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                if (Pokemons[i].Health - 10 > 0)
                {
                    Pokemons[i].Health -= 10;
                }
                else
                {
                    RemovePokemon(i);
                }
            }
        }

        private void RemovePokemon(int index)
        {
            Pokemons.RemoveAt(index);
        }

        public bool PokemonsContainElement(string element)
        {
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Element == element)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
