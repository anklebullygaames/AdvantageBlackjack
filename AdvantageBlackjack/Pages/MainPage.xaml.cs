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

            DeckModeBtn.Opacity = 0;
            DeckModeBtn.TranslationY = 100;

            DeckModeImage.Opacity = 0;
            DeckModeImage.TranslationY = 100;

            DealModeBtn.Opacity = 0;
            DealModeBtn.TranslationY = 100;

            DealModeImage.Opacity = 0;
            DealModeImage.TranslationY = 100;
        }

        private async void AnimateUI()
        {

            await LogoImage.FadeTo(1, 1000, Easing.CubicInOut);

            await SlideUpFromBottom(Subheader, 0);
            await SlideUpFromBottom(BasicStrategyBtn, 0);
            await SlideUpFromBottom(PairsAndSoftHandsBtn, 0);
            await SlideUpFromBottom(StrategyTableBtn, 0);
            await SlideUpFromBottom(CountingBtn, 0);
            await SlideUpFromBottom(DeckModeBtn, 0);
            await SlideUpFromBottom(DeckModeImage, 0);
            await SlideUpFromBottom(DealModeBtn, 0);
            await SlideUpFromBottom(DealModeImage, 0);
        }

        private async Task SlideUpFromBottom(View element, int delay)
        {
            await Task.Delay(delay);
            element.Opacity = 1;
            await element.TranslateTo(0, 0, 150, Easing.SinOut);
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
        private async void DeckModeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("DeckMode");
        }

        /// <summary>
        /// Deal mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void DealModeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("DealMode");
        }
    }
}
