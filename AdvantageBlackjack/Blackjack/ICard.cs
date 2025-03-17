using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// The card interface which has a face and suit
    /// </summary>
    public interface ICard
    {
        /// <summary>
        /// The face of the card
        /// </summary>
        CardFace Face { get; }

        /// <summary>
        /// The suit of the card
        /// </summary>
        CardSuit Suit { get; }
    }
}
