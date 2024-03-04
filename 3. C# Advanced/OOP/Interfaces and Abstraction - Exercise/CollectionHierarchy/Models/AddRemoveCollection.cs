using CollectionHierarchy.Models.InterFaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int addIndex = 0;
        private readonly List<string> listAddRemoveCollection;

        public AddRemoveCollection()
        {
            listAddRemoveCollection = new List<string>();
        }
        public int Add(string inputElement)
        {
            listAddRemoveCollection.Insert(addIndex, inputElement);
            return addIndex;
        }
        public string Remove()
        {
            if(listAddRemoveCollection.Count > 0)
            {
                string elementForRemoving = listAddRemoveCollection[listAddRemoveCollection.Count - 1];
                listAddRemoveCollection.RemoveAt(listAddRemoveCollection.Count - 1);
                return elementForRemoving;
            }
            return null;
        }
    }
}
