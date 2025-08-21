using System;
using System.Collections.Generic;

namespace Cards
{
    class Hand
    {
        public const int HandSize = 13;
        private List<PlayingCard> cards = new List<PlayingCard>(HandSize);
        // private int playingCardCount = 0;

        public void AddCardToHand(PlayingCard cardDealt)
        {
            if (this.cards.Count >= HandSize)
            {
                throw new ArgumentException("Too many cards");
            }
            this.cards.Add(cardDealt);
        }

        public override string ToString()
        {
            string result = "";
            foreach (PlayingCard card in this.cards)
            {
                result += card.ToString() + "\n";
            }

            return result;
        }
    }
}