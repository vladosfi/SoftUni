using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strenght, int ability, int intelligence)
        {
            this.Strength = strenght;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; private set; }
        public int Ability { get; private set; }
        public int Intelligence { get; private set; }

        public override string ToString()
        {
            StringBuilder itemInfo = new StringBuilder();

            itemInfo.AppendLine("Item:");
            itemInfo.AppendLine($"  * Strength: {this.Strength}");
            itemInfo.AppendLine($"  * Ability: {this.Ability}");
            itemInfo.Append($"  * Intelligence: {this.Intelligence}");

            return itemInfo.ToString();
        }

    }
}
