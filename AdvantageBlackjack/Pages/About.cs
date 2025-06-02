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
        }

        private string AboutMessage = "AP Blackjack Trainer is designed to help you master basic strategy and HILO card counting so that you can beat the casinos. Every feature is built to train you and keep things simple. The All Hands page asks you to make the right decision while giving you feedback. The Pairs and Soft Hands page mixes those hand types so that you can focus on concepts like split and double down. The Strategy Tables page contains the answers for all matchups. Settings are adjustable and can be set to match the blackjack table rules you prefer. Deal Mode and Deck Mode help you practice the HILO counting system. The more you train the better you get, so stick with it and dont give up! \n\n- Isaiah";

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
