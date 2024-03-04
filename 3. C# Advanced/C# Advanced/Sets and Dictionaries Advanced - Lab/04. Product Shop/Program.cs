using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> continents = new Dictionary<string, Dictionary<string, double>>();
            string input = Console.ReadLine();
            while(input != "Revision")
            {
                string[] partsOfInput = input.Split(", ");
                string shop = partsOfInput[0];
                string product = partsOfInput[1];
                double price = double.Parse(partsOfInput[2]);
                if (!continents.ContainsKey(shop))
                {
                    continents.Add(shop, new Dictionary<string, double>());
                }
                if (!continents[shop].ContainsKey(product))
                {
                    continents[shop].Add(product, price);
                }
                else
                {
                    continents[shop][product] = price;
                }
                input = Console.ReadLine();
            }
            continents = continents.OrderBy(v => v.Key)
                    .ToDictionary(v => v.Key, v => v.Value);
            foreach (var shop in continents)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach(var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }


        }
    }
}
