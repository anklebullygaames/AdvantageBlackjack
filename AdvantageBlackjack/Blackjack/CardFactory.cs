using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// Contains methods to create a card and create a blackjack card
    /// </summary>
    public static class CardFactory
    {
        /// <summary>
        /// Creates a card with a given face and suit
        /// </summary>
        /// <param name="face">face</param>
        /// <param name="suit">suit</param>
        /// <returns>Card</returns>
        public static ICard CreateCard(CardFace face, CardSuit suit)
        {
            Card card = new Card(face, suit);
            return card;
        }

        /// <summary>
        /// Creates a blackjack card with a given face and suit
        /// </summary>
        /// <param name="face">face</param>
        /// <param name="suit">suit</param>
        /// <returns>BlackjackCard</returns>
        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            BlackjackCard blackJackCard = new BlackjackCard(face, suit);
            return blackJackCard;
        }
    }
}
