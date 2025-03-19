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

            //_hit17Soft

            _hit17Soft.Add((13, CardFace._2), Answer.Hit);
            _hit17Soft.Add((13, CardFace._3), Answer.Hit);
            _hit17Soft.Add((13, CardFace._4), Answer.Hit);
            _hit17Soft.Add((13, CardFace._5), Answer.Double);
            _hit17Soft.Add((13, CardFace._6), Answer.Double);
            _hit17Soft.Add((13, CardFace._7), Answer.Hit);
            _hit17Soft.Add((13, CardFace._8), Answer.Hit);
            _hit17Soft.Add((13, CardFace._9), Answer.Hit);
            _hit17Soft.Add((13, CardFace._10), Answer.Hit);
            _hit17Soft.Add((13, CardFace.K), Answer.Hit);
            _hit17Soft.Add((13, CardFace.Q), Answer.Hit);
            _hit17Soft.Add((13, CardFace.J), Answer.Hit);
            _hit17Soft.Add((13, CardFace.A), Answer.Hit);

            _hit17Soft.Add((14, CardFace._2), Answer.Hit);
            _hit17Soft.Add((14, CardFace._3), Answer.Hit);
            _hit17Soft.Add((14, CardFace._4), Answer.Hit);
            _hit17Soft.Add((14, CardFace._5), Answer.Double);
            _hit17Soft.Add((14, CardFace._6), Answer.Double);
            _hit17Soft.Add((14, CardFace._7), Answer.Hit);
            _hit17Soft.Add((14, CardFace._8), Answer.Hit);
            _hit17Soft.Add((14, CardFace._9), Answer.Hit);
            _hit17Soft.Add((14, CardFace._10), Answer.Hit);
            _hit17Soft.Add((14, CardFace.K), Answer.Hit);
            _hit17Soft.Add((14, CardFace.Q), Answer.Hit);
            _hit17Soft.Add((14, CardFace.J), Answer.Hit);
            _hit17Soft.Add((14, CardFace.A), Answer.Hit);

            _hit17Soft.Add((15, CardFace._2), Answer.Hit);
            _hit17Soft.Add((15, CardFace._3), Answer.Hit);
            _hit17Soft.Add((15, CardFace._4), Answer.Double);
            _hit17Soft.Add((15, CardFace._5), Answer.Double);
            _hit17Soft.Add((15, CardFace._6), Answer.Double);
            _hit17Soft.Add((15, CardFace._7), Answer.Hit);
            _hit17Soft.Add((15, CardFace._8), Answer.Hit);
            _hit17Soft.Add((15, CardFace._9), Answer.Hit);
            _hit17Soft.Add((15, CardFace._10), Answer.Hit);
            _hit17Soft.Add((15, CardFace.K), Answer.Hit);
            _hit17Soft.Add((15, CardFace.Q), Answer.Hit);
            _hit17Soft.Add((15, CardFace.J), Answer.Hit);
            _hit17Soft.Add((15, CardFace.A), Answer.Hit);

            _hit17Soft.Add((16, CardFace._2), Answer.Hit);
            _hit17Soft.Add((16, CardFace._3), Answer.Hit);
            _hit17Soft.Add((16, CardFace._4), Answer.Double);
            _hit17Soft.Add((16, CardFace._5), Answer.Double);
            _hit17Soft.Add((16, CardFace._6), Answer.Double);
            _hit17Soft.Add((16, CardFace._7), Answer.Hit);
            _hit17Soft.Add((16, CardFace._8), Answer.Hit);
            _hit17Soft.Add((16, CardFace._9), Answer.Hit);
            _hit17Soft.Add((16, CardFace._10), Answer.Hit);
            _hit17Soft.Add((16, CardFace.K), Answer.Hit);
            _hit17Soft.Add((16, CardFace.Q), Answer.Hit);
            _hit17Soft.Add((16, CardFace.J), Answer.Hit);
            _hit17Soft.Add((16, CardFace.A), Answer.Hit);

            _hit17Soft.Add((17, CardFace._2), Answer.Hit);
            _hit17Soft.Add((17, CardFace._3), Answer.Double);
            _hit17Soft.Add((17, CardFace._4), Answer.Double);
            _hit17Soft.Add((17, CardFace._5), Answer.Double);
            _hit17Soft.Add((17, CardFace._6), Answer.Double);
            _hit17Soft.Add((17, CardFace._7), Answer.Hit);
            _hit17Soft.Add((17, CardFace._8), Answer.Hit);
            _hit17Soft.Add((17, CardFace._9), Answer.Hit);
            _hit17Soft.Add((17, CardFace._10), Answer.Hit);
            _hit17Soft.Add((17, CardFace.K), Answer.Hit);
            _hit17Soft.Add((17, CardFace.Q), Answer.Hit);
            _hit17Soft.Add((17, CardFace.J), Answer.Hit);
            _hit17Soft.Add((17, CardFace.A), Answer.Hit);

            _hit17Soft.Add((18, CardFace._2), Answer.Double);
            _hit17Soft.Add((18, CardFace._3), Answer.Double);
            _hit17Soft.Add((18, CardFace._4), Answer.Double);
            _hit17Soft.Add((18, CardFace._5), Answer.Double);
            _hit17Soft.Add((18, CardFace._6), Answer.Double);
            _hit17Soft.Add((18, CardFace._7), Answer.Stand);
            _hit17Soft.Add((18, CardFace._8), Answer.Stand);
            _hit17Soft.Add((18, CardFace._9), Answer.Hit);
            _hit17Soft.Add((18, CardFace._10), Answer.Hit);
            _hit17Soft.Add((18, CardFace.K), Answer.Hit);
            _hit17Soft.Add((18, CardFace.Q), Answer.Hit);
            _hit17Soft.Add((18, CardFace.J), Answer.Hit);
            _hit17Soft.Add((18, CardFace.A), Answer.Hit);

            _hit17Soft.Add((19, CardFace._2), Answer.Stand);
            _hit17Soft.Add((19, CardFace._3), Answer.Stand);
            _hit17Soft.Add((19, CardFace._4), Answer.Stand);
            _hit17Soft.Add((19, CardFace._5), Answer.Stand);
            _hit17Soft.Add((19, CardFace._6), Answer.Double);
            _hit17Soft.Add((19, CardFace._7), Answer.Stand);
            _hit17Soft.Add((19, CardFace._8), Answer.Stand);
            _hit17Soft.Add((19, CardFace._9), Answer.Stand);
            _hit17Soft.Add((19, CardFace._10), Answer.Stand);
            _hit17Soft.Add((19, CardFace.K), Answer.Stand);
            _hit17Soft.Add((19, CardFace.Q), Answer.Stand);
            _hit17Soft.Add((19, CardFace.J), Answer.Stand);
            _hit17Soft.Add((19, CardFace.A), Answer.Stand);

            _hit17Soft.Add((20, CardFace._2), Answer.Stand);
            _hit17Soft.Add((20, CardFace._3), Answer.Stand);
            _hit17Soft.Add((20, CardFace._4), Answer.Stand);
            _hit17Soft.Add((20, CardFace._5), Answer.Stand);
            _hit17Soft.Add((20, CardFace._6), Answer.Stand);
            _hit17Soft.Add((20, CardFace._7), Answer.Stand);
            _hit17Soft.Add((20, CardFace._8), Answer.Stand);
            _hit17Soft.Add((20, CardFace._9), Answer.Stand);
            _hit17Soft.Add((20, CardFace._10), Answer.Stand);
            _hit17Soft.Add((20, CardFace.K), Answer.Stand);
            _hit17Soft.Add((20, CardFace.Q), Answer.Stand);
            _hit17Soft.Add((20, CardFace.J), Answer.Stand);
            _hit17Soft.Add((20, CardFace.A), Answer.Stand);

            //_stand17Soft

            _stand17Soft.Add((13, CardFace._2), Answer.Hit);
            _stand17Soft.Add((13, CardFace._3), Answer.Hit);
            _stand17Soft.Add((13, CardFace._4), Answer.Hit);
            _stand17Soft.Add((13, CardFace._5), Answer.Double);
            _stand17Soft.Add((13, CardFace._6), Answer.Double);
            _stand17Soft.Add((13, CardFace._7), Answer.Hit);
            _stand17Soft.Add((13, CardFace._8), Answer.Hit);
            _stand17Soft.Add((13, CardFace._9), Answer.Hit);
            _stand17Soft.Add((13, CardFace.K), Answer.Hit);
            _stand17Soft.Add((13, CardFace.Q), Answer.Hit);
            _stand17Soft.Add((13, CardFace.J), Answer.Hit);
            _stand17Soft.Add((13, CardFace.A), Answer.Hit);

            _stand17Soft.Add((14, CardFace._2), Answer.Hit);
            _stand17Soft.Add((14, CardFace._3), Answer.Hit);
            _stand17Soft.Add((14, CardFace._4), Answer.Hit);
            _stand17Soft.Add((14, CardFace._5), Answer.Double);
            _stand17Soft.Add((14, CardFace._6), Answer.Double);
            _stand17Soft.Add((14, CardFace._7), Answer.Hit);
            _stand17Soft.Add((14, CardFace._8), Answer.Hit);
            _stand17Soft.Add((14, CardFace._9), Answer.Hit);
            _stand17Soft.Add((14, CardFace._10), Answer.Hit);
            _stand17Soft.Add((14, CardFace.K), Answer.Hit);
            _stand17Soft.Add((14, CardFace.Q), Answer.Hit);
            _stand17Soft.Add((14, CardFace.J), Answer.Hit);
            _stand17Soft.Add((14, CardFace.A), Answer.Hit);

            _stand17Soft.Add((15, CardFace._2), Answer.Hit);
            _stand17Soft.Add((15, CardFace._3), Answer.Hit);
            _stand17Soft.Add((15, CardFace._4), Answer.Double);
            _stand17Soft.Add((15, CardFace._5), Answer.Double);
            _stand17Soft.Add((15, CardFace._6), Answer.Double);
            _stand17Soft.Add((15, CardFace._7), Answer.Hit);
            _stand17Soft.Add((15, CardFace._8), Answer.Hit);
            _stand17Soft.Add((15, CardFace._9), Answer.Hit);
            _stand17Soft.Add((15, CardFace._10), Answer.Hit);
            _stand17Soft.Add((15, CardFace.K), Answer.Hit);
            _stand17Soft.Add((15, CardFace.Q), Answer.Hit);
            _stand17Soft.Add((15, CardFace.J), Answer.Hit);
            _stand17Soft.Add((15, CardFace.A), Answer.Hit);

            _stand17Soft.Add((16, CardFace._2), Answer.Hit);
            _stand17Soft.Add((16, CardFace._3), Answer.Hit);
            _stand17Soft.Add((16, CardFace._4), Answer.Double);
            _stand17Soft.Add((16, CardFace._5), Answer.Double);
            _stand17Soft.Add((16, CardFace._6), Answer.Double);
            _stand17Soft.Add((16, CardFace._7), Answer.Hit);
            _stand17Soft.Add((16, CardFace._8), Answer.Hit);
            _stand17Soft.Add((16, CardFace._9), Answer.Hit);
            _stand17Soft.Add((16, CardFace._10), Answer.Hit);
            _stand17Soft.Add((16, CardFace.K), Answer.Hit);
            _stand17Soft.Add((16, CardFace.Q), Answer.Hit);
            _stand17Soft.Add((16, CardFace.J), Answer.Hit);
            _stand17Soft.Add((16, CardFace.A), Answer.Hit);

            _stand17Soft.Add((17, CardFace._2), Answer.Hit);
            _stand17Soft.Add((17, CardFace._3), Answer.Double);
            _stand17Soft.Add((17, CardFace._4), Answer.Double);
            _stand17Soft.Add((17, CardFace._5), Answer.Double);
            _stand17Soft.Add((17, CardFace._6), Answer.Double);
            _stand17Soft.Add((17, CardFace._7), Answer.Hit);
            _stand17Soft.Add((17, CardFace._8), Answer.Hit);
            _stand17Soft.Add((17, CardFace._9), Answer.Hit);
            _stand17Soft.Add((17, CardFace._10), Answer.Hit);
            _stand17Soft.Add((17, CardFace.K), Answer.Hit);
            _stand17Soft.Add((17, CardFace.Q), Answer.Hit);
            _stand17Soft.Add((17, CardFace.J), Answer.Hit);
            _stand17Soft.Add((17, CardFace.A), Answer.Hit);

            _stand17Soft.Add((18, CardFace._2), Answer.Stand);
            _stand17Soft.Add((18, CardFace._3), Answer.Double);
            _stand17Soft.Add((18, CardFace._4), Answer.Double);
            _stand17Soft.Add((18, CardFace._5), Answer.Double);
            _stand17Soft.Add((18, CardFace._6), Answer.Double);
            _stand17Soft.Add((18, CardFace._7), Answer.Stand);
            _stand17Soft.Add((18, CardFace._8), Answer.Stand);
            _stand17Soft.Add((18, CardFace._9), Answer.Hit);
            _stand17Soft.Add((18, CardFace._10), Answer.Hit);
            _stand17Soft.Add((18, CardFace.K), Answer.Hit);
            _stand17Soft.Add((18, CardFace.Q), Answer.Hit);
            _stand17Soft.Add((18, CardFace.J), Answer.Hit);
            _stand17Soft.Add((18, CardFace.A), Answer.Hit);

            _stand17Soft.Add((19, CardFace._2), Answer.Stand);
            _stand17Soft.Add((19, CardFace._3), Answer.Stand);
            _stand17Soft.Add((19, CardFace._4), Answer.Stand);
            _stand17Soft.Add((19, CardFace._5), Answer.Stand);
            _stand17Soft.Add((19, CardFace._6), Answer.Double);
            _stand17Soft.Add((19, CardFace._7), Answer.Stand);
            _stand17Soft.Add((19, CardFace._8), Answer.Stand);
            _stand17Soft.Add((19, CardFace._9), Answer.Stand);
            _stand17Soft.Add((19, CardFace._10), Answer.Stand);
            _stand17Soft.Add((19, CardFace.K), Answer.Stand);
            _stand17Soft.Add((19, CardFace.Q), Answer.Stand);
            _stand17Soft.Add((19, CardFace.J), Answer.Stand);
            _stand17Soft.Add((19, CardFace.A), Answer.Stand);

            _stand17Soft.Add((20, CardFace._2), Answer.Stand);
            _stand17Soft.Add((20, CardFace._3), Answer.Stand);
            _stand17Soft.Add((20, CardFace._4), Answer.Stand);
            _stand17Soft.Add((20, CardFace._5), Answer.Stand);
            _stand17Soft.Add((20, CardFace._6), Answer.Stand);
            _stand17Soft.Add((20, CardFace._7), Answer.Stand);
            _stand17Soft.Add((20, CardFace._8), Answer.Stand);
            _stand17Soft.Add((20, CardFace._9), Answer.Stand);
            _stand17Soft.Add((20, CardFace._10), Answer.Stand);
            _stand17Soft.Add((20, CardFace.K), Answer.Stand);
            _stand17Soft.Add((20, CardFace.Q), Answer.Stand);
            _stand17Soft.Add((20, CardFace.J), Answer.Stand);
            _stand17Soft.Add((20, CardFace.A), Answer.Stand);

            //_hit17Hard
            _hit17Hard.Add((8, CardFace._2), Answer.Hit);
            _hit17Hard.Add((8, CardFace._3), Answer.Hit);
            _hit17Hard.Add((8, CardFace._4), Answer.Hit);
            _hit17Hard.Add((8, CardFace._5), Answer.Hit);
            _hit17Hard.Add((8, CardFace._6), Answer.Hit);
            _hit17Hard.Add((8, CardFace._7), Answer.Hit);
            _hit17Hard.Add((8, CardFace._8), Answer.Hit);
            _hit17Hard.Add((8, CardFace._9), Answer.Hit);
            _hit17Hard.Add((8, CardFace._10), Answer.Hit);
            _hit17Hard.Add((8, CardFace.K), Answer.Hit);
            _hit17Hard.Add((8, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((8, CardFace.J), Answer.Hit);
            _hit17Hard.Add((8, CardFace.A), Answer.Hit);

            _hit17Hard.Add((9, CardFace._2), Answer.Hit);
            _hit17Hard.Add((9, CardFace._3), Answer.Double);
            _hit17Hard.Add((9, CardFace._4), Answer.Double);
            _hit17Hard.Add((9, CardFace._5), Answer.Double);
            _hit17Hard.Add((9, CardFace._6), Answer.Double);
            _hit17Hard.Add((9, CardFace._7), Answer.Hit);
            _hit17Hard.Add((9, CardFace._8), Answer.Hit);
            _hit17Hard.Add((9, CardFace._9), Answer.Hit);
            _hit17Hard.Add((9, CardFace.K), Answer.Hit);
            _hit17Hard.Add((9, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((9, CardFace.J), Answer.Hit);
            _hit17Hard.Add((9, CardFace.A), Answer.Hit);

            _hit17Hard.Add((10, CardFace._2), Answer.Double);
            _hit17Hard.Add((10, CardFace._3), Answer.Double);
            _hit17Hard.Add((10, CardFace._4), Answer.Double);
            _hit17Hard.Add((10, CardFace._5), Answer.Double);
            _hit17Hard.Add((10, CardFace._6), Answer.Double);
            _hit17Hard.Add((10, CardFace._7), Answer.Double);
            _hit17Hard.Add((10, CardFace._8), Answer.Double);
            _hit17Hard.Add((10, CardFace._9), Answer.Double);
            _hit17Hard.Add((10, CardFace.K), Answer.Hit);
            _hit17Hard.Add((10, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((10, CardFace.J), Answer.Hit);
            _hit17Hard.Add((10, CardFace.A), Answer.Hit);

            _hit17Hard.Add((11, CardFace._2), Answer.Double);
            _hit17Hard.Add((11, CardFace._3), Answer.Double);
            _hit17Hard.Add((11, CardFace._4), Answer.Double);
            _hit17Hard.Add((11, CardFace._5), Answer.Double);
            _hit17Hard.Add((11, CardFace._6), Answer.Double);
            _hit17Hard.Add((11, CardFace._7), Answer.Double);
            _hit17Hard.Add((11, CardFace._8), Answer.Double);
            _hit17Hard.Add((11, CardFace._9), Answer.Double);
            _hit17Hard.Add((11, CardFace.K), Answer.Double);
            _hit17Hard.Add((11, CardFace.Q), Answer.Double);
            _hit17Hard.Add((11, CardFace.J), Answer.Double);
            _hit17Hard.Add((11, CardFace.A), Answer.Double);

            _hit17Hard.Add((12, CardFace._2), Answer.Hit);
            _hit17Hard.Add((12, CardFace._3), Answer.Hit);
            _hit17Hard.Add((12, CardFace._4), Answer.Stand);
            _hit17Hard.Add((12, CardFace._5), Answer.Stand);
            _hit17Hard.Add((12, CardFace._6), Answer.Stand);
            _hit17Hard.Add((12, CardFace._7), Answer.Hit);
            _hit17Hard.Add((12, CardFace._8), Answer.Hit);
            _hit17Hard.Add((12, CardFace._9), Answer.Hit);
            _hit17Hard.Add((12, CardFace.K), Answer.Hit);
            _hit17Hard.Add((12, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((12, CardFace.J), Answer.Hit);
            _hit17Hard.Add((12, CardFace.A), Answer.Hit);

            _hit17Hard.Add((13, CardFace._2), Answer.Stand);
            _hit17Hard.Add((13, CardFace._3), Answer.Stand);
            _hit17Hard.Add((13, CardFace._4), Answer.Stand);
            _hit17Hard.Add((13, CardFace._5), Answer.Stand);
            _hit17Hard.Add((13, CardFace._6), Answer.Stand);
            _hit17Hard.Add((13, CardFace._7), Answer.Hit);
            _hit17Hard.Add((13, CardFace._8), Answer.Hit);
            _hit17Hard.Add((13, CardFace._9), Answer.Hit);
            _hit17Hard.Add((13, CardFace.K), Answer.Hit);
            _hit17Hard.Add((13, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((13, CardFace.J), Answer.Hit);
            _hit17Hard.Add((13, CardFace.A), Answer.Hit);

            _hit17Hard.Add((14, CardFace._2), Answer.Stand);
            _hit17Hard.Add((14, CardFace._3), Answer.Stand);
            _hit17Hard.Add((14, CardFace._4), Answer.Stand);
            _hit17Hard.Add((14, CardFace._5), Answer.Stand);
            _hit17Hard.Add((14, CardFace._6), Answer.Stand);
            _hit17Hard.Add((14, CardFace._7), Answer.Hit);
            _hit17Hard.Add((14, CardFace._8), Answer.Hit);
            _hit17Hard.Add((14, CardFace._9), Answer.Hit);
            _hit17Hard.Add((14, CardFace.K), Answer.Hit);
            _hit17Hard.Add((14, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((14, CardFace.J), Answer.Hit);
            _hit17Hard.Add((14, CardFace.A), Answer.Hit);

            _hit17Hard.Add((15, CardFace._2), Answer.Stand);
            _hit17Hard.Add((15, CardFace._3), Answer.Stand);
            _hit17Hard.Add((15, CardFace._4), Answer.Stand);
            _hit17Hard.Add((15, CardFace._5), Answer.Stand);
            _hit17Hard.Add((15, CardFace._6), Answer.Stand);
            _hit17Hard.Add((15, CardFace._7), Answer.Hit);
            _hit17Hard.Add((15, CardFace._8), Answer.Hit);
            _hit17Hard.Add((15, CardFace._9), Answer.Hit);
            _hit17Hard.Add((15, CardFace.K), Answer.Hit);
            _hit17Hard.Add((15, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((15, CardFace.J), Answer.Hit);
            _hit17Hard.Add((15, CardFace.A), Answer.Hit);

            _hit17Hard.Add((16, CardFace._2), Answer.Stand);
            _hit17Hard.Add((16, CardFace._3), Answer.Stand);
            _hit17Hard.Add((16, CardFace._4), Answer.Stand);
            _hit17Hard.Add((16, CardFace._5), Answer.Stand);
            _hit17Hard.Add((16, CardFace._6), Answer.Stand);
            _hit17Hard.Add((16, CardFace._7), Answer.Hit);
            _hit17Hard.Add((16, CardFace._8), Answer.Hit);
            _hit17Hard.Add((16, CardFace._9), Answer.Hit);
            _hit17Hard.Add((16, CardFace.K), Answer.Hit);
            _hit17Hard.Add((16, CardFace.Q), Answer.Hit);
            _hit17Hard.Add((16, CardFace.J), Answer.Hit);
            _hit17Hard.Add((16, CardFace.A), Answer.Hit);

            _hit17Hard.Add((17, CardFace._2), Answer.Stand);
            _hit17Hard.Add((17, CardFace._3), Answer.Stand);
            _hit17Hard.Add((17, CardFace._4), Answer.Stand);
            _hit17Hard.Add((17, CardFace._5), Answer.Stand);
            _hit17Hard.Add((17, CardFace._6), Answer.Stand);
            _hit17Hard.Add((17, CardFace._7), Answer.Stand);
            _hit17Hard.Add((17, CardFace._8), Answer.Stand);
            _hit17Hard.Add((17, CardFace._9), Answer.Stand);
            _hit17Hard.Add((17, CardFace.K), Answer.Stand);
            _hit17Hard.Add((17, CardFace.Q), Answer.Stand);
            _hit17Hard.Add((17, CardFace.J), Answer.Stand);
            _hit17Hard.Add((17, CardFace.A), Answer.Stand);

            //_stand17Hard

            _stand17Hard.Add((8, CardFace._2), Answer.Hit);
            _stand17Hard.Add((8, CardFace._3), Answer.Hit);
            _stand17Hard.Add((8, CardFace._4), Answer.Hit);
            _stand17Hard.Add((8, CardFace._5), Answer.Hit);
            _stand17Hard.Add((8, CardFace._6), Answer.Hit);
            _stand17Hard.Add((8, CardFace._7), Answer.Hit);
            _stand17Hard.Add((8, CardFace._8), Answer.Hit);
            _stand17Hard.Add((8, CardFace._9), Answer.Hit);
            _stand17Hard.Add((8, CardFace.K), Answer.Hit);
            _stand17Hard.Add((8, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((8, CardFace.J), Answer.Hit);
            _stand17Hard.Add((8, CardFace.A), Answer.Hit);

            _stand17Hard.Add((9, CardFace._2), Answer.Hit);
            _stand17Hard.Add((9, CardFace._3), Answer.Double);
            _stand17Hard.Add((9, CardFace._4), Answer.Double);
            _stand17Hard.Add((9, CardFace._5), Answer.Double);
            _stand17Hard.Add((9, CardFace._6), Answer.Double);
            _stand17Hard.Add((9, CardFace._7), Answer.Hit);
            _stand17Hard.Add((9, CardFace._8), Answer.Hit);
            _stand17Hard.Add((9, CardFace._9), Answer.Hit);
            _stand17Hard.Add((9, CardFace.K), Answer.Hit);
            _stand17Hard.Add((9, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((9, CardFace.J), Answer.Hit);
            _stand17Hard.Add((9, CardFace.A), Answer.Hit);

            _stand17Hard.Add((10, CardFace._2), Answer.Double);
            _stand17Hard.Add((10, CardFace._3), Answer.Double);
            _stand17Hard.Add((10, CardFace._4), Answer.Double);
            _stand17Hard.Add((10, CardFace._5), Answer.Double);
            _stand17Hard.Add((10, CardFace._6), Answer.Double);
            _stand17Hard.Add((10, CardFace._7), Answer.Double);
            _stand17Hard.Add((10, CardFace._8), Answer.Double);
            _stand17Hard.Add((10, CardFace._9), Answer.Double);
            _stand17Hard.Add((10, CardFace.K), Answer.Hit);
            _stand17Hard.Add((10, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((10, CardFace.J), Answer.Hit);
            _stand17Hard.Add((10, CardFace.A), Answer.Hit);

            _stand17Hard.Add((11, CardFace._2), Answer.Double);
            _stand17Hard.Add((11, CardFace._3), Answer.Double);
            _stand17Hard.Add((11, CardFace._4), Answer.Double);
            _stand17Hard.Add((11, CardFace._5), Answer.Double);
            _stand17Hard.Add((11, CardFace._6), Answer.Double);
            _stand17Hard.Add((11, CardFace._7), Answer.Double);
            _stand17Hard.Add((11, CardFace._8), Answer.Double);
            _stand17Hard.Add((11, CardFace._9), Answer.Double);
            _stand17Hard.Add((11, CardFace.K), Answer.Double);
            _stand17Hard.Add((11, CardFace.Q), Answer.Double);
            _stand17Hard.Add((11, CardFace.J), Answer.Double);
            _stand17Hard.Add((11, CardFace.A), Answer.Hit);

            _stand17Hard.Add((12, CardFace._2), Answer.Hit);
            _stand17Hard.Add((12, CardFace._3), Answer.Hit);
            _stand17Hard.Add((12, CardFace._4), Answer.Stand);
            _stand17Hard.Add((12, CardFace._5), Answer.Stand);
            _stand17Hard.Add((12, CardFace._6), Answer.Stand);
            _stand17Hard.Add((12, CardFace._7), Answer.Hit);
            _stand17Hard.Add((12, CardFace._8), Answer.Hit);
            _stand17Hard.Add((12, CardFace._9), Answer.Hit);
            _stand17Hard.Add((12, CardFace.K), Answer.Hit);
            _stand17Hard.Add((12, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((12, CardFace.J), Answer.Hit);
            _stand17Hard.Add((12, CardFace.A), Answer.Hit);

            _stand17Hard.Add((13, CardFace._2), Answer.Stand);
            _stand17Hard.Add((13, CardFace._3), Answer.Stand);
            _stand17Hard.Add((13, CardFace._4), Answer.Stand);
            _stand17Hard.Add((13, CardFace._5), Answer.Stand);
            _stand17Hard.Add((13, CardFace._6), Answer.Stand);
            _stand17Hard.Add((13, CardFace._7), Answer.Hit);
            _stand17Hard.Add((13, CardFace._8), Answer.Hit);
            _stand17Hard.Add((13, CardFace._9), Answer.Hit);
            _stand17Hard.Add((13, CardFace.K), Answer.Hit);
            _stand17Hard.Add((13, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((13, CardFace.J), Answer.Hit);
            _stand17Hard.Add((13, CardFace.A), Answer.Hit);

            _stand17Hard.Add((14, CardFace._2), Answer.Stand);
            _stand17Hard.Add((14, CardFace._3), Answer.Stand);
            _stand17Hard.Add((14, CardFace._4), Answer.Stand);
            _stand17Hard.Add((14, CardFace._5), Answer.Stand);
            _stand17Hard.Add((14, CardFace._6), Answer.Stand);
            _stand17Hard.Add((14, CardFace._7), Answer.Hit);
            _stand17Hard.Add((14, CardFace._8), Answer.Hit);
            _stand17Hard.Add((14, CardFace._9), Answer.Hit);
            _stand17Hard.Add((14, CardFace.K), Answer.Hit);
            _stand17Hard.Add((14, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((14, CardFace.J), Answer.Hit);
            _stand17Hard.Add((14, CardFace.A), Answer.Hit);

            _stand17Hard.Add((15, CardFace._2), Answer.Stand);
            _stand17Hard.Add((15, CardFace._3), Answer.Stand);
            _stand17Hard.Add((15, CardFace._4), Answer.Stand);
            _stand17Hard.Add((15, CardFace._5), Answer.Stand);
            _stand17Hard.Add((15, CardFace._6), Answer.Stand);
            _stand17Hard.Add((15, CardFace._7), Answer.Hit);
            _stand17Hard.Add((15, CardFace._8), Answer.Hit);
            _stand17Hard.Add((15, CardFace._9), Answer.Hit);
            _stand17Hard.Add((15, CardFace.K), Answer.Hit);
            _stand17Hard.Add((15, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((15, CardFace.J), Answer.Hit);
            _stand17Hard.Add((15, CardFace.A), Answer.Hit);

            _stand17Hard.Add((16, CardFace._2), Answer.Stand);
            _stand17Hard.Add((16, CardFace._3), Answer.Stand);
            _stand17Hard.Add((16, CardFace._4), Answer.Stand);
            _stand17Hard.Add((16, CardFace._5), Answer.Stand);
            _stand17Hard.Add((16, CardFace._6), Answer.Stand);
            _stand17Hard.Add((16, CardFace._7), Answer.Hit);
            _stand17Hard.Add((16, CardFace._8), Answer.Hit);
            _stand17Hard.Add((16, CardFace._9), Answer.Hit);
            _stand17Hard.Add((16, CardFace.K), Answer.Hit);
            _stand17Hard.Add((16, CardFace.Q), Answer.Hit);
            _stand17Hard.Add((16, CardFace.J), Answer.Hit);
            _stand17Hard.Add((16, CardFace.A), Answer.Hit);

            _stand17Hard.Add((17, CardFace._2), Answer.Stand);
            _stand17Hard.Add((17, CardFace._3), Answer.Stand);
            _stand17Hard.Add((17, CardFace._4), Answer.Stand);
            _stand17Hard.Add((17, CardFace._5), Answer.Stand);
            _stand17Hard.Add((17, CardFace._6), Answer.Stand);
            _stand17Hard.Add((17, CardFace._7), Answer.Stand);
            _stand17Hard.Add((17, CardFace._8), Answer.Stand);
            _stand17Hard.Add((17, CardFace._9), Answer.Stand);
            _stand17Hard.Add((17, CardFace.K), Answer.Stand);
            _stand17Hard.Add((17, CardFace.Q), Answer.Stand);
            _stand17Hard.Add((17, CardFace.J), Answer.Stand);
            _stand17Hard.Add((17, CardFace.A), Answer.Stand);

            //_hit17PairsDAS

            _hit17PairsDAS.Add((4, CardFace._2), Answer.Split);
            _hit17PairsDAS.Add((4, CardFace._3), Answer.Split);
            _hit17PairsDAS.Add((4, CardFace._4), Answer.Split);
            _hit17PairsDAS.Add((4, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((4, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((4, CardFace._7), Answer.Split);
            _hit17PairsDAS.Add((4, CardFace._8), Answer.Hit);
            _hit17PairsDAS.Add((4, CardFace._9), Answer.Hit);
            _hit17PairsDAS.Add((4, CardFace.K), Answer.Hit);
            _hit17PairsDAS.Add((4, CardFace.Q), Answer.Hit);
            _hit17PairsDAS.Add((4, CardFace.J), Answer.Hit);
            _hit17PairsDAS.Add((4, CardFace.A), Answer.Hit);

            _hit17PairsDAS.Add((6, CardFace._2), Answer.Split);
            _hit17PairsDAS.Add((6, CardFace._3), Answer.Split);
            _hit17PairsDAS.Add((6, CardFace._4), Answer.Split);
            _hit17PairsDAS.Add((6, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((6, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((6, CardFace._7), Answer.Split);
            _hit17PairsDAS.Add((6, CardFace._8), Answer.Hit);
            _hit17PairsDAS.Add((6, CardFace._9), Answer.Hit);
            _hit17PairsDAS.Add((6, CardFace.K), Answer.Hit);
            _hit17PairsDAS.Add((6, CardFace.Q), Answer.Hit);
            _hit17PairsDAS.Add((6, CardFace.J), Answer.Hit);
            _hit17PairsDAS.Add((6, CardFace.A), Answer.Hit);

            _hit17PairsDAS.Add((8, CardFace._2), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace._3), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace._4), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((8, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((8, CardFace._7), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace._8), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace._9), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace.K), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace.Q), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace.J), Answer.Hit);
            _hit17PairsDAS.Add((8, CardFace.A), Answer.Hit);

            _hit17PairsDAS.Add((10, CardFace._2), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._3), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._4), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._5), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._6), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._7), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._8), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace._9), Answer.Double);
            _hit17PairsDAS.Add((10, CardFace.K), Answer.Hit);
            _hit17PairsDAS.Add((10, CardFace.Q), Answer.Hit);
            _hit17PairsDAS.Add((10, CardFace.J), Answer.Hit);
            _hit17PairsDAS.Add((10, CardFace.A), Answer.Hit);

            _hit17PairsDAS.Add((12, CardFace._2), Answer.Split);
            _hit17PairsDAS.Add((12, CardFace._3), Answer.Split);
            _hit17PairsDAS.Add((12, CardFace._4), Answer.Split);
            _hit17PairsDAS.Add((12, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((12, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((12, CardFace._7), Answer.Hit);
            _hit17PairsDAS.Add((12, CardFace._8), Answer.Hit);
            _hit17PairsDAS.Add((12, CardFace._9), Answer.Hit);
            _hit17PairsDAS.Add((12, CardFace.K), Answer.Hit);
            _hit17PairsDAS.Add((12, CardFace.Q), Answer.Hit);
            _hit17PairsDAS.Add((12, CardFace.J), Answer.Hit);
            _hit17PairsDAS.Add((12, CardFace.A), Answer.Hit);

            _hit17PairsDAS.Add((14, CardFace._2), Answer.Split);
            _hit17PairsDAS.Add((14, CardFace._3), Answer.Split);
            _hit17PairsDAS.Add((14, CardFace._4), Answer.Split);
            _hit17PairsDAS.Add((14, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((14, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((14, CardFace._7), Answer.Split);
            _hit17PairsDAS.Add((14, CardFace._8), Answer.Hit);
            _hit17PairsDAS.Add((14, CardFace._9), Answer.Hit);
            _hit17PairsDAS.Add((14, CardFace.K), Answer.Hit);
            _hit17PairsDAS.Add((14, CardFace.Q), Answer.Hit);
            _hit17PairsDAS.Add((14, CardFace.J), Answer.Hit);
            _hit17PairsDAS.Add((14, CardFace.A), Answer.Hit);

            _hit17PairsDAS.Add((16, CardFace._2), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._3), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._4), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._7), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._8), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace._9), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace.K), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace.Q), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace.J), Answer.Split);
            _hit17PairsDAS.Add((16, CardFace.A), Answer.Split);

            _hit17PairsDAS.Add((18, CardFace._2), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace._3), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace._4), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace._5), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace._6), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace._7), Answer.Stand);
            _hit17PairsDAS.Add((18, CardFace._8), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace._9), Answer.Split);
            _hit17PairsDAS.Add((18, CardFace.K), Answer.Stand);
            _hit17PairsDAS.Add((18, CardFace.Q), Answer.Stand);
            _hit17PairsDAS.Add((18, CardFace.J), Answer.Stand);
            _hit17PairsDAS.Add((18, CardFace.A), Answer.Stand);

            _hit17PairsDAS.Add((20, CardFace._2), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._3), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._4), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._5), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._6), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._7), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._8), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace._9), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace.K), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace.Q), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace.J), Answer.Stand);
            _hit17PairsDAS.Add((20, CardFace.A), Answer.Stand);

            //_hit17PairsNoDAS

            _hit17PairsNoDAS.Add((4, CardFace._2), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace._3), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace._4), Answer.Split);
            _hit17PairsNoDAS.Add((4, CardFace._5), Answer.Split);
            _hit17PairsNoDAS.Add((4, CardFace._6), Answer.Split);
            _hit17PairsNoDAS.Add((4, CardFace._7), Answer.Split);
            _hit17PairsNoDAS.Add((4, CardFace._8), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace._9), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace.K), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace.Q), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace.J), Answer.Hit);
            _hit17PairsNoDAS.Add((4, CardFace.A), Answer.Hit);

            _hit17PairsNoDAS.Add((6, CardFace._2), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace._3), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace._4), Answer.Split);
            _hit17PairsNoDAS.Add((6, CardFace._5), Answer.Split);
            _hit17PairsNoDAS.Add((6, CardFace._6), Answer.Split);
            _hit17PairsNoDAS.Add((6, CardFace._7), Answer.Split);
            _hit17PairsNoDAS.Add((6, CardFace._8), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace._9), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace.K), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace.Q), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace.J), Answer.Hit);
            _hit17PairsNoDAS.Add((6, CardFace.A), Answer.Hit);

            _hit17PairsNoDAS.Add((8, CardFace._2), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._3), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._4), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._5), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._6), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._7), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._8), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace._9), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace.K), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace.Q), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace.J), Answer.Hit);
            _hit17PairsNoDAS.Add((8, CardFace.A), Answer.Hit);

            _hit17PairsNoDAS.Add((10, CardFace._2), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._3), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._4), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._5), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._6), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._7), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._8), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace._9), Answer.Double);
            _hit17PairsNoDAS.Add((10, CardFace.K), Answer.Hit);
            _hit17PairsNoDAS.Add((10, CardFace.Q), Answer.Hit);
            _hit17PairsNoDAS.Add((10, CardFace.J), Answer.Hit);
            _hit17PairsNoDAS.Add((10, CardFace.A), Answer.Hit);

            _hit17PairsNoDAS.Add((12, CardFace._2), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace._3), Answer.Split);
            _hit17PairsNoDAS.Add((12, CardFace._4), Answer.Split);
            _hit17PairsNoDAS.Add((12, CardFace._5), Answer.Split);
            _hit17PairsNoDAS.Add((12, CardFace._6), Answer.Split);
            _hit17PairsNoDAS.Add((12, CardFace._7), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace._8), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace._9), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace.K), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace.Q), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace.J), Answer.Hit);
            _hit17PairsNoDAS.Add((12, CardFace.A), Answer.Hit);

            _hit17PairsNoDAS.Add((14, CardFace._2), Answer.Split);
            _hit17PairsNoDAS.Add((14, CardFace._3), Answer.Split);
            _hit17PairsNoDAS.Add((14, CardFace._4), Answer.Split);
            _hit17PairsNoDAS.Add((14, CardFace._5), Answer.Split);
            _hit17PairsNoDAS.Add((14, CardFace._6), Answer.Split);
            _hit17PairsNoDAS.Add((14, CardFace._7), Answer.Split);
            _hit17PairsNoDAS.Add((14, CardFace._8), Answer.Hit);
            _hit17PairsNoDAS.Add((14, CardFace._9), Answer.Hit);
            _hit17PairsNoDAS.Add((14, CardFace.K), Answer.Hit);
            _hit17PairsNoDAS.Add((14, CardFace.Q), Answer.Hit);
            _hit17PairsNoDAS.Add((14, CardFace.J), Answer.Hit);
            _hit17PairsNoDAS.Add((14, CardFace.A), Answer.Hit);

            _hit17PairsNoDAS.Add((16, CardFace._2), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._3), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._4), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._5), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._6), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._7), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._8), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace._9), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace.K), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace.Q), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace.J), Answer.Split);
            _hit17PairsNoDAS.Add((16, CardFace.A), Answer.Split);

            _hit17PairsNoDAS.Add((18, CardFace._2), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace._3), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace._4), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace._5), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace._6), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace._7), Answer.Stand);
            _hit17PairsNoDAS.Add((18, CardFace._8), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace._9), Answer.Split);
            _hit17PairsNoDAS.Add((18, CardFace.K), Answer.Stand);
            _hit17PairsNoDAS.Add((18, CardFace.Q), Answer.Stand);
            _hit17PairsNoDAS.Add((18, CardFace.J), Answer.Stand);
            _hit17PairsNoDAS.Add((18, CardFace.A), Answer.Stand);

            _hit17PairsNoDAS.Add((20, CardFace._2), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._3), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._4), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._5), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._6), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._7), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._8), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace._9), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace.K), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace.Q), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace.J), Answer.Stand);
            _hit17PairsNoDAS.Add((20, CardFace.A), Answer.Stand);

            //_stand17PairsDAS

            _stand17PairsDAS.Add((4, CardFace._2), Answer.Split);
            _stand17PairsDAS.Add((4, CardFace._3), Answer.Split);
            _stand17PairsDAS.Add((4, CardFace._4), Answer.Split);
            _stand17PairsDAS.Add((4, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((4, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((4, CardFace._7), Answer.Split);
            _stand17PairsDAS.Add((4, CardFace._8), Answer.Hit);
            _stand17PairsDAS.Add((4, CardFace._9), Answer.Hit);
            _stand17PairsDAS.Add((4, CardFace.K), Answer.Hit);
            _stand17PairsDAS.Add((4, CardFace.Q), Answer.Hit);
            _stand17PairsDAS.Add((4, CardFace.J), Answer.Hit);
            _stand17PairsDAS.Add((4, CardFace.A), Answer.Hit);

            _stand17PairsDAS.Add((6, CardFace._2), Answer.Split);
            _stand17PairsDAS.Add((6, CardFace._3), Answer.Split);
            _stand17PairsDAS.Add((6, CardFace._4), Answer.Split);
            _stand17PairsDAS.Add((6, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((6, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((6, CardFace._7), Answer.Split);
            _stand17PairsDAS.Add((6, CardFace._8), Answer.Hit);
            _stand17PairsDAS.Add((6, CardFace._9), Answer.Hit);
            _stand17PairsDAS.Add((6, CardFace.K), Answer.Hit);
            _stand17PairsDAS.Add((6, CardFace.Q), Answer.Hit);
            _stand17PairsDAS.Add((6, CardFace.J), Answer.Hit);
            _stand17PairsDAS.Add((6, CardFace.A), Answer.Hit);

            _stand17PairsDAS.Add((8, CardFace._2), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace._3), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace._4), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((8, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((8, CardFace._7), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace._8), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace._9), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace.K), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace.Q), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace.J), Answer.Hit);
            _stand17PairsDAS.Add((8, CardFace.A), Answer.Hit);

            _stand17PairsDAS.Add((10, CardFace._2), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._3), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._4), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._5), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._6), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._7), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._8), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace._9), Answer.Double);
            _stand17PairsDAS.Add((10, CardFace.K), Answer.Hit);
            _stand17PairsDAS.Add((10, CardFace.Q), Answer.Hit);
            _stand17PairsDAS.Add((10, CardFace.J), Answer.Hit);
            _stand17PairsDAS.Add((10, CardFace.A), Answer.Hit);

            _stand17PairsDAS.Add((12, CardFace._2), Answer.Split);
            _stand17PairsDAS.Add((12, CardFace._3), Answer.Split);
            _stand17PairsDAS.Add((12, CardFace._4), Answer.Split);
            _stand17PairsDAS.Add((12, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((12, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((12, CardFace._7), Answer.Hit);
            _stand17PairsDAS.Add((12, CardFace._8), Answer.Hit);
            _stand17PairsDAS.Add((12, CardFace._9), Answer.Hit);
            _stand17PairsDAS.Add((12, CardFace.K), Answer.Hit);
            _stand17PairsDAS.Add((12, CardFace.Q), Answer.Hit);
            _stand17PairsDAS.Add((12, CardFace.J), Answer.Hit);
            _stand17PairsDAS.Add((12, CardFace.A), Answer.Hit);

            _stand17PairsDAS.Add((14, CardFace._2), Answer.Split);
            _stand17PairsDAS.Add((14, CardFace._3), Answer.Split);
            _stand17PairsDAS.Add((14, CardFace._4), Answer.Split);
            _stand17PairsDAS.Add((14, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((14, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((14, CardFace._7), Answer.Split);
            _stand17PairsDAS.Add((14, CardFace._8), Answer.Hit);
            _stand17PairsDAS.Add((14, CardFace._9), Answer.Hit);
            _stand17PairsDAS.Add((14, CardFace.K), Answer.Hit);
            _stand17PairsDAS.Add((14, CardFace.Q), Answer.Hit);
            _stand17PairsDAS.Add((14, CardFace.J), Answer.Hit);
            _stand17PairsDAS.Add((14, CardFace.A), Answer.Hit);

            _stand17PairsDAS.Add((16, CardFace._2), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._3), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._4), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._7), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._8), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace._9), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace.K), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace.Q), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace.J), Answer.Split);
            _stand17PairsDAS.Add((16, CardFace.A), Answer.Split);

            _stand17PairsDAS.Add((18, CardFace._2), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace._3), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace._4), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace._5), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace._6), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace._7), Answer.Stand);
            _stand17PairsDAS.Add((18, CardFace._8), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace._9), Answer.Split);
            _stand17PairsDAS.Add((18, CardFace.K), Answer.Stand);
            _stand17PairsDAS.Add((18, CardFace.Q), Answer.Stand);
            _stand17PairsDAS.Add((18, CardFace.J), Answer.Stand);
            _stand17PairsDAS.Add((18, CardFace.A), Answer.Stand);

            _stand17PairsDAS.Add((20, CardFace._2), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._3), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._4), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._5), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._6), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._7), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._8), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace._9), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace.K), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace.Q), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace.J), Answer.Stand);
            _stand17PairsDAS.Add((20, CardFace.A), Answer.Stand);

            //_stand17PairsNoDAS

            _stand17PairsNoDAS.Add((4, CardFace._2), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace._3), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace._4), Answer.Split);
            _stand17PairsNoDAS.Add((4, CardFace._5), Answer.Split);
            _stand17PairsNoDAS.Add((4, CardFace._6), Answer.Split);
            _stand17PairsNoDAS.Add((4, CardFace._7), Answer.Split);
            _stand17PairsNoDAS.Add((4, CardFace._8), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace._9), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace.K), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace.Q), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace.J), Answer.Hit);
            _stand17PairsNoDAS.Add((4, CardFace.A), Answer.Hit);

            _stand17PairsNoDAS.Add((6, CardFace._2), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace._3), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace._4), Answer.Split);
            _stand17PairsNoDAS.Add((6, CardFace._5), Answer.Split);
            _stand17PairsNoDAS.Add((6, CardFace._6), Answer.Split);
            _stand17PairsNoDAS.Add((6, CardFace._7), Answer.Split);
            _stand17PairsNoDAS.Add((6, CardFace._8), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace._9), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace.K), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace.Q), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace.J), Answer.Hit);
            _stand17PairsNoDAS.Add((6, CardFace.A), Answer.Hit);

            _stand17PairsNoDAS.Add((8, CardFace._2), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._3), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._4), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._5), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._6), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._7), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._8), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace._9), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace.K), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace.Q), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace.J), Answer.Hit);
            _stand17PairsNoDAS.Add((8, CardFace.A), Answer.Hit);

            _stand17PairsNoDAS.Add((10, CardFace._2), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._3), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._4), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._5), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._6), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._7), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._8), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace._9), Answer.Double);
            _stand17PairsNoDAS.Add((10, CardFace.K), Answer.Hit);
            _stand17PairsNoDAS.Add((10, CardFace.Q), Answer.Hit);
            _stand17PairsNoDAS.Add((10, CardFace.J), Answer.Hit);
            _stand17PairsNoDAS.Add((10, CardFace.A), Answer.Hit);

            _stand17PairsNoDAS.Add((12, CardFace._2), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace._3), Answer.Split);
            _stand17PairsNoDAS.Add((12, CardFace._4), Answer.Split);
            _stand17PairsNoDAS.Add((12, CardFace._5), Answer.Split);
            _stand17PairsNoDAS.Add((12, CardFace._6), Answer.Split);
            _stand17PairsNoDAS.Add((12, CardFace._7), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace._8), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace._9), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace.K), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace.Q), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace.J), Answer.Hit);
            _stand17PairsNoDAS.Add((12, CardFace.A), Answer.Hit);

            _stand17PairsNoDAS.Add((14, CardFace._2), Answer.Split);
            _stand17PairsNoDAS.Add((14, CardFace._3), Answer.Split);
            _stand17PairsNoDAS.Add((14, CardFace._4), Answer.Split);
            _stand17PairsNoDAS.Add((14, CardFace._5), Answer.Split);
            _stand17PairsNoDAS.Add((14, CardFace._6), Answer.Split);
            _stand17PairsNoDAS.Add((14, CardFace._7), Answer.Split);
            _stand17PairsNoDAS.Add((14, CardFace._8), Answer.Hit);
            _stand17PairsNoDAS.Add((14, CardFace._9), Answer.Hit);
            _stand17PairsNoDAS.Add((14, CardFace.K), Answer.Hit);
            _stand17PairsNoDAS.Add((14, CardFace.Q), Answer.Hit);
            _stand17PairsNoDAS.Add((14, CardFace.J), Answer.Hit);
            _stand17PairsNoDAS.Add((14, CardFace.A), Answer.Hit);

            _stand17PairsNoDAS.Add((16, CardFace._2), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._3), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._4), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._5), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._6), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._7), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._8), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace._9), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace.K), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace.Q), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace.J), Answer.Split);
            _stand17PairsNoDAS.Add((16, CardFace.A), Answer.Split);

            _stand17PairsNoDAS.Add((18, CardFace._2), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace._3), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace._4), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace._5), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace._6), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace._7), Answer.Stand);
            _stand17PairsNoDAS.Add((18, CardFace._8), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace._9), Answer.Split);
            _stand17PairsNoDAS.Add((18, CardFace.K), Answer.Stand);
            _stand17PairsNoDAS.Add((18, CardFace.Q), Answer.Stand);
            _stand17PairsNoDAS.Add((18, CardFace.J), Answer.Stand);
            _stand17PairsNoDAS.Add((18, CardFace.A), Answer.Stand);

            _stand17PairsNoDAS.Add((20, CardFace._2), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._3), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._4), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._5), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._6), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._7), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._8), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace._9), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace.K), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace.Q), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace.J), Answer.Stand);
            _stand17PairsNoDAS.Add((20, CardFace.A), Answer.Stand);

        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetPairAnswer((int playerScore, CardFace dealerFace) matchup)
        {
            if (GlobalSettings.H17)
            {
                if (GlobalSettings.DoubleAfterSplit)
                {
                    return _hit17PairsDAS[matchup];
                }
                else
                {
                    return _hit17PairsNoDAS[matchup];
                }
            }
            else
            {
                if (GlobalSettings.DoubleAfterSplit)
                {
                    return _stand17PairsDAS[matchup];
                }
                else
                {
                    return _stand17PairsNoDAS[matchup];
                }
            }
        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetSoftAnswer((int playerScore, CardFace dealerFace) matchup)
        {
            if (GlobalSettings.H17)
            {
                return _hit17Soft[matchup];
            }
            else
            {
                return _stand17Soft[matchup];
            }
        }

        /// <summary>
        /// Returns the answer to a matchup
        /// </summary>
        /// <param name="matchup"></param>
        /// <returns></returns>
        public static Answer GetHardAnswer((int playerScore, CardFace dealerFace) matchup)
        {
            if (GlobalSettings.H17)
            {
                return _hit17Hard[matchup];
            }
            else
            {
                return _stand17Hard[matchup];
            }
        }
    }
}
