using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// A hand of cards
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// A list of cards that represents the hand
        /// </summary>
        protected List<ICard> _cards = new();

        /// <summary>
        /// Adds a card to the hand
        /// </summary>
        /// <param name="card"></param>
        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        /// <summary>
        /// Returns a read only version of the hand
        /// </summary>
        public IReadOnlyList<ICard> Cards => _cards.AsReadOnly();
    }
}
