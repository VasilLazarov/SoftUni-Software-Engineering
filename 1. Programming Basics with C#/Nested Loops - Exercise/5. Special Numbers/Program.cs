using System;

namespace _5._Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string number = "";
            int num = 0;
            bool special = true;
            for(int i = 1111; i <= 9999; i++)
            {
                number = i.ToString();
                for (int j = 0; j < 4; j++) 
                {
                    num = int.Parse(number[j].ToString());
                    if (num == 0)
                    {
                        special = false;
                        break;
                    }
                    else if (n % num != 0)
                    {
                        special = false;
                        break;
                    }
                }
                if (special)
                {
                    Console.Write($"{i} ");
                }
                special = true;
            }
        }
    }
}
