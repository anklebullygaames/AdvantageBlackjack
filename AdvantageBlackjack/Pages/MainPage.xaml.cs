namespace AdvantageBlackjack
{
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : ContentPage
    {

        /// <summary>
        /// The main page constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += OnPageLoaded;
            InitializeSupabase();
            StartAnimations();
        }

        /// <summary>
        /// Whether the user is in the options menu
        /// </summary>
        private bool _isInSettingsMenu = false;

        /// <summary>
        /// Starts the resting page animations
        /// </summary>
        private async void StartAnimations()
        {
            StartStrategyTables();
            StartBasicStrategy();
            StartPairs();
        }

        /// <summary>
        /// Starts basic strategy button animation
        /// </summary>
        private async void StartBasicStrategy()
        {
            await AnimateBasicStrategy();
        }

        /// <summary>
        /// Starts strategy tables button animation
        /// </summary>
        private async void StartStrategyTables()
        {
            await AnimateStrategyTables();
        }

        /// <summary>
        /// Starts the pairs button animation
        /// </summary>
        private async void StartPairs()
        {
            await AnimatePairs();
        }

        /// <summary>
        /// Waits for the page to load then does initial animations
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void OnPageLoaded(object sender, EventArgs e)
        {
            while (MainContentGrid.Width == 0)
            {
                await Task.Delay(50);
            }

            InitializeUIState();
            AnimateUI();
        }

        /// <summary>
        /// Sets the correct state and opcity before beginning animation
        /// </summary>
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

            CountingLabel.Opacity = 0;
            CountingLabel.TranslationY = 100;

            DeckModeBtn.Opacity = 0;
            DeckModeBtn.TranslationY = 100;

            DeckModeImage.Opacity = 0;
            DeckModeImage.TranslationY = 100;

            DealModeBtn.Opacity = 0;
            DealModeBtn.TranslationY = 100;

            DealModeImage.Opacity = 0;
            DealModeImage.TranslationY = 100;
        }

        /// <summary>
        /// Does the initial load in animation
        /// </summary>
        private async void AnimateUI()
        {

            await LogoImage.FadeTo(1, 1000, Easing.CubicIn);

            await SlideInButtons();
        }

        /// <summary>
        /// Animates the basic strategy button
        /// </summary>
        /// <returns>Task</returns>
        private async Task AnimateBasicStrategy()
        {
            while (true)
            {
                await BasicStrategyBtn.ScaleTo(1.02, 1000, Easing.CubicInOut);
                await BasicStrategyBtn.ScaleTo(.98, 1000, Easing.CubicInOut);
            }
        }

        /// <summary>
        /// Animates the strategy tables
        /// </summary>
        /// <returns>Task</returns>
        private async Task AnimateStrategyTables()
        {
            while (true)
            {
                await StrategyTableBtn.ScaleTo(1.02, 1000, Easing.CubicInOut);
                await StrategyTableBtn.ScaleTo(.98, 1000, Easing.CubicInOut);
            }
        }

        /// <summary>
        /// Animates the pairs
        /// </summary>
        /// <returns>Task</returns>
        private async Task AnimatePairs()
        {
            while (true)
            {
                await PairsAndSoftHandsBtn.ScaleTo(1.02, 1000, Easing.CubicInOut);
                await PairsAndSoftHandsBtn.ScaleTo(.98, 1000, Easing.CubicInOut);
            }
        }

        /// <summary>
        /// Slides a button up from button
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Task</returns>
        private async Task SlideUpFromBottom(View element)
        {
            element.Opacity = 1;
            await element.TranslateTo(0, 0, 150, Easing.CubicOut);
        }

        /// <summary>
        /// Slides a button down to bottom
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Task</returns>
        private async Task SlideDownToBottom(View element)
        {
            await element.TranslateTo(0, 1000, 75, Easing.CubicIn);  // Slide down
            element.Opacity = 0;  // Optional: fade out as it moves
        }

        /// <summary>
        /// Slides all the buttons down to bttom
        /// </summary>
        /// <returns>Task</returns>
        private async Task SlideOutButtons()
        {
            await SlideDownToBottom(DealModeImage);
            await SlideDownToBottom(DealModeBtn);
            await SlideDownToBottom(DeckModeImage);
            await SlideDownToBottom(DeckModeBtn);
            await SlideDownToBottom(CountingLabel);
            await SlideDownToBottom(StrategyTableBtn);
            await SlideDownToBottom(PairsAndSoftHandsBtn);
            await SlideDownToBottom(BasicStrategyBtn);
            await SlideDownToBottom(Subheader);
        }

        /// <summary>
        /// Slides all the buttons up
        /// </summary>
        /// <returns>Task</returns>
        private async Task SlideInButtons()
        {
            await SlideUpFromBottom(Subheader);
            await SlideUpFromBottom(BasicStrategyBtn);
            await SlideUpFromBottom(PairsAndSoftHandsBtn);
            await SlideUpFromBottom(StrategyTableBtn);
            await SlideUpFromBottom(CountingLabel);
            await SlideUpFromBottom(DeckModeBtn);
            await SlideUpFromBottom(DeckModeImage);
            await SlideUpFromBottom(DealModeBtn);
            await SlideUpFromBottom(DealModeImage);
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void BasicStrategyClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("BasicStrategy");
        }

        /// <summary>
        /// BasicStrategyBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void StrategyTableClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("StrategyTables");
        }

        /// <summary>
        /// Pairs and soft hands event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void PairsAndSoftHandsClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("PairsAndSoftHands");
        }

        /// <summary>
        /// Deck mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void DeckModeClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("DeckMode");
        }

        /// <summary>
        /// Deal mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void DealModeClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("DealMode");
        }

        /// <summary>
        /// Settings clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void MenuClicked(object sender, EventArgs e)
        {
            if (!_isInSettingsMenu)
            {
                double targetX = this.Width / 2;

                await MainContentGrid.TranslateTo(targetX, 0, 250, Easing.CubicOut);
                MenuGrid.TranslationY = 500;
                await UserImage.TranslateTo(-200, 0, 400, Easing.CubicOut);
                MenuGrid.IsVisible = true;
                await MenuGrid.TranslateTo(0, 0, 400, Easing.CubicOut);
                _isInSettingsMenu = true;
            }
        }

        /// <summary>
        /// Deck mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void SignInClicked(object sender, EventArgs e)
        {   
            await Navigation.PushAsync(new SignInPage());
            return;
        }

        /// <summary>
        /// Initialize Supabase
        /// </summary>
        private async void InitializeSupabase()
        {
            if (!SupabaseClient.IsInitialized)
            {
                await SupabaseClient.Initialize();
            }

            if (GlobalSettings.CurrentSession == null || GlobalSettings.CurrentSession.User == null)
            {
                SignInBtn.IsVisible = true;
            }
            else
            {
                SignInBtn.IsVisible = false;
            }
        }

        /// <summary>
        /// Options back clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void OptionsBackClicked(object sender, EventArgs e)
        {
            _isInSettingsMenu = false;

            await UserImage.TranslateTo(0, 0, 400, Easing.CubicIn);

            await MenuGrid.TranslateTo(0, 500, 400, Easing.CubicIn);
            MenuGrid.IsVisible = false;

            await MainContentGrid.TranslateTo(0, 0, 250, Easing.CubicIn);
        }

        /// <summary>
        /// RecordsBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void RecordsClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("BasicStrategy");
        }

        /// <summary>
        /// StatsBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void StatsClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("BasicStrategy");
        }

        /// <summary>
        /// AboutBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void AboutClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("BasicStrategy");
        }

        /// <summary>
        /// AIBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void AIClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("BasicStrategy");
        }

        /// <summary>
        /// MissedBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void MissedClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("BasicStrategy");
        }

    }
}
