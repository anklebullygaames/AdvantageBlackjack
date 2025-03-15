using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    public class Card : ICard
    {
        /// <summary>
        /// The suit of the card numbered 0 to 3
        /// </summary>
        public CardSuit Suit { get; private set; }

        /// <summary>
        /// The value of the card
        /// </summary>
        public CardFace Face { get; private set; }

        public string Name => $"{Suit.ToString()} of {Face.ToString()}";

        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }
    }
}
