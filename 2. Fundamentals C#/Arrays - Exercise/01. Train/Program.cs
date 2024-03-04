using System;
using System.Linq;

namespace _01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] passengersInThisWagon = new int[n];
            int totapPassengers = 0;
            for (int i = 0; i < n; i++)
            {
                passengersInThisWagon[i] = int.Parse(Console.ReadLine());
                totapPassengers += passengersInThisWagon[i];
            }
            Console.WriteLine(String.Join(" ", passengersInThisWagon));
            Console.WriteLine(totapPassengers);
        }
    }
}
