using System;

namespace Test_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPass = "";
            char[] userN = username.ToCharArray();
            Array.Reverse(userN);
            correctPass = new string(userN);
            Console.WriteLine(correctPass);
        }
    }
}
