using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> orders = new Queue<int>(input);

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                quantityFood -= orders.Peek();
                if(quantityFood >= 0)
                {
                    orders.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
