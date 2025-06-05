using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack.Pages;

namespace AdvantageBlackjack.Pages
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage(SignUpViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            EmailEntry.Unfocus();
            PasswordEntry.Unfocus();
        }
    }
}
