using System;
using System.Numerics;

namespace _11._Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            BigInteger snowballValue = 0;
            BigInteger bestValue = 0;
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;
            for (int i = 0; i < n; i++)
            {
                snowballSnow = int.Parse(Console.ReadLine());
                snowballTime = int.Parse(Console.ReadLine());
                snowballQuality = int.Parse(Console.ReadLine());
                snowballValue = BigInteger.Pow((snowballSnow/snowballTime), snowballQuality);
                if(snowballValue >= bestValue)
                {
                    bestValue = snowballValue;
                    bestQuality = snowballQuality;
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                }
            }
            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");
        }
    }
}
