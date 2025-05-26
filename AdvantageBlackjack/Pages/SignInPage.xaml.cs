using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    public partial class SignInPage : ContentPage, INotifyPropertyChanged
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string email = "anklebullygames@gmail.com";
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Missing Information", "Please enter both an email and password.", "OK");
                return;
            }

            try
            {
                var session = await SupabaseClient.Client.Auth.SignIn(email: email, password: password);

                if (session.User != null)
                {
                    // Optionally fetch the user's account info if needed
                    var response = await SupabaseClient.Client
                        .From<Account>()
                        .Where(a => a.Email == email)
                        .Get();

                    var userAccount = response.Models.FirstOrDefault();

                    if (userAccount != null)
                    {
                        Preferences.Set("email", email);
                        Preferences.Set("password", password);
                        await Shell.Current.GoToAsync("//MainPage");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Login Failed", $"Error: {ex.Message}", "OK");
            }
        }

        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            EmailEntry.Unfocus();
            PasswordEntry.Unfocus();
        }


        public new event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        /// <summary>
        /// back clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void BackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// back clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void SignUpClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("SignUpPage");
        }
    }
}
