using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private readonly List<T> stones;

        public Lake(T[] data)
        {
            this.stones = new List<T>(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return stones[i];
            }

            int currentIndex =
                this.stones.Count % 2 == 0
                ? this.stones.Count - 1
                : this.stones.Count - 2;

            for (int i = currentIndex; i >= 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
