namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

          GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            decimal fullSize = GetFolderSize(folderPath, 0)/1024;
            File.WriteAllText(outputFilePath, $"{fullSize} KB");
        }
        public static decimal GetFolderSize(string folderPath, int level)
        {
            string spaces = new string(' ', level * 3);
            string spacess = new string(' ', (level+1) * 3);
            Console.WriteLine($"{spaces}{new DirectoryInfo(folderPath).Name}");
            string[] filePaths = Directory.GetFiles(folderPath);

            decimal size = 0;

            foreach (var filePath in filePaths)
            {
                FileInfo info = new FileInfo(filePath);
                size += info.Length;
                Console.WriteLine($"{spacess}{info.Name}");
            }
            
            foreach (var dirPaths in Directory.GetDirectories(folderPath))
            {
                size += GetFolderSize(dirPaths, level + 1);
            }
            return size;
        }
    }
}
