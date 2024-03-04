using System;
using System.IO;

namespace Directories
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[] fileNames = Directory.GetFiles("../../../");
            foreach (string file in fileNames)
            {
                Console.WriteLine(file);
                FileInfo info = new FileInfo(file);
                Console.WriteLine(info.Name);
                Console.WriteLine(info.Extension);
                Console.WriteLine(info.Length);
                Console.WriteLine();
            }

            string[] subDirectories = Directory.GetDirectories("../../../");
            foreach (string file in subDirectories)
            {
                Console.WriteLine(file);
                DirectoryInfo info = new DirectoryInfo(file);
                Console.WriteLine(info.Name);
                Console.WriteLine();
            }

            //Directory.Delete("../../../TestFolder", true);
            //Directory.CreateDirectory("../../../TestFolder");
            //Directory.CreateDirectory("../../../TestFolder1");
            //Directory.Move("../../../TestFolder1", "../../../TestFolder/TestFolder1");
        }
    }
}
