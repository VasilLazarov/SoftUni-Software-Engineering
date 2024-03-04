namespace EvenLines
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int lineCount = 0;
                while (line != null)
                {
                    if (lineCount % 2 == 0)
                    {
                        line = ReplaceSymbols(line);
                        line = ReversWords(line);
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    lineCount++;
                }
            }
            return null;
        }

        public static string ReplaceSymbols(string line)
        {
            StringBuilder text = new StringBuilder(line);
            char[] charsForReplace = { '-', ',', '.', '!', '?' };
            foreach (var symbol in charsForReplace)
            {
                text.Replace(symbol, '@');
            }
            line = text.ToString();
            return line;
        }
        public static string ReversWords(string line)
        {
            string[] reversWords = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(reversWords);
            line = string.Join(" ", reversWords);
            return line;
        }
    }
}
