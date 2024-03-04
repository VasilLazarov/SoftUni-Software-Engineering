using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _03._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> list2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> result = new List<int>();
            for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
            {
                result.Add(list1[i]);
                result.Add(list2[i]);
            }
            if(list1.Count > list2.Count)
            {
                result.AddRange(GetRemainingElements(list1, list2));
            }
            else if(list2.Count > list1.Count)
            {
                result.AddRange(GetRemainingElements(list2, list1));
            }
            Console.WriteLine(String.Join(" ", result));
        }
        static List<int> GetRemainingElements(List<int> longerList, List<int> shorterList)
        {
            List<int> remainingElements = new List<int>();
            for (int i =  shorterList.Count; i < longerList.Count; i++)
            {
                remainingElements.Add(longerList[i]);
            }
            return remainingElements;
        }
    }
}
