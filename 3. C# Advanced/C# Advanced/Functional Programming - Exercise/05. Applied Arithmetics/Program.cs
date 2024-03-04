using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<string, List<int>, List<int>> doOperation = (cmd, nums) => DoOperation(cmd, nums);
            //{
            //    return DoOperation(cmd, nums);
            //};

            Action<List<int>> print = numbers => Console.WriteLine(String.Join(" ", numbers));

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if(command == "print")
                {
                    print(numbers);
                }
                else
                {
                    numbers = doOperation(command, numbers);
                }
            }
        }

        static List<int> DoOperation(string cmd, List<int> nums)
        {
            List<int> newList = new List<int>();
            foreach (int i in nums)
            {
                switch (cmd)
                {
                    case "add":
                        newList.Add(i + 1);
                        break;
                    case "multiply":
                        newList.Add(i * 2);
                        break;
                    case "subtract":
                        newList.Add(i - 1);
                        break;
                }
            }
            return newList;
        }
    }
}
