using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    public partial class RunningCountPrompt : ContentPage, INotifyPropertyChanged
    {
        private TaskCompletionSource<int> _taskCompletionSource;

        public RunningCountPrompt(TaskCompletionSource<int> taskCompletionSource)
        {
            InitializeComponent();
            _taskCompletionSource = taskCompletionSource;
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Get the input and trim any extra spaces
            string input = RunningCountEntry.Text?.Trim();

            // If the input is empty, treat it as "0"
            if (string.IsNullOrEmpty(input))
            {
                input = "0"; // Default to 0 if no input is provided
            }

            if (int.TryParse(input, out int userGuess))
            {
                // Return the user guess back to the DeckMode page
                _taskCompletionSource.SetResult(userGuess);

                // Navigate back after submission
                await Navigation.PopAsync();
            }
            else
            {
                // Show an error if the input is not a valid number
                await DisplayAlert("Invalid Input", "Please enter a valid number.", "OK");
            }
        }
    }
}
