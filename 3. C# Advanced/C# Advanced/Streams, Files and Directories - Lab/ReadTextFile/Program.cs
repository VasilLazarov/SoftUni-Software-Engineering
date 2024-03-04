using System;
using System.IO;

namespace ReadTextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                int lineCount = 1;
                string line = reader.ReadLine();
                while(line != null)
                {
                    Console.WriteLine($"{lineCount}. {line}");
                    lineCount++;
                    line = reader.ReadLine();
                }
            }



        }
    }
}
