using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] symbolsForSplit = new string[] {" -> ", ","};
                string[] input = Console.ReadLine()
                    .Split(symbolsForSplit, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int v = 1; v < input.Length; v++)
                {
                    string garment = input[v];
                    if (!wardrobe[color].ContainsKey(garment))
                    {
                        wardrobe[color].Add(garment, 0);
                    }
                    wardrobe[color][garment]++;
                }
            }
            string[] garmentForSearch = Console.ReadLine()
                .Split(" ");
            string colorForS = garmentForSearch[0];
            string garmentForS = garmentForSearch[1];
            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var garm in item.Value)
                {
                    if(item.Key == colorForS && garm.Key == garmentForS)
                    {
                        Console.WriteLine($"* {garm.Key} - {garm.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {garm.Key} - {garm.Value}");
                }
            }
        }
    }
}
