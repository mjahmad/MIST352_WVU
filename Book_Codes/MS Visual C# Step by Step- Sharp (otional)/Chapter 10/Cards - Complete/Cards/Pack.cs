using System;

namespace Cards
{	
	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private PlayingCard[,] cardPack;
        private Random randomCardSelector = new Random();

        public Pack()
        {
            this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];
            for (var suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (var value = Value.Two; value <= Value.Ace; value++)
                {
                    this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
        }

        public PlayingCard DealCardFromPack()
        {
            var suit = (Suit)randomCardSelector.Next(NumSuits);
            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit)randomCardSelector.Next(NumSuits);
            }

            var value = (Value)randomCardSelector.Next(CardsPerSuit);
            while (this.IsCardAlreadyDealt(suit, value))
            {
                value = (Value)randomCardSelector.Next(CardsPerSuit);
            }

            var card = this.cardPack[(int)suit, (int)value];
            this.cardPack[(int)suit, (int)value] = null;
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
            bool result = true;
            for (var value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value) => (this.cardPack[(int)suit, (int)value] == null);
    }
}