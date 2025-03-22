namespace AdvantageBlackjack
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += OnPageLoaded;
        }

        private async void OnPageLoaded(object sender, EventArgs e)
        {
            // Wait for layout to be ready
            while (MainGrid.Width == 0)
                await Task.Delay(50);

            InitializeUIState();
            MoveCountingElementsOffScreen();
            AnimateUI();
        }

        private void InitializeUIState()
        {
            LogoImage.Opacity = 0;

            Subheader.Opacity = 0;
            Subheader.TranslationY = 100;

            BasicStrategyBtn.Opacity = 0;
            BasicStrategyBtn.TranslationY = 100;

            PairsAndSoftHandsBtn.Opacity = 0;
            PairsAndSoftHandsBtn.TranslationY = 100;

            StrategyTableBtn.Opacity = 0;
            StrategyTableBtn.TranslationY = 100;

            CountingBtn.Opacity = 0;
            CountingBtn.TranslationY = 100;
        }

        private void MoveCountingElementsOffScreen()
        {
            double screenWidth = MainGrid.Width;

            DealModeBtn.TranslationX = screenWidth;
            DealModeImage.TranslationX = screenWidth;

            DeckModeBtn.TranslationX = -screenWidth;
            DeckModeImage.TranslationX = -screenWidth;

            DealModeBtn.IsVisible = false;
            DealModeImage.IsVisible = false;
            DeckModeBtn.IsVisible = false;
            DeckModeImage.IsVisible = false;
        }

        private bool _countingOptionsVisible = false;

        private async void AnimateUI()
        {
            await Task.Delay(1000);  // Wait before animating

            await LogoImage.FadeTo(1, 1500, Easing.CubicInOut);

            await SlideUpFromBottom(Subheader, 0);
            await SlideUpFromBottom(BasicStrategyBtn, 0);
            await SlideUpFromBottom(PairsAndSoftHandsBtn, 0);
            await SlideUpFromBottom(StrategyTableBtn, 0);
            await SlideUpFromBottom(CountingBtn, 0);
        }

        private async Task SlideUpFromBottom(View element, int delay)
        {
            await Task.Delay(delay);
            element.Opacity = 1;
            await element.TranslateTo(0, 0, 200, Easing.SinOut);
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
        private async void CountingClicked(object sender, EventArgs e)
        {
            _countingOptionsVisible = !_countingOptionsVisible;

            if (_countingOptionsVisible)
            {
                DealModeBtn.IsVisible = true;
                DealModeImage.IsVisible = true;
                DeckModeBtn.IsVisible = true;
                DeckModeImage.IsVisible = true;

                await Task.WhenAll(
                    DealModeBtn.TranslateTo(0, 0, 400, Easing.SinOut),
                    DealModeImage.TranslateTo(0, 0, 400, Easing.SinOut),
                    DeckModeBtn.TranslateTo(0, 0, 400, Easing.SinOut),
                    DeckModeImage.TranslateTo(0, 0, 400, Easing.SinOut)
                );
            }
            else
            {
                await Task.WhenAll(
                    DealModeBtn.TranslateTo(1000, 0, 400, Easing.SinIn),
                    DealModeImage.TranslateTo(1000, 0, 400, Easing.SinIn),
                    DeckModeBtn.TranslateTo(-1000, 0, 400, Easing.SinIn),
                    DeckModeImage.TranslateTo(-1000, 0, 400, Easing.SinIn)
                );

                DealModeBtn.IsVisible = false;
                DealModeImage.IsVisible = false;
                DeckModeBtn.IsVisible = false;
                DeckModeImage.IsVisible = false;
            }
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

        /// <summary>
        /// deck mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DeckModeClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not Implemented", "Cancel");
        }

        /// <summary>
        /// Deal mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DealModeClicked(object sender, EventArgs e)
        {
            DisplayAlert("Error", "Not Implemented", "Cancel");
        }
    }

}
