using System;

namespace _4._Even_Powers_of_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int k = 0; k<=n; k += 2)
            {
                double sum = Math.Pow(2, k);
                Console.WriteLine(sum);
            }
        }
    }
}
