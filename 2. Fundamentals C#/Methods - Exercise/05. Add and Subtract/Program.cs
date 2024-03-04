using System;

namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int sum = SumNum1AndNum2(num1, num2);
            Console.WriteLine(SubtractNum3(sum, num3));
        }

        static int SumNum1AndNum2(int num1, int num2)
        {
            return num1 + num2;
        }
        static int SubtractNum3(int sum, int num3)
        {
            return sum - num3;
        }
    }
}
