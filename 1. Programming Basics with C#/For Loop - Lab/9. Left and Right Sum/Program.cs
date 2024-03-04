using System;

namespace _9._Left_and_Right_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            for(int x = 1; x <= (n*2); x++)
            {
                int num = int.Parse(Console.ReadLine());
                if(x <= n)
                {
                    sum1 += num;
                }
                else
                {
                    sum2 += num;
                }

            }
            if(sum1 == sum2)
            {
                Console.WriteLine($"Yes, sum = {sum1}");
            }
            else
            {
                int diff = Math.Abs(sum1 - sum2);
                Console.WriteLine($"No, diff = {diff}");
            }
        }
    }
}
