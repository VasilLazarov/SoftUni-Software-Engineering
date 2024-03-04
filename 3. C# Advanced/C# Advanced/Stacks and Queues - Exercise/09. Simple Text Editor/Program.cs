using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> textModifications = new Stack<string>();

            StringBuilder currentText = new StringBuilder();

            int countOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                int command = int.Parse(input[0]);
                switch (command)
                {
                    case 1:
                        textModifications.Push(currentText.ToString());
                        currentText.Append(input[1]);
                        break;
                    case 2:
                        textModifications.Push(currentText.ToString());
                        int countOfElementsForRemove = int.Parse(input[1]);
                        currentText = currentText.Remove(currentText.Length - countOfElementsForRemove, countOfElementsForRemove);
                        break;
                    case 3:
                        int positionIndex = int.Parse(input[1]);
                        Console.WriteLine(currentText[positionIndex - 1]);
                        break;
                    case 4:
                        if (textModifications.Any())
                        {
                            currentText = new StringBuilder(textModifications.Pop());
                        }
                        break;
                }
            }
        }
    }
}
