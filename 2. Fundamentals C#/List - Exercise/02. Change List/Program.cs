using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputs = input.Split();
                string command = inputs[0];
                if(command == "Delete")
                {
                    int element = int.Parse(inputs[1]);
                    numbers.RemoveAll(x => x == element);
                }
                else if(command == "Insert")
                {
                    int element = int.Parse(inputs[1].ToString());
                    int position = int.Parse(inputs[2].ToString());
                    numbers.Insert(position, element);
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
