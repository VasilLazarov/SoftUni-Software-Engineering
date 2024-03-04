using System;

namespace _02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string forPrinting = "";
            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int v = 0; v < firstArray.Length; v++)
                {
                    if(secondArray[i] == firstArray[v])
                    {
                        forPrinting += (secondArray[i] + " ");
                    }
                }
            }
            Console.WriteLine(forPrinting);
        }
    }
}
