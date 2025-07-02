using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    public partial class About : ContentPage
    {
        public About()
        {
            InitializeComponent();
            MainLabel.Text = AboutMessage;
            MainBack.SetValue(Grid.ZIndexProperty, 1);
        }

        private string AboutMessage = "AP Blackjack Trainer is a tool designed to help you master basic strategy and HILO card counting. Every feature is built to train you and keep things as simple as possible. The All Hands page asks you to make the right decision while giving you feedback. The Pairs and Soft Hands page trains you on only those situations so that you can focus on concepts like split and double down. The Strategy Tables page contains the answers for all matchups. Settings are adjustable and can be set to match the blackjack rules you prefer. Deal Mode and Deck Mode help you practice the HILO card counting system. \n\nThe more you train the better you get, so stick with it and dont give up!";

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
