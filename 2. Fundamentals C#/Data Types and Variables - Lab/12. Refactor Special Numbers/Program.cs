using System;

namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool special = false;
            for (int i = 1; i <= num; i++)
            {
                int numForChanging = i;
                int sum = 0;
                while (numForChanging > 0)
                {
                    sum += numForChanging % 10;
                    numForChanging = numForChanging / 10;
                }
                special = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, special);
            }

        }
    }
}
