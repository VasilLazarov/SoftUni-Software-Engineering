using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool haveChangesOnList = false;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> inputElements = input.Split(" ").ToList();
                string command = inputElements[0];
                if (command == "Contains")
                {
                    int number = int.Parse(inputElements[1]);
                    CheckContainsNumber(numbers, number);
                }
                else if (command == "PrintEven")
                {
                    PrintEvenNumbers(numbers);
                }
                else if (command == "PrintOdd")
                {
                    PrintOddNumbers(numbers);
                }
                else if (command == "GetSum")
                {
                    GetSumOfElements(numbers);
                }
                else if (command == "Filter")
                {
                    int number = int.Parse(inputElements[2]);
                    string condition = inputElements[1];
                    PrintNumbersAfterFilter(numbers, condition, number);
                }
                else if (command == "Add")
                {
                    haveChangesOnList = true;
                    int number = int.Parse(inputElements[1]);
                    AddElementToList(numbers, number);
                }
                else if (command == "Remove")
                {
                    haveChangesOnList = true;
                    int number = int.Parse(inputElements[1]);
                    RemoveElementFromList(numbers, number);
                }
                else if (command == "RemoveAt")
                {
                    haveChangesOnList = true;
                    int index = int.Parse(inputElements[1]);
                    RemoveElementAtIndex(numbers, index);
                }
                else if (command == "Insert")
                {
                    haveChangesOnList = true;
                    int number = int.Parse(inputElements[1]);
                    int index = int.Parse(inputElements[2]);
                    InsertElementAtIndex(numbers, number, index);
                }
            }
            if (haveChangesOnList)
            {
                Console.WriteLine(String.Join(" ", numbers));
            }
        }
        static void CheckContainsNumber(List<int> numbers, int number)
        {
            if (numbers.Contains(number))
            {
                Console.WriteLine("Yes");
                return;
            }
            Console.WriteLine("No such number");
        }
        static void PrintEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if(number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            Console.WriteLine(String.Join(" ", evenNumbers));
        }
        static void PrintOddNumbers(List<int> numbers)
        {
            List<int> oddNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    oddNumbers.Add(number);
                }
            }
            Console.WriteLine(String.Join(" ", oddNumbers));
        }
        static void GetSumOfElements(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }
        static void PrintNumbersAfterFilter(List<int> numbers, string condition, int number)
        {
            List<int> numbersAfterFilter = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                switch (condition)
                {
                    case "<":
                        if (numbers[i] < number)
                        {
                            numbersAfterFilter.Add(numbers[i]);
                        }
                        break;
                    case ">":
                        if (numbers[i] > number)
                        {
                            numbersAfterFilter.Add(numbers[i]);
                        }
                        break;
                    case "<=":
                        if (numbers[i] <= number)
                        {
                            numbersAfterFilter.Add(numbers[i]);
                        }
                        break;
                    case ">=":
                        if (numbers[i] >= number)
                        {
                            numbersAfterFilter.Add(numbers[i]);
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", numbersAfterFilter));
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
