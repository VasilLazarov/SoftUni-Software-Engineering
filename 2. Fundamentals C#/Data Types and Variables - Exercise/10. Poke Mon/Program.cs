using System;

namespace _10._Poke_Mon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());
            double originalN = N/2.0;
            int numOfPokes = 0;
            while(N >= M)
            {
                N -= M;
                numOfPokes++;
                if(N == originalN)
                {
                    if(Y != 0)
                    {
                        N /= Y;
                    }
                }
            }
            Console.WriteLine($"{N}\n{numOfPokes}");
        }
    }
}
