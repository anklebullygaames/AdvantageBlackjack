using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack.Blackjack
{
    /// <summary>
    /// Database of correct answers
    /// </summary>
    static class AnswerDatabase
    {
        /// <summary>
        /// Dictionary of answers for a hit 17 double after split blackjack game
        /// </summary>
        private static Dictionary<(CardFace playerCard1, CardFace playerCard2, CardFace dealerCard), Answer> _hit17DoubleAfterSplit = new();

        /// <summary>
        /// Dictionary of answers for a hit 17 no double after split blackjack game
        /// </summary>
        private static Dictionary<(CardFace playerCard1, CardFace playerCard2, CardFace dealerCard), Answer> _hit17NoDoubleAfterSplit = new();

        /// <summary>
        /// Dictionary of answers for a stand 17 double after split blackjack game
        /// </summary>
        private static Dictionary<(CardFace playerCard1, CardFace playerCard2, CardFace dealerCard), Answer> _stand17DoubleAfterSplit = new();

        /// <summary>
        /// Dictionary of answers for a stand 17 no double after split blackjack game
        /// </summary>
        private static Dictionary<(CardFace playerCard1, CardFace playerCard2, CardFace dealerCard), Answer> _stand17NoDoubleAfterSplit = new();

        /// <summary>
        /// The constructor for the AnswerDatabase
        /// </summary>
        static AnswerDatabase()
        {
            // add to dictionaries
        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetAnswer((CardFace, CardFace, CardFace) matchup)
        {
            if (GlobalSettings.H17)
            {
                if (GlobalSettings.DoubleAfterSplit)
                {
                    return _hit17DoubleAfterSplit[matchup];
                }
                else
                {
                    return _hit17NoDoubleAfterSplit[matchup];
                }
            }
            else
            {
                if (GlobalSettings.DoubleAfterSplit)
                {
                    return _stand17DoubleAfterSplit[matchup];
                }
                else
                {
                    return _stand17NoDoubleAfterSplit[matchup];
                }
            }
        }
    }
}
