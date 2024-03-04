using CollectionHierarchy.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> listAddCollection;
        public AddCollection()
        {
            listAddCollection = new List<string>();
        }
        public int Add(string inputElement)
        {
            listAddCollection.Add(inputElement);

            return listAddCollection.LastIndexOf(inputElement); // return listAddCollection.Count - 1;
        }
    }
}
