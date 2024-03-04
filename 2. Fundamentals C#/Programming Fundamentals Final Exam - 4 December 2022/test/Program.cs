using System;
using System.Collections.Generic;
using System.Text;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append("WELIK3SOFTUNI");
            text.Remove(1, 4);
            Console.WriteLine(text);
        }
    }
}
