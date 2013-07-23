using System;
using System.ComponentModel;

namespace Cards
{
	class PlayingCard
	{
        private readonly Suit suit;
        private readonly Value value;

        /// <summary>
        /// Constructor that allows the use the select a specific card when creating an object.
        /// </summary>
        /// <param name="s">Card's Suit, chosen between options of Clubs, Diamonds, Hearts and Spades.</param>
        /// <param name="v">Card's value, chosen between options of Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King and Ace.</param>
		public PlayingCard(Suit s, Value v)
		{
            if (!CheckSuitValidity(s)) throw new InvalidEnumArgumentException("The card suit entered does not match any of the options.");
            if (!CheckValueValidity(v)) throw new InvalidEnumArgumentException("The card value entered does not match any of the options.");

			this.suit = s;
			this.value = v;
		}

        /// <summary>
        /// Convert the value and suit of the card selected into a string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
		{
            string result = string.Format("{0} of {1}", this.value, this.suit);
			return result;
		}

        /// <summary>
        /// Return card suit
        /// </summary>
        /// <returns></returns>
        public Suit CardSuit()
        {
            return this.suit;
        }

        /// <summary>
        /// Return card value
        /// </summary>
        /// <returns></returns>
        public Value CardValue()
        {
            return this.value;
        }

        /// <summary>
        /// To check if the card suit provided in the constructor is valid.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool CheckSuitValidity(Suit s) //AS
        {
            bool suitValid = false;
            for (Suit su = Suit.Clubs; su <= Suit.Spades; su++)
            {
                if (s == su)
                {
                    suitValid = true;
                    break;
                }
            }
            return suitValid;

        }

        /// <summary>
        /// To check if the card value provided in the constructor is valid.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool CheckValueValidity(Value v)  //AS
        {
            //!!!!!!!!!!!!!!!! why is  this version not working??? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
            bool valueValid = false;
            for (Value val = Value.Two; val <= Value.Ace; val++)
            {
                if (v == val)
                {
                    valueValid = true;
                    break;
                }
 
            }
            return valueValid;


        }

    }
}