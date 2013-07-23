using System.ComponentModel;

namespace Cards
{
	using System;
	using System.Collections;

	class Pack
	{
        public const int NumSuits = 4;
        public const int CardsPerSuit = 13;
        private PlayingCard[,] cardPack;
        private Random randomCardSelector = new Random();

		public Pack()
		{
            //instantiate cardPack
            this.cardPack = new PlayingCard[NumSuits, CardsPerSuit];
            
            // initialise each element in cardPack array
            for (Suit suit = Suit.Clubs; suit <= Suit.Spades; suit++)
            {
                for (Value value = Value.Two; value <= Value.Ace; value++)
                {
                    //cast suit and value into integer values. More computer and memory efficient.
                    this.cardPack[(int)suit, (int)value] = new PlayingCard(suit, value);
                }
            }
		}

        public PlayingCard DealCardFromPack()
        {
            // Pick a random card, remove it from the pack, and return it
            Suit suit = (Suit) randomCardSelector.Next(NumSuits);

            // Check if there are any cards of this specific suit left in the pack.
            // If not, another suit is chosen. It continues until it finds a suit with 
            // at least one card left.
            while (this.IsSuitEmpty(suit))
            {
                suit = (Suit) randomCardSelector.Next(NumSuits);
            }

            // After chosen the suit, now lets randomly select a card and verify that 
            // the card w the selected value has not been dealt.
            Value value = (Value) randomCardSelector.Next(CardsPerSuit);
            while (this.IsCardAlreadyDealt(suit,value))
            {
                value = (Value) randomCardSelector.Next(CardsPerSuit);
            }

            // With the card selected, now return the card and set corresponding 
            // element in the cardPack array to null.
            PlayingCard card = this.cardPack[(int) suit, (int) value];
            this.cardPack[(int) suit, (int) value] = null;
            return card;
        }

        private bool IsSuitEmpty(Suit suit)
        {
           // Return true if there are no more cards available in this suit
            bool result = true;

            for (Value value = Value.Two; value <= Value.Ace; value++)
            {
                if (!IsCardAlreadyDealt(suit, value))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private bool IsCardAlreadyDealt(Suit suit, Value value)
        {
           // Return true if this card has already been dealt   
            return (this.cardPack[(int) suit, (int) value] == null);
        }
	}
}