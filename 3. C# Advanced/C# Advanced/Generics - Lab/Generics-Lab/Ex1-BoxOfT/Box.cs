using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_BoxOfT
{
    public class Box<T>
    {

        public Stack<T> elements;

        public Box()
        {
            elements = new();
        }

        public int Count { get { return elements.Count; } }

        public void Add(T element)
        {
            elements.Push(element);
        }

        public T Remove()
        {
            return elements.Pop();//or .Peek
        }

    }
}
