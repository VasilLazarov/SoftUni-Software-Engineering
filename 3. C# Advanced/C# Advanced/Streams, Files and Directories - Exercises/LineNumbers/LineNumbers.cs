namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            for (int v = 0; v < lines.Length; v++)
            {
                //int letters = 0;                    //use Linq below for same results
                //int punctuationMarks = 0;
                //foreach (char c in lines[v])
                //{
                //    if (c == ' ')
                //    {
                //        continue;
                //    }
                //    else if (char.IsPunctuation(c))
                //    {
                //        punctuationMarks++;
                //    }
                //    else
                //    {
                //        letters++;
                //    }
                //}
                int letters = lines[v].Count(char.IsLetter);
                int punctuationMarks = lines[v].Count(char.IsPunctuation);
                lines[v] = $"Line {v + 1}: {lines[v]} ({letters}) ({punctuationMarks})";
            }
            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
