using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {

        public string Name { get; private set; }
        public int Level { get; private set; }
        public Item Item { get; private set; }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }


        public override string ToString()
        {
            StringBuilder heroInfo = new StringBuilder();

            heroInfo.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            heroInfo.Append(this.Item.ToString());

            return heroInfo.ToString();
        }
    }
}
