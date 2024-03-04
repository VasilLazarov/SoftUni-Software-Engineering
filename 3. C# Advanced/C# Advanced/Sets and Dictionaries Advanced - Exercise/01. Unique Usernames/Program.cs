using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                string userName = Console.ReadLine();
                uniqueUsernames.Add(userName);
            }
            foreach (string userName in uniqueUsernames)
            {
                Console.WriteLine(userName);
            }
        }
    }
}
