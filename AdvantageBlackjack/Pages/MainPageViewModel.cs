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
        private string _username = "Guest";

        [ObservableProperty]
        private Account _account;

        public int Diamonds => Account?.Diamonds ?? 0;

        partial void OnAccountChanged(Account value)
        {
            OnPropertyChanged(nameof(Diamonds));
        }

        public MainPageViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
            Username = _authClient.User?.Info?.DisplayName ?? "Guest";
        }
    }
}