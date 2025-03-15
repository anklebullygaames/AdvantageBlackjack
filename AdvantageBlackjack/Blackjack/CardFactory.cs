using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    public static class CardFactory
    {
        public static ICard CreateCard(CardFace face, CardSuit suit)
        {
            Card card = new Card(face, suit);
            return card;
        }
        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            BlackjackCard blackJackCard = new BlackjackCard(face, suit);
            return blackJackCard;
        }
    }
}
