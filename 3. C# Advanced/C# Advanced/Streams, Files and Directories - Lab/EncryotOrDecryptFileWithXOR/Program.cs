using System;
using System.IO;

namespace EncryotOrDecryptFileWithXOR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string basePath = "../../../Images/";
            int imageNumber = 1;
            EncryptImages(basePath, imageNumber);
            //DecryptImages(basePath, imageNumber);
        }
        public static void EncryptImages(string basePath, int imageNumber)
        {
            while (File.Exists($"{basePath}{imageNumber}.jpg"))
            {
                using (var stream = new FileStream($"{basePath}{imageNumber}.jpg", FileMode.Open))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);

                    using (var encryptedStream = new FileStream($"{basePath}{imageNumber}.encrypted.jpg", FileMode.OpenOrCreate))
                    {
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            buffer[i] = (byte)(buffer[i] ^ 157);
                        }

                        encryptedStream.Write(buffer, 0, buffer.Length);
                    }

                }
                imageNumber++;
            }
        }

        public static void DecryptImages(string basePath, int imageNumber)
        {
            while (File.Exists($"{basePath}{imageNumber}.encrypted.png"))
            {
                using (var stream = new FileStream($"{basePath}{imageNumber}.encrypted.png", FileMode.Open))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);

                    using (var encryptedStream = new FileStream($"{basePath}{imageNumber}.png", FileMode.OpenOrCreate))
                    {
                        for (int i = 0; i < buffer.Length; i++)
                        {
                            buffer[i] = (byte)(buffer[i] ^ 157);
                        }

                        encryptedStream.Write(buffer, 0, buffer.Length);
                    }

                }
                imageNumber++;
            }
        }
    }
}
