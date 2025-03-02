namespace AdvantageBlackjack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void BasicStrategyClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not Implemented", "Cancel");
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void OptionsClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not Implemented", "Cancel");
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void StrategyTableClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("StrategyTables");
        }

        private void PairsAndSoftHandsClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not Implemented", "Cancel");
        }
    }

}
