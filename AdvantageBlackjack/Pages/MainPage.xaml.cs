namespace AdvantageBlackjack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeOpacity();
            AnimateUI();
        }

        private async void AnimateUI()
        {
            await Task.Delay(1000);  // Wait before animating
            await LogoImage.FadeTo(1, 1750, Easing.CubicInOut); 
            await FadeIn(Subheader, 0);
            await FadeIn(BasicStrategyBtn, 0);
            await FadeIn(PairsAndSoftHandsBtn, 0);
            await FadeIn(StrategyTableBtn, 0);
            await FadeIn(CountingBtn, 0);
        }

        private void InitializeOpacity()
        {
            LogoImage.Opacity = 0;
            Subheader.Opacity = 0;
            BasicStrategyBtn.Opacity = 0;
            PairsAndSoftHandsBtn.Opacity = 0;
            StrategyTableBtn.Opacity = 0;
            CountingBtn.Opacity = 0;
        }

        private async Task FadeIn(View element, int delay)
        {
            await Task.Delay(delay);  // Wait before animating
            await element.FadeTo(1, 100, Easing.CubicInOut);  // Smooth fade-in over 0.8s
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void BasicStrategyClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("BasicStrategy");
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void CountingClicked(object sender, EventArgs e)
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

        private async void PairsAndSoftHandsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("PairsAndSoftHands");
        }
    }

}
