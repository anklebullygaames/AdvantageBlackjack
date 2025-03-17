using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// The base case for a card which implements ICard and has a callable name
    /// </summary>
    public class Card : ICard
    {
        /// <summary>
        /// The suit of the card
        /// </summary>
        public CardSuit Suit { get; private set; }

        /// <summary>
        /// The face of the card
        /// </summary>
        public CardFace Face { get; private set; }

        /// <summary>
        /// Returns the name of the card
        /// </summary>
        public string Name => $"{Suit.ToString()} of {Face.ToString()}";

        /// <summary>
        /// The constructor for a card
        /// </summary>
        /// <param name="face">face</param>
        /// <param name="suit">suit</param>
        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }
    }
}
