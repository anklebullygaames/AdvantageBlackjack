using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    public class BlackjackHand : Hand
    {
        public int Score { get; private set; }

        public bool IsDealer { get; set; } = false;

        public BlackjackHand(bool isDealer = false)
        {
            IsDealer = isDealer;
        }

        public override void AddCard(ICard card)
        {
            base.AddCard(card);
            int aceCounter = 0;
            Score = 0;
            for (int i = 0; i < _cards.Count; i++)
            {
                BlackjackCard temp = (BlackjackCard)_cards[i];
                if (temp.Face is CardFace.A)
                    aceCounter++;
                else Score += temp.Value;

            }
            for (int i = 0; i < aceCounter; i++)
            {
                if (11 + Score <= 21)
                    Score += 11;
                else Score++;
            }
        }
    }
}
