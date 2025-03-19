using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// A BlackjackHand and which implements Hand but adds a blackjack score and whther or not the hand is the dealer
    /// </summary>
    public class BlackjackHand : Hand
    {
        /// <summary>
        /// The total score of the hand
        /// </summary>
        public int Score { get; private set; }

        public int AceCount { get; set; }

        /// <summary>
        /// Whether the hand is the dealer or not
        /// </summary>
        public bool IsDealer { get; set; } = false;

        /// <summary>
        /// The constructor for a BlackjackHand
        /// </summary>
        /// <param name="isDealer">Whether the hand is the dealer or not</param>
        public BlackjackHand(bool isDealer = false)
        {
            IsDealer = isDealer;
        }

        /// <summary>
        /// Adds a card to the BlackjackHand and adjust the score
        /// </summary>
        /// <param name="card">card</param>
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

            AceCount = aceCounter;

            for (int i = 0; i < aceCounter; i++)
            {
                if (11 + Score <= 21)
                    Score += 11;
                else Score++;
            }
        }
    }
}
