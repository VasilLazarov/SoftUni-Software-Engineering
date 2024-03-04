using System;
using System.Linq;
using System.Text;

namespace _08._Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder();
            input.Append(Console.ReadLine());
            string[] elementsOfInput = (input.ToString()).Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            double totalSum = 0;
            for (int i = 0; i < elementsOfInput.Length; i++)
            {
                string currentString = elementsOfInput[i];
                char firstLetter = currentString[0];
                char lastLetter = currentString[currentString.Length - 1];
                currentString = currentString.Remove(0, 1);
                currentString = currentString.Remove(currentString.Length - 1, 1);
                double startNumber = int.Parse(currentString);
                double currentSum = 0;
                currentSum = FirstLetterCalculations(startNumber, firstLetter);
                currentSum = LastLetterCalculations(lastLetter, currentSum);
                totalSum += currentSum;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
        static double FirstLetterCalculations(double startNumber, char firstLetter)
        {
            double currentSum = 0;
            if (char.IsUpper(firstLetter))
            {
                currentSum = startNumber / FindLetterPosition(firstLetter);
            }
            else if (char.IsLower(firstLetter))
            {
                currentSum = startNumber * FindLetterPosition(firstLetter);
            }
            return currentSum;
        }
        static double LastLetterCalculations(char lastLetter, double currentSum)
        {
            if (char.IsUpper(lastLetter))
            {
                currentSum -= FindLetterPosition(lastLetter);
            }
            else if (char.IsLower(lastLetter))
            {
                currentSum += FindLetterPosition(lastLetter);
            }
            return currentSum;
        }
        static int FindLetterPosition(char letter)
        {
            int position = 0;
            if (char.IsUpper(letter))
            {
                position = letter - 64;
            }
            else if (char.IsLower(letter))
            {
                position = letter - 96;
            }
            return position;
        }
    }
}
