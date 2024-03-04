using System;
using System.Linq;

namespace _01._The_Imitation_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Decode")
            {
                string[] inputElements = input.Split("|").ToArray();
                string command = inputElements[0];
                if(command == "Move")
                {
                    int numberOfLetters = int.Parse(inputElements[1]);
                    string lettersForMoving = text.Substring(0, numberOfLetters);
                    text = text.Remove(0, numberOfLetters);
                    text += lettersForMoving;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(inputElements[1]);
                    string valueForAdding = inputElements[2];
                    text = text.Insert(index, valueForAdding);
                }
                else if (command == "ChangeAll")
                {
                    string oldString = inputElements[1];
                    string newString = inputElements[2];
                    text = text.Replace(oldString, newString);
                }
            }
            Console.WriteLine($"The decrypted message is: {text}");

        }
    }
}
