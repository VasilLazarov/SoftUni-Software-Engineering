using System;

namespace more_ex._8._Equal_Pairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int sum = num1 + num2;
            int diff = 0;
            int currentSum;
            bool check = true;
            for(int i = 1; i < count; i++)
            {
                num1 = int.Parse(Console.ReadLine());
                num2 = int.Parse(Console.ReadLine());
                currentSum = num1 + num2;
                if(currentSum != sum)
                {
                    check = false;
                    int currentDiff = Math.Abs(currentSum - sum);
                    if(currentDiff > diff)
                    {
                        diff = currentDiff;
                    }
                    sum = currentSum;
                }
            }
            if (check)
            {
                Console.WriteLine($"Yes, value={sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
