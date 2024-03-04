using System;

namespace _1._Christmas_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPaper = int.Parse(Console.ReadLine());
            int numFabric = int.Parse(Console.ReadLine());
            double littersGlue = double.Parse(Console.ReadLine());
            int percentage = int.Parse(Console.ReadLine());
            double totalPrice = numPaper * 5.80 + numFabric * 7.20 + littersGlue * 1.20;
            totalPrice -= totalPrice * (percentage / 100.0);
            Console.WriteLine($"{totalPrice:f3}");
        }
    }
}
