using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            //HashSet<string> elements = new HashSet<string>();
            SortedSet<string> elements = new SortedSet<string>();
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ");
                //foreach (string element in input)
                //{
                //    elements.Add(element);
                //}
                elements.UnionWith(input);
            }
            //elements = elements.OrderBy(v => v).ToHashSet();
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
