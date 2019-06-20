using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public int Count => this.data.Count;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = data.Where(h => h.Name == name).FirstOrDefault();

            if (hero != null)
            {
                this.data.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(h => h.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(h => h.Item.Intelligence).FirstOrDefault();
        }


        public override string ToString()
        {
            StringBuilder allHeros = new StringBuilder();

            foreach (var hero in this.data)
            {
                allHeros.AppendLine(hero.ToString());
            }
            return allHeros.ToString();
        }

    }
}
