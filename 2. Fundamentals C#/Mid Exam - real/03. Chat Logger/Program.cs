using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _03._Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chatElements = new List<string>();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "end")
            {
                string[] inputElements = input.Split(" ");
                string command = inputElements[0];
                if(command == "Chat")
                {
                    string text = string.Join(" ", inputElements.Skip(1));
                    chatElements.Add(text);
                }
                else if(command == "Delete")
                {
                    string text = string.Join(" ", inputElements.Skip(1));
                    chatElements.Remove(text);
                }
                else if (command == "Edit")
                {
                    string text = inputElements[1];
                    string editedText = inputElements[2];
                    int indexForEdit = chatElements.FindIndex(x => x == text);
                    if(indexForEdit >= 0 && indexForEdit < chatElements.Count)
                    {
                        chatElements[indexForEdit] = editedText;
                    }
                }
                else if (command == "Pin")
                {
                    string text = string.Join(" ", inputElements.Skip(1));
                    int indexForEdit = chatElements.FindIndex(x => x == text);
                    if( indexForEdit >= 0 && indexForEdit < chatElements.Count)
                    {
                        string movedElement = chatElements[indexForEdit];
                        chatElements.RemoveAt(indexForEdit);
                        chatElements.Add(movedElement);
                    }
                }
                else if (command == "Spam")
                {
                    string[] elementsForAdd = (string.Join(" ", inputElements.Skip(1))).Split(" ").ToArray();
                    for (int i = 0; i < elementsForAdd.Length; i++)
                    {
                        chatElements.Add(elementsForAdd[i]);
                    }
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, chatElements));
        }
    }
}
