using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string inputCommand = string.Empty;
            while((inputCommand = Console.ReadLine()) != "3:1")
            {
                string[] inputcmd = inputCommand
                    .Split()
                    .ToArray();
                string command = inputcmd[0];
                if(command == "merge")
                {
                    int startIndex = int.Parse(inputcmd[1]);
                    int endIndex = int.Parse(inputcmd[2]);
                    CheckIndexes(input, ref startIndex, ref endIndex);
                    MergeElements(input, startIndex, endIndex);
                }
                else if(command == "divide")
                {
                    int index = int.Parse(inputcmd[1]);
                    int partitions = int.Parse(inputcmd[2]);

                    string word = input[index];
                    List<string> partitionsList = DivideWord(word, partitions);
                    input.RemoveAt(index);
                    input.InsertRange(index, partitionsList);
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }
        static void CheckIndexes(List<string> input, ref int startIndex, ref int endIndex)
        {
            if(startIndex < 0)
            {
                startIndex = 0;
            }
            else if(startIndex >= input.Count)
            {
                startIndex = input.Count - 1;
            }
            if (endIndex < 0)
            {
                endIndex = 0;
            }
            else if (endIndex >= input.Count)
            {
                endIndex = input.Count - 1;
            }
        }
        static void MergeElements(List<string> input, int startIndex, int endIndex)
        {
            string mergedText = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedText += input[startIndex];
                input.RemoveAt(startIndex);
            }
            input.Insert(startIndex, mergedText);
        }
        static List<string> DivideWord(string word, int partitions)
        {
            List<string> result = new List<string>();
            int subStringLength = word.Length / partitions;
            int lastSubStringLength = word.Length / partitions + word.Length % partitions;
            for (int i = 0; i < partitions; i++)
            {
                int nextElementLendth = subStringLength;
                if(i == partitions - 1)
                {
                    nextElementLendth = lastSubStringLength;
                }
                char[] newPatitionArr = word
                    .Skip(i * subStringLength)
                    .Take(nextElementLendth)
                    .ToArray();
                string newPatition = string.Join("", newPatitionArr);
                result.Add(newPatition);
            }
            return result;
        }
    }
}
