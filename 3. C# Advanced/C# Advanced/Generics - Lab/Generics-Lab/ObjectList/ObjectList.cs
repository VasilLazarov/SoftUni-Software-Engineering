using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectList
{
    public class ObjectList
    {
        private int index = 0;
        private object[] internalArray;

        public ObjectList()
        {
            internalArray = new object[100];
        }

        public void Add(object element)
        {
            internalArray[index++] = element;
        }
    }

    public class GenericList<T>
    {
        private int index = 0;
        private T[] internalArray;

        public GenericList()
        {
            internalArray = new T[100];
        }
        public void Add(T element)
        {
            internalArray[index++] = element;
        }
    }
}
