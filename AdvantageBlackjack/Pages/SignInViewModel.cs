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
    public partial class SignInViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        [RelayCommand]
        private async Task SignIn()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Missing Info", "Please enter both email and password.", "OK");
                return;
            }

            try
            {
                await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);
                await Shell.Current.GoToAsync("////MainPage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sign-in failed: " + ex.Message);
                string message = FirebaseErrorHelper.GetFriendlyMessage(ex.Message);
                await Shell.Current.DisplayAlert("Sign-In Failed", message, "OK");
            }
            finally
            {
                Password = string.Empty;
            }
        }

        [RelayCommand]
        private async Task NavigateSignUp()
        {
            await Shell.Current.GoToAsync("///SignUpPage");
        }

        public SignInViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }
    }
}
