using System;
using System.Collections.Generic;
using System.Text;

namespace _03Cards
{
    public class Card
    {
        private string cardFace;
        private char cardSuit;
        private readonly List<string> validCardFaces 
            = new List<string>() 
            { 
                "2", "3", "4", "5", "6", "7", "8", 
                "9", "10", "J", "Q", "K", "A" 
            };
        private readonly Dictionary<char, char> validCardSuits
            = new Dictionary<char, char>()
            {
                { 'S', '\u2660' },
                { 'H', '\u2665' },
                { 'D', '\u2666' },
                { 'C', '\u2663' }
            };

        public Card(string cardFace, char cardSuit)
        {
            CardFace = cardFace;
            CardSuit = cardSuit;
        }

        public string CardFace
        { 
            get { return cardFace; }
            set
            {
                if (!validCardFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                cardFace = value;
            }
        }

        public char CardSuit
        {
            get { return cardSuit; }
            set
            {
                if (!validCardSuits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                cardSuit = validCardSuits[value];
            } 
        }

        public override string ToString()
        {
            return $"[{CardFace}{CardSuit}]";
        }
    }
}
