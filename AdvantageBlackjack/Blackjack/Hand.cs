using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    public class Hand
    {
        protected List<ICard> _cards = new();

        public virtual void AddCard(ICard card)
        {
            _cards.Add(card);
        }

        public IReadOnlyList<ICard> Cards => _cards.AsReadOnly();
    }
}
