using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<double, int>> products = new Dictionary<string, Dictionary<double, int>>();
            string input;
            while((input = Console.ReadLine()) != "buy")
            {
                string[] inputElements = input.Split(" ");
                string currentProduct = inputElements[0];
                double currentPrice = double.Parse(inputElements[1]);
                int currentQuantity = int.Parse(inputElements[2]);
                int addQuantity = 0;
                double currentKey = 0;
                if (!products.ContainsKey(currentProduct))
                {
                    products.Add(currentProduct, new Dictionary<double, int>());
                    products[currentProduct].Add(currentPrice, currentQuantity);
                }
                else
                {
                    foreach (var item in products[currentProduct])
                    {
                        addQuantity = item.Value + currentQuantity;
                        currentKey = item.Key;
                    }
                    products[currentProduct].Remove(currentKey);
                    products[currentProduct].Add(currentPrice, addQuantity);
                }
            }
            foreach (var product in products)
            {
                var currProductValue = product.Value;
                foreach(var item in currProductValue)
                {
                    double totalPrice = item.Key * item.Value;
                    Console.WriteLine($"{product.Key} -> {totalPrice:f2}");

                }
            }
        }
    }
}
