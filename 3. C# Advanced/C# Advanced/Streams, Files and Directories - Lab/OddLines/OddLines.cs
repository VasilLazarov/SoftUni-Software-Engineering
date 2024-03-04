namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader(inputFilePath);
            using (reader)
            {
                string line = reader.ReadLine();
                int lineCount = 0;
                StreamWriter writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    while (line != null)
                    {
                        if (lineCount % 2 == 1)
                        {

                            writer.WriteLine(line);
                        }
                        line = reader.ReadLine();
                        lineCount++;
                    }
                }

            }
        }
    }
}
