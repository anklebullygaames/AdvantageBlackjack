using Supabase;
using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack
{
    /// <summary>
    /// GlobalSettings
    /// </summary>
    public static class GlobalSettings
    {
        /// <summary>
        /// CurrentSession
        /// </summary>
        public static Session? CurrentSession => SupabaseClient.Client.Auth.CurrentSession;

        /// <summary>
        /// Determines if the dealer hits on soft 17 (H17 = true) or stands (S17 = false)
        /// </summary>
        public static bool H17 { get; set; } = true;

        /// <summary>
        /// Determines if double after split is allowed (true) or not (false)
        /// </summary>
        public static bool DoubleAfterSplit { get; set; } = true;

        /// <summary>
        /// Determines if surrender is allowed (true) or not (false)
        /// </summary>
        public static bool Surrender { get; set; } = false;

        /// <summary>
        /// Determines if double deck is (true) or not (false)
        /// </summary>
        public static bool DoubleDeck { get; set; } = false;
    }
}
