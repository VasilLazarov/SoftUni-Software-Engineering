using System;
using System.Collections;
using System.Collections.Generic;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> pieces = new Dictionary<string, Dictionary<string, string>>();
            int numberOfStartingPieces = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfStartingPieces; i++)
            {
                string[] pieceElements = Console.ReadLine()
                    .Split("|");
                string nameOfPiece = pieceElements[0];
                string composer = pieceElements[1];
                string key = pieceElements[2];
                pieces.Add(nameOfPiece, new Dictionary<string, string>());
                pieces[nameOfPiece].Add(composer, key);
            }
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Stop")
            {
                string[] inputElements = input
                    .Split("|");
                string command = inputElements[0];
                string nameOfPiece = inputElements[1];
                if(command == "Add")
                {
                    string composer = inputElements[2];
                    string key = inputElements[3];
                    if (!pieces.ContainsKey(nameOfPiece))
                    {
                        pieces.Add(nameOfPiece, new Dictionary<string, string>());
                        pieces[nameOfPiece].Add(composer, key);
                        Console.WriteLine($"{nameOfPiece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfPiece} is already in the collection!");
                    }
                }
                else if(command == "Remove")
                {
                    if (pieces.ContainsKey(nameOfPiece))
                    {
                        pieces.Remove(nameOfPiece);
                        Console.WriteLine($"Successfully removed {nameOfPiece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {nameOfPiece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string key = inputElements[2];
                    string composer = string.Empty;
                    if (pieces.ContainsKey(nameOfPiece))
                    {
                        foreach (var item in pieces[nameOfPiece])
                        {
                            composer = item.Key;
                        }
                        pieces[nameOfPiece][composer] = key;
                        Console.WriteLine($"Changed the key of {nameOfPiece} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {nameOfPiece} does not exist in the collection.");
                    }
                }
            }
            foreach (var item in pieces)
            {
                foreach (var iteem in item.Value)
                {
                    Console.WriteLine($"{item.Key} -> Composer: {iteem.Key}, Key: {iteem.Value}");
                }
            }
        }
    }
}
