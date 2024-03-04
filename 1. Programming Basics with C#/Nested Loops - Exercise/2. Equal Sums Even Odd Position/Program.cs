using System;

namespace _2._Equal_Sums_Even_Odd_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;
            
            for(int j = startNum; j <= endNum; j++)
            {
                string currentNum = j.ToString();
                for (int i = 0; i <= 5; i++)
                {
                    int dig = int.Parse(currentNum[i].ToString());
                    if (i % 2 == 0)
                    {
                        sumEven += dig;
                    }
                    else
                    {
                        sumOdd += dig;
                    }
                    
                }
                if(sumEven == sumOdd)
                {
                    Console.Write($"{currentNum} ");
                }
                sumOdd = 0;
                sumEven = 0;
                
            }
        }
    }
}
