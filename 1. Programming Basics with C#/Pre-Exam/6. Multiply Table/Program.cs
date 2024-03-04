using System;

namespace _6._Multiply_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string number = num.ToString();
            int fnum = int.Parse(number[0].ToString());
            int snum = int.Parse(number[1].ToString());
            int thnum = int.Parse(number[2].ToString());
            for (int i = 1; i <= thnum; i++)
            {
                for(int j = 1; j <= snum; j++)
                {
                    for(int k = 1; k <= fnum; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j *k};");
                    }
                }
            }
        }
    }
}
