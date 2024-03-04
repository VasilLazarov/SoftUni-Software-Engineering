using System;
using System.IO;

namespace WriteInTextFIle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("../../../output.txt");
            using (writer)
            {
                for (int i = 1; i <= 10; i++)
                {
                    writer.WriteLine($"Line {i}");
                }
            }
        }
    }
}
