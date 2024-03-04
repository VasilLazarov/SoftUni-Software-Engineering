using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(this.Count);
            string removedElement = this[index];
            this.RemoveAt(index);
            return removedElement;
        }
    }
}
