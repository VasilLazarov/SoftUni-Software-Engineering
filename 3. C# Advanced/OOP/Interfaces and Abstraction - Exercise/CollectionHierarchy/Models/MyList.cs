using CollectionHierarchy.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : IMyList
    {
        private const int addIndex = 0;
        private const int removeIndex = 0;
        private readonly List<string> listMyList;

        public MyList()
        {
            listMyList = new List<string>();
        }
        public int Used => listMyList.Count; 

        public int Add(string inputElement)
        {
            listMyList.Insert(addIndex, inputElement);
            return addIndex;
        }
        public string Remove()
        {
            if(listMyList.Count > 0)
            {
                string elementForRemoving = listMyList[removeIndex];
                listMyList.RemoveAt(removeIndex);
                return elementForRemoving;
            }
            return null;
        }
    }
}
