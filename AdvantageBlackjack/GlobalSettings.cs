using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack
{
    public static class GlobalSettings
    {
        /// <summary>
        /// Determines if the dealer hits on soft 17 (H17 = true) or stands (S17 = false)
        /// </summary>
        public static bool H17 { get; set; } = true;

        /// <summary>
        /// Determines if double after split is allowed (true) or not (false)
        /// </summary>
        public static bool DoubleAfterSplit { get; set; } = true;
    }
}
