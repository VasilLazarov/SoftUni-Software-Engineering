using System;
using System.Collections.Generic;

namespace _03._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> shopInventory = new Dictionary<string, int>();
            string input = string.Empty;
            int numberOfSoldGoods = 0;
            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] inputElements = input.Split(" ");
                string command = inputElements[0];
                int quantity = int.Parse(inputElements[1]);
                string food = inputElements[2];
                if (command == "Receive")
                {
                    if(quantity <= 0)
                    {
                        break;
                    }
                    if (!shopInventory.ContainsKey(food))
                    {
                        shopInventory.Add(food, quantity);
                    }
                    else
                    {
                        shopInventory[food] += quantity;
                    }
                }
                else if(command == "Sell")
                {
                    if (!shopInventory.ContainsKey(food))
                    {
                        Console.WriteLine($"You do not have any {food}.");
                    }
                    else
                    {
                        if(quantity > shopInventory[food])
                        {
                            numberOfSoldGoods += shopInventory[food];
                            Console.WriteLine($"There aren't enough {food}. You sold the last {shopInventory[food]} of them.");
                            shopInventory[food] = 0;
                        }
                        else if (quantity <= shopInventory[food])
                        {
                            Console.WriteLine($"You sold {quantity} {food}.");
                            shopInventory[food] -= quantity;
                            numberOfSoldGoods += quantity;
                        }
                    }
                }
                if (shopInventory.ContainsKey(food))
                {
                    if (shopInventory[food] <= 0)
                    {
                        shopInventory.Remove(food);
                    }
                }
            }
            foreach (var item in shopInventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine($"All sold: {numberOfSoldGoods} goods");
        }
    }
}
