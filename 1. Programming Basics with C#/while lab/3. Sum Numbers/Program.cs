using System;

namespace _3._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = 0;
            while(sum < total)
            {
                num = int.Parse((Console.ReadLine()));
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
