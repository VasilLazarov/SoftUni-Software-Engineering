using System;
using System.Collections.Generic;

namespace _03Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            Card card = null;
            string[] inputCards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string inputCard in inputCards)
            {
                string[] cardElements = inputCard
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string cardFace = cardElements[0];
                    char cardSuit = char.Parse(cardElements[1]);
                    card = new Card(cardFace, cardSuit);
                    cards.Add(card);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid card!");
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(String.Join(" ", cards));
        }
    }
}
