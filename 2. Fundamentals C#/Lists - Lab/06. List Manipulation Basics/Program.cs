using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
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
                List<string> inputElements = input.Split(" ").ToList();
                string command = inputElements[0];
                if(command == "Add")
                {
                    int number = int.Parse(inputElements[1]);
                    AddElementToList(numbers, number);
                }
                else if(command == "Remove")
                {
                    int number = int.Parse(inputElements[1]);
                    RemoveElementFromList(numbers, number);
                }
                else if (command == "RemoveAt")
                {
                    int index = int.Parse(inputElements[1]);
                    RemoveElementAtIndex(numbers, index);
                }
                else if (command == "Insert")
                {
                    int number = int.Parse(inputElements[1]);
                    int index = int.Parse(inputElements[2]);
                    InsertElementAtIndex(numbers, number, index);
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
        static void AddElementToList(List<int> numbers, int numForAdd)
        {
            numbers.Add(numForAdd);
        }
        static void RemoveElementFromList(List<int> numbers, int numForRemove)
        {
            numbers.Remove(numForRemove);
        }
        static void RemoveElementAtIndex(List<int> numbers, int indexOfRemovingNum)
        {
            numbers.RemoveAt(indexOfRemovingNum);
        }
        static void InsertElementAtIndex(List<int> numbers, int number, int index)
        {
            numbers.Insert(index, number);
        }
    }
}
