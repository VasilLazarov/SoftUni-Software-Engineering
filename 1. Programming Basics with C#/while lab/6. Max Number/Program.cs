using System;

namespace _6._Max_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int num = 0;
            int maxNum = int.MinValue;
            while(input != "Stop")
            {
                num = int.Parse(input);
                if(num > maxNum)
                {
                    maxNum = num;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}
