using System;
using System.Text;

namespace _01._Decrypting_Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            text.Append(Console.ReadLine());
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Finish")
            {
                string[] inputElements = input.Split(' ');
                string command = inputElements[0];
                if(command == "Replace")
                {
                    string currentElem = inputElements[1];
                    string newElem = inputElements[2];
                    text.Replace(currentElem, newElem);
                    Console.WriteLine(text.ToString());
                }
                else if(command == "Cut")
                {
                    int startIndex = int.Parse(inputElements[1]);
                    int endIndex = int.Parse(inputElements[2]);
                    //if(startIndex > endIndex)
                    //{
                    //    int a = startIndex;
                    //    startIndex = endIndex;
                    //    endIndex = a;
                    //}
                    int length = endIndex - startIndex + 1;
                    if (startIndex >= 0 && startIndex < text.Length && length > 0 && length < text.Length - startIndex)
                    {
                        text.Remove(startIndex, length);
                        Console.WriteLine(text.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
                else if (command == "Make")
                {
                    string upOrLow = inputElements[1];
                    if(upOrLow == "Upper")
                    {
                        string changedtext = text.ToString().ToUpper();
                        text.Clear();
                        text.Append(changedtext);
                    }
                    else if(upOrLow == "Lower")
                    {
                        string changedtext = text.ToString().ToLower();
                        text.Clear();
                        text.Append(changedtext);
                    }
                    Console.WriteLine(text.ToString());
                }
                else if (command == "Check")
                {
                    string textForSearch = inputElements[1];
                    if (text.ToString().Contains(textForSearch))
                    {
                        Console.WriteLine($"Message contains {textForSearch}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {textForSearch}");
                    }
                }
                else if (command == "Sum")
                {
                    int startIndex = int.Parse(inputElements[1]);
                    int endIndex = int.Parse(inputElements[2]);
                    if(startIndex >= 0 && startIndex < text.Length && endIndex >= 0 && endIndex < text.Length)
                    {
                        string subString = text.ToString().Substring(startIndex, endIndex - startIndex + 1);
                        int sumOfSymbols = 0;
                        for(int i = 0; i < subString.Length; i++)
                        {
                            sumOfSymbols += subString[i];
                        }
                        Console.WriteLine(sumOfSymbols);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indices!");
                    }
                }
            }
        }
    }
}
