using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// A deck of cards
    /// </summary>
    public class Deck
    {

        /// <summary>
        /// A list of cards that represents the deck
        /// </summary>
        List<ICard> _cards = new List<ICard>();

        /// <summary>
        /// The constructor for a deck which calls DeckMethod and Shuffles.
        /// </summary>
        public Deck()
        {
            DeckMethod();
        }

        /// <summary>
        /// Adds 52 cards to the deck
        /// </summary>
        public void DeckMethod()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    _cards.Add(CardFactory.CreateBlackjackCard((CardFace)j, (CardSuit)i));
                }
            }
        }

        /// <summary>
        /// Shuffles the deck
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = 0; i < 51; i++)
            {
                int j = rng.Next(i, 52);

                ICard temp = _cards[j];
                _cards[j] = _cards[i];
                _cards[i] = temp;
            }
        }

        /// <summary>
        /// Deals a card from the deck
        /// </summary>
        /// <returns></returns>
        public ICard Deal()
        {
            if (_cards.Count == 0)
            {
                DeckMethod();
                Shuffle();
            }
            ICard temp = _cards[0];
            _cards.RemoveAt(0);
            return temp;
        }
    }
}
