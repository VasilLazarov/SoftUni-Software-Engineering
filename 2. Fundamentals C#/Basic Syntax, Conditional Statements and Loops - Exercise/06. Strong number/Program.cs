using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string wow = Convert.ToString(input);
            int num = 0;
            int fact = 1;
            int sum = 0;
            for (int i = 0; i < wow.Length; i++)
            {
                fact = 1;
                num = int.Parse(wow[i].ToString());
                for (int v = 1; v <= num; v++)
                {
                    fact = fact * v;
                }
                sum += fact;
            }
            if(sum == input)
            {
                Console.WriteLine("yes");

            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
