using System;

namespace _1._Sum_Seconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int totalTime = firstTime + secondTime + thirdTime;
            int min = totalTime / 60;
            int sec = totalTime % 60;
            Console.WriteLine($"{min}:{sec:d2}");
        }
    }
}
