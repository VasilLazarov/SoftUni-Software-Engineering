using System;
using System.IO;

namespace CopyDirectory
{

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";     //@$"C:\C#\C# Advanced\Projects\Streams, Files and Directories - Exercises\CopyDirectory\folder for copy";
            string outputPath = @$"{Console.ReadLine()}";    //@$"C:\C#\C# Advanced\Projects\Streams, Files and Directories - Exercises\CopyDirectory\folder for copy - copy";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);

            string[] filePaths = Directory.GetFiles(inputPath);
            foreach (var filePath in filePaths)
            {
                string filename = Path.GetFileName(filePath);
                string destination = Path.Combine(outputPath, filename);

                File.Copy(filePath, destination);
            }
        }

    }
}
