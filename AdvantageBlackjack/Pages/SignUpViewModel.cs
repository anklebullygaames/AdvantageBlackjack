using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace AdvantageBlackjack
{
    public partial class SignUpViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _authClient;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;

        [RelayCommand]
        private async Task SignUp()
        {
            try
            {
                await _authClient.CreateUserWithEmailAndPasswordAsync(Email, Password, Username);
                await Shell.Current.GoToAsync("///MainPage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Sign-up failed: " + ex.Message);
                await Shell.Current.DisplayAlert("Sign-Up Failed", ex.Message, "OK");
            }
            finally
            {
                Password = string.Empty;
            }
        }


        [RelayCommand]
        private async Task NavigateSignIn()
        {
            await Shell.Current.GoToAsync("///SignInPage");
        }

        public SignUpViewModel(FirebaseAuthClient authClient)
        {
            _authClient = authClient;
        }
    }
}
