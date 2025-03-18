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
        private static Dictionary<(int score, CardFace dealerFace), Answer> _hit17Soft = new();

        /// <summary>
        /// Dictionary of answers for a hit 17 no double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _stand17Soft = new();

        /// <summary>
        /// Dictionary of answers for a stand 17 double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _hit17Hard = new();

        /// <summary>
        /// Dictionary of answers for a stand 17 no double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _stand17Hard = new();

        /// <summary>
        /// Dictionary of answers for a hit 17 double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _hit17PairsDAS = new();

        /// <summary>
        /// Dictionary of answers for a hit 17 no double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _hit17PairsNoDAS = new();

        /// <summary>
        /// Dictionary of answers for a stand 17 double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _stand17PairsDAS = new();

        /// <summary>
        /// Dictionary of answers for a stand 17 no double after split blackjack game
        /// </summary>
        private static Dictionary<(int score, CardFace dealerFace), Answer> _stand17PairsNoDAS = new();

        /// <summary>
        /// The constructor for the AnswerDatabase
        /// </summary>
        static AnswerDatabase()
        {

            //H17DoubleAfterSplit


            //H17NoDoubleAfterSplit


            //S17SoubleAfterSplit


            //S17NoDoubleAfterSplit


        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetPairAnswer((BlackjackHand playerHand, BlackjackHand dealerHand) matchup)
        {
            CardFace dealerFaceCard = matchup.dealerHand.Cards[0].Face;

            if (GlobalSettings.H17)
            {
                if (GlobalSettings.DoubleAfterSplit)
                {
                    return _hit17PairsDAS[(matchup.playerHand.Score, dealerFaceCard)];
                }
                else
                {
                    return _hit17PairsNoDAS[(matchup.playerHand.Score, dealerFaceCard)];
                }
            }
            else
            {
                if (GlobalSettings.DoubleAfterSplit)
                {
                    return _stand17PairsDAS[(matchup.playerHand.Score, dealerFaceCard)];
                }
                else
                {
                    return _stand17PairsNoDAS[(matchup.playerHand.Score, dealerFaceCard)];
                }
            }
        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetSoftAnswer((BlackjackHand playerHand, BlackjackHand dealerHand) matchup)
        {
            CardFace dealerFaceCard = matchup.dealerHand.Cards[0].Face;

            if (GlobalSettings.H17)
            {
                return _hit17Soft[(matchup.playerHand.Score, dealerFaceCard)];
            }
            else
            {
                return _stand17Soft[(matchup.playerHand.Score, dealerFaceCard)];
            }
        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetHardAnswer((BlackjackHand playerHand, BlackjackHand dealerHand) matchup)
        {
            CardFace dealerFaceCard = matchup.dealerHand.Cards[0].Face;

            if (GlobalSettings.H17)
            {
                return _hit17Hard[(matchup.playerHand.Score, dealerFaceCard)];
            }
            else
            {
                return _stand17Hard[(matchup.playerHand.Score, dealerFaceCard)];
            }
        }
    }
}
