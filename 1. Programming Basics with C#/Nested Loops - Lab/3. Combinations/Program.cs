using System;

namespace _3._Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int count = 0;
            for(int i = 0; i <= num; i++)
            {
                for(int j = 0; j <= num; j++)
                {
                    for(int d = 0; d <= num; d++)
                    {
                        if(i + j + d == num)
                        {
                            count++;
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
