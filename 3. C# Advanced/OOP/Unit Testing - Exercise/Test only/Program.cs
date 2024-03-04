using System;
using System.IO;

namespace Test_only
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Console.WriteLine("Hello");

            var output = stringWriter.ToString();
            Console.WriteLine("result");
            Console.WriteLine(output);
        }
    }
}
