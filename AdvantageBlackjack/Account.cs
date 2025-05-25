using System;
using Supabase.Postgrest;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvantageBlackjack
{
    [Table("accounts")]
    public class Account : BaseModel
    {
        [PrimaryKey("id", false)]
        public long Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [Column("diamonds")]
        public int Diamonds { get; set; }

        [Column("correct_counts")]
        public int CorrectCounts { get; set; }

        [Column("correct_plays")]
        public int CorrectPlays { get; set; }

        [Column("missed_hands")]
        public int MissedHands { get; set; }
    }
}
