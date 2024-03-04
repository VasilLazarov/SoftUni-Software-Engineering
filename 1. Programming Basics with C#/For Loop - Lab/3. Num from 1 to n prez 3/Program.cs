using System;

namespace _3._Num_from_1_to_n_prez_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int k = 1; k <= n; k +=3)
            {
                Console.WriteLine(k);
            }
        }
    }
    
}
