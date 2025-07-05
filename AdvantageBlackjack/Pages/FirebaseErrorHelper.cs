using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    public static class FirebaseErrorHelper
    {
        public static string GetFriendlyMessage(string rawMessage)
        {
            if (rawMessage.Contains("EMAIL_EXISTS"))
                return "Email is already in use.";
            if (rawMessage.Contains("INVALID_EMAIL"))
                return "Please enter a valid email address.";
            if (rawMessage.Contains("INVALID_LOGIN"))
                return "Invalid credentials, Please try again.";

            return rawMessage;
        }
    }
}
