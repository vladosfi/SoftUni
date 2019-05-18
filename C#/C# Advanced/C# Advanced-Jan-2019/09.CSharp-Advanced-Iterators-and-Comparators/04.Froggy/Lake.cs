using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> lakePath;

        public Lake(List<int> data)
        {
            lakePath = new List<int>(data);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.lakePath.Count; i+=2)
            {
                yield return this.lakePath[i];
            }

            int startIndex = 
                this.lakePath.Count % 2 == 0 
                ? this.lakePath.Count - 1 
                : this.lakePath.Count - 2;
            
            for (int i = startIndex; i >= 0; i-=2)
            {
                yield return this.lakePath[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
