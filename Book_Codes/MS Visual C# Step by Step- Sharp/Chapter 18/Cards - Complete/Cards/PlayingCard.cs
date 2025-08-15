namespace Cards
{
    class PlayingCard
    {
        private readonly Suit suit;
        private readonly Value value;

        public PlayingCard(Suit s, Value v)
        {
            this.suit = s;
            this.value = v;
        }

        public override string ToString()
        {
            string result = string.Format("{0} of {1}", this.value, this.suit);
            return result;
        }

        public Suit CardSuit
        {
            get
            {
                return this.suit;
            }
        }

        public Value CardValue
        {
            get
            {
                return this.value;
            }
        }
    }
}