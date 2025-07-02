using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack.Pages;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    public partial class Stats : ContentPage
    {
        private Account _account;

        public Stats(Account account)
        {
            InitializeComponent();
            MainBack.SetValue(Grid.ZIndexProperty, 1);
            _account = account;

            CorrectPlaysLabel.Text = $"Correct Plays: {_account.CorrectPlays}";
            IncorrectPlaysLabel.Text = $"Incorrect Plays: {_account.IncorrectPlays}";
            CorrectPromptsLabel.Text = $"Correct Running Counts: {_account.CorrectPrompts}";
            IncorrectPromptsLabel.Text = $"Incorrect Running Counts: {_account.IncorrectPrompts}";
            CorrectSwipesLabel.Text = $"Correct Card Swipes: {_account.CorrectSwipes}";
            IncorrectSwipesLabel.Text = $"Incorrect Card Swipes: {_account.IncorrectSwipes}";
            TimeSpan bestTimeSpan = TimeSpan.FromSeconds(_account.BestTime);
            BestTimeLabel.Text = $"Best Deck Time: {bestTimeSpan.Minutes}:{bestTimeSpan.Seconds:D2}";

            int totalPlays = _account.CorrectPlays + _account.IncorrectPlays;
            if (totalPlays > 0)
            {
                double percent = (double)_account.CorrectPlays / totalPlays * 100;
                PlayPercentLabel.Text = $"{(int)percent}%";
            }
            else
            {
                PlayPercentLabel.Text = "100%";
            }
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
