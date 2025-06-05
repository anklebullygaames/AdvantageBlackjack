using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack.Pages;
using AdvantageBlackjack;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace AdvantageBlackjack
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string username = "Guest";

        public MainPageViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
            Username = _authClient.User?.Info?.DisplayName ?? "Guest";
        }
    }
}
