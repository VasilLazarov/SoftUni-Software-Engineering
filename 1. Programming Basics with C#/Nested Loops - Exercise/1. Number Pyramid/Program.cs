using System;

namespace _1._Number_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            bool isBigger = false;
            int count = 0;
            for(int rows = 1; rows <= n; rows++)
            {
                for(int cols = 1; cols <= rows; cols++)
                {
                    
                    if(num > n)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write($"{num} ");
                    
                    num++;
                }
                if (isBigger)
                {
                    break;
                }
                count++;
                Console.WriteLine();
            }
            Console.WriteLine();
            int num2 = n;
            for (int rows = n; rows >= 1; rows--)
            {
                for (int cols = 1; cols <= count; cols++)
                {
                    if (num2 < 1)
                    {
                        return;
                    }
                    Console.Write($"{num2} ");
                    num2--;
                    
                }
                count--;
                Console.WriteLine();
            }
        }
    }
}
