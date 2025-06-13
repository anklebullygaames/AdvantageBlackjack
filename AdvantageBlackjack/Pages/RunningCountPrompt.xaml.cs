using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack;

namespace AdvantageBlackjack
{
    /// <summary>
    /// RunningCountPrompt
    /// </summary>
    public partial class RunningCountPrompt : ContentPage, INotifyPropertyChanged
    {
        /// <summary>
        /// The running count prompt answers
        /// </summary>
        private TaskCompletionSource<int> _taskCompletionSource;

        /// <summary>
        /// The running count prompt constructor
        /// </summary>
        /// <param name="taskCompletionSource"></param>
        public RunningCountPrompt(TaskCompletionSource<int> taskCompletionSource)
        {
            InitializeComponent();
            _taskCompletionSource = taskCompletionSource;
        }

        /// <summary>
        /// Submit clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            string input = RunningCountEntry.Text?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                input = "0";
            }

            if (int.TryParse(input, out int userGuess))
            {
                _taskCompletionSource.SetResult(userGuess);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Invalid Input", "Please enter a valid number.", "OK");
            }
        }
    }
}
