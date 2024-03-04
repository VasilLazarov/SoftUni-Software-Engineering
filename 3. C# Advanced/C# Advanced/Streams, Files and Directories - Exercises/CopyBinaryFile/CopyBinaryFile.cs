namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream readFile = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] buffer = new byte[readFile.Length];
                readFile.Read(buffer, 0, buffer.Length);
                using (FileStream writeFile = new FileStream(outputFilePath, FileMode.CreateNew))
                {
                        writeFile.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
