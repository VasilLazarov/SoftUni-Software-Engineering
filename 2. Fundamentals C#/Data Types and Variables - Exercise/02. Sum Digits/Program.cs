using System;

namespace _02._Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string numLength = num.ToString();
            int sum = 0;
            for(int i = 0; i < numLength.Length; i++)
            {
                sum += num % 10;
                num = num / 10;
            }
            Console.WriteLine(sum);
        }
    }
}
