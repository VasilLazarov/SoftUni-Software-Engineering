namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = @"C:\Users\USER\Downloads";
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder textForOutput = new StringBuilder();
            SortedDictionary<string, List<FileInfo>> allFiles = new SortedDictionary<string, List<FileInfo>>();

            string[] filePaths = Directory.GetFiles(inputFolderPath);

            foreach (var filePath in filePaths)
            {
                FileInfo info = new FileInfo(filePath);
                if (!allFiles.ContainsKey(info.Extension))
                {
                    allFiles[info.Extension] = new List<FileInfo>();
                }
                allFiles[info.Extension].Add(info);
            }
            //allFiles.OrderByDescending(x => x.Value.Count);
            foreach (var file in allFiles.OrderByDescending(x => x.Value.Count))
            {
                textForOutput.AppendLine(file.Key);
                foreach (var fileInfo in file.Value.OrderBy(x => x.Length))
                {
                    double size = fileInfo.Length / (double)1024;
                    textForOutput.AppendLine($"--{fileInfo.Name} - {size}kb");
                }
            }
            return textForOutput.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }
}
