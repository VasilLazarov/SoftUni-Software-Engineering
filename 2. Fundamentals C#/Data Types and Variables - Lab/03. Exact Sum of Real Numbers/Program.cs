using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            decimal inputNum = decimal.Parse(Console.ReadLine());
            decimal sum = inputNum;
            for (int i = 1; i < n; i++)
            {
                inputNum = decimal.Parse(Console.ReadLine());
                sum += inputNum;
                
            }
            Console.WriteLine(sum);
        }
    }
}
