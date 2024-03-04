using System;

namespace Test
{
    internal class Program
    {
        //revers string - working
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string correctPass = "";
            for (int i = username.Length - 1; i >= 0; i--)
            {
                correctPass += username[i];
            }
            Console.WriteLine(correctPass);
        }
    }
}
