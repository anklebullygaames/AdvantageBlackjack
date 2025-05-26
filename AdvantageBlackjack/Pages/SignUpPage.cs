using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    public partial class SignUpPage : ContentPage, INotifyPropertyChanged
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();
            string password = PasswordEntry.Text;
            string username = UsernameEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(password) || 
                string.IsNullOrWhiteSpace(username))
            {
                await DisplayAlert("Missing Information", "Please enter email, password, and username.", "OK");
                return;
            }

            try
            {
                var session = await SupabaseClient.Client.Auth.SignUp(email: email, password: password);

                if (session.User != null)
                {
                    var newAccount = new Account
                    {
                        Email = email,
                        Username = username,
                        ProfilePicUrl = "",
                        Diamonds = 0,
                        CorrectCounts = 0,
                        CorrectPlays = 0,
                        MissedHands = 0
                    };

                    await SupabaseClient.Client.From<Account>().Insert(newAccount);

                    Preferences.Set("email", email);
                    Preferences.Set("password", password);

                    await Shell.Current.GoToAsync("//MainPage");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Sign Up Failed", $"Error: {ex.Message}", "OK");
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
    }
}
