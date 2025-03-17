using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// A Blackjack card that implements Card
    /// </summary>
    public class BlackjackCard : Card
    {
        /// <summary>
        /// The numerical value of the card (1 - 11)
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// The constructor for a BlackjackCard which implements Card and assigns it a blackjack value (1 - 11)
        /// </summary>
        /// <param name="face">face</param>
        /// <param name="suit">suit</param>
        public BlackjackCard(CardFace face, CardSuit suit) : base(face, suit)
        {

            //Sets the Value property based on the face of the card.
            switch (face)
            {
                default:
                    Value = 11;
                    break;
                case CardFace._2:
                    Value = 2;
                    break;
                case CardFace._3:
                    Value = 3;
                    break;
                case CardFace._4:
                    Value = 4;
                    break;
                case CardFace._5:
                    Value = 5;
                    break;
                case CardFace._6:
                    Value = 6;
                    break;
                case CardFace._7:
                    Value = 7;
                    break;
                case CardFace._8:
                    Value = 8;
                    break;
                case CardFace._9:
                    Value = 9;
                    break;
                case CardFace._10:
                    Value = 10;
                    break;
                case CardFace.J:
                    Value = 10;
                    break;
                case CardFace.Q:
                    Value = 10;
                    break;
                case CardFace.K:
                    Value = 10;
                    break;
            }

        }
    }
}
