using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public abstract class Backpack : IBag
    {
        private readonly IList<string> items;

        public Backpack()
        {
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;
    }
}
