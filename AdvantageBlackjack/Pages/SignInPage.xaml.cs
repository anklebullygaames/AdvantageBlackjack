using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack.Pages;
using Firebase.Auth;

namespace AdvantageBlackjack.Pages
{
    public partial class SignInPage : ContentPage
    {

        public SignInPage(SignInViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }

        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            EmailEntry.Unfocus();
            PasswordEntry.Unfocus();
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
    }
}
