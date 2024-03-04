using System;

namespace _02._Common_Elements___with_array_for_print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split(" ");
            string[] secondArray = Console.ReadLine().Split(" ");
            //string[] forPrinting = new string[firstArray.Length];
            int numForPrint = 0;
            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int v = 0; v < firstArray.Length; v++)
                {
                    if (secondArray[i] == firstArray[v])
                    {
                        //forPrinting[numForPrint] = secondArray[i];
                        //numForPrint++;
                        //break;
                        Console.Write($"{secondArray[i]} ");
                    }
                }
            }
            //Console.WriteLine(String.Join(" ", forPrinting));
        }
    }
}
