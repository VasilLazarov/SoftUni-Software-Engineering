namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                string line = reader.ReadLine();
                int lineCount = 1;
                StreamWriter writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    while(line != null)
                    {
                        writer.WriteLine($"{lineCount}. {line}");
                        line = reader.ReadLine();
                        lineCount++;
                    }
                }
            }
        }
    }
}
