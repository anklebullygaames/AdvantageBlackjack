using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;
using AdvantageBlackjack.Pages;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

namespace AdvantageBlackjack
{
    public partial class AI : ContentPage
    {
        private Account _account;

        private readonly FirebaseAuthClient _authClient;

        public AI(Account account, FirebaseAuthClient authClient)
        {
            _account = account;
            _authClient = authClient;
            InitializeComponent();
        }

        private async Task SaveAccountAsync()
        {
            var user = _authClient.User;
            if (user == null) return;

            string token = await user.GetIdTokenAsync();
            var client = new FirebaseClient(
                "https://ap-blackjack-default-rtdb.firebaseio.com/",
                new FirebaseOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(token)
                });

            await client
                .Child("Accounts")
                .Child(user.Uid)
                .PutAsync(_account);
        }

        /// <summary>
        /// back clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void BackClicked(object sender, EventArgs e)
        {
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }
    }
}
