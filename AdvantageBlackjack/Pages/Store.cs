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
    public partial class Store : ContentPage
    {
        private Account _account;

        private readonly FirebaseAuthClient _authClient;

        public Store(Account account, FirebaseAuthClient authClient)
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
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// blank icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void BlankUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 0;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void ClubUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 1;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void HeartUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 2;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void DiamondUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 3;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void SpadeUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 4;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void AlienUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 5;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void DiceUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 6;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// club icon clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void GoldenDiceUserIconClicked(object sender, EventArgs e)
        {
            _account.ProfilePic = 7;
            await SaveAccountAsync();
            await Shell.Current.GoToAsync("..");
        }
    }
}
