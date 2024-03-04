using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            Dictionary<IAddCollection, List<int>> indexesOfAdd = new Dictionary<IAddCollection, List<int>>()
            {
                { addCollection, new List<int>() },
                { addRemoveCollection, new List<int>() },
                { myList, new List<int>() }
            };
            Dictionary<IAddCollection, List<string>> removedStrings = new Dictionary<IAddCollection, List<string>>()
            {
                { addRemoveCollection, new List<string>() },
                { myList, new List<string>() }
            };
            
            List<string> inputElements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            for(int i = 0; i < inputElements.Count; i++)
            {
                indexesOfAdd[addCollection].Add(addCollection.Add(inputElements[i]));
                indexesOfAdd[addRemoveCollection].Add(addRemoveCollection.Add(inputElements[i]));
                indexesOfAdd[myList].Add(myList.Add(inputElements[i]));
            }
            int removeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < removeCount; i++)
            {
                removedStrings[addRemoveCollection].Add(addRemoveCollection.Remove());
                removedStrings[myList].Add(myList.Remove());
            }
            foreach (var item in indexesOfAdd)
            {
                Console.WriteLine(String.Join(" ", item.Value));
            }
            foreach (var item in removedStrings)
            {
                Console.WriteLine(String.Join(" ", item.Value));
            }
        }
    }
}
//Dictionary<string, List<int>> indexesOfAdd = new Dictionary<string, List<int>>()
//{
//    { "AddCollection", new List<int>() },
//    { "AddRemoveCollection", new List<int>() },
//    { "MyList", new List<int>() }
//};
//Dictionary<string, List<int>> indexesOfRemove = new Dictionary<string, List<int>>()
//{
//    { "AddCollection", new List<int>() },
//    { "AddRemoveCollection", new List<int>() },
//    { "MyList", new List<int>() }
//};
