using System;
using System.IO;
using System.Text;

namespace Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream("../../../text.txt", FileMode.Create);
            string text = "Кирилица";
            using (file)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                file.Write(buffer, 0, buffer.Length);
            }


        }
    }
}
