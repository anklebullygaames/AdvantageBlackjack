using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;

namespace AdvantageBlackjack.Pages
{
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private readonly FirebaseAuthClient _authClient;

        public Account CurrentAccount { get; set; } = new Account();

        public string Username => _authClient.User?.Info?.DisplayName ?? "Guest";

        /// <summary>
        /// The main page constructor
        /// </summary>
        public MainPage(MainPageViewModel viewModel, FirebaseAuthClient authClient)
        {
            InitializeComponent();
            _authClient = authClient;
            BindingContext = viewModel;
            this.Loaded += OnPageLoaded;
            StartAnimations();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            bool isSignedIn = _authClient.User != null;

            if (BindingContext is MainPageViewModel vm)
            {
                vm.Username = isSignedIn ? _authClient.User?.Info?.DisplayName ?? "Guest" : "Guest";
                UpdateUserImage();
            }

            SignInBtn.IsVisible = !isSignedIn;
            SignOutBtn.IsVisible = isSignedIn;
            StatsBtn.IsVisible = isSignedIn;
            StoreBtn.IsVisible = isSignedIn;
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

            try
            {
                var user = _authClient.User;

                if (user != null)
                {
                    string uid = user.Uid;
                    string token = await user.GetIdTokenAsync();

                    // FirebaseClient that sends the auth token
                    var firebaseClient = new FirebaseClient(
                        "https://ap-blackjack-default-rtdb.firebaseio.com/",
                        new FirebaseOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(token)
                        });

                    // Try to load existing account
                    var account = await firebaseClient
                        .Child("Accounts")
                        .Child(uid)
                        .OnceSingleAsync<Account>();

                    if (account != null)
                    {
                        CurrentAccount = account;
                        if (BindingContext is MainPageViewModel vm)
                        {
                            vm.Account = account;
                        }
                        Console.WriteLine("Account loaded successfully!");
                    }
                    else
                    {
                        // Create a default account for new users
                        CurrentAccount = new Account
                        {
                            Username = user.Info?.DisplayName ?? "Guest",
                        };
                        await firebaseClient
                            .Child("Accounts")
                            .Child(uid)
                            .PutAsync(CurrentAccount);
                        Console.WriteLine("No account found. New account created.");
                    }
                }
                else
                {
                    Console.WriteLine("User not signed in.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading account: {ex.Message}");
            }

            UpdateUserImage();
            AnimateUI();
        }

        private void UpdateUserImage()
        {
            string[] iconSources = {
                "blankusericon.png",     // 0
                "clubusericon.png",      // 1
                "heartusericon.png",     // 2
                "diamondusericon.png",   // 3
                "spadeusericon.png",     // 4
                "alienusericon.png",     // 5
                "diceusericon.png",      // 6
                "goldendiceusericon.png" // 7
            };

            if (BindingContext is MainPageViewModel vm && vm.Account != null)
            {
                int iconIndex = vm.Account.ProfilePic;
                if (iconIndex >= 0 && iconIndex < iconSources.Length)
                {
                    UserImage.Source = iconSources[iconIndex];
                }
                else
                {
                    UserImage.Source = iconSources[0];
                }
            }
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

            bool isSignedIn = _authClient.User != null;

            SignInBtn.IsVisible = !isSignedIn;
            SignOutBtn.IsVisible = isSignedIn;
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
            if (BindingContext is MainPageViewModel vm)
            {
                var accountToUse = _authClient.User != null ? vm.Account : new Account();
                await Shell.Current.Navigation.PushAsync(new BasicStrategy(accountToUse, _authClient));
            }
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
            if (BindingContext is MainPageViewModel vm)
            {
                var accountToUse = _authClient.User != null ? vm.Account : new Account();
                await Shell.Current.Navigation.PushAsync(new PairsAndSoftHands(accountToUse, _authClient));
            }
        }

        /// <summary>
        /// Deck mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void DeckModeClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();

            var guestAccount = new Account();

            if (BindingContext is MainPageViewModel vm)
            {
                var accountToUse = _authClient.User != null ? vm.Account : guestAccount;
                await Shell.Current.Navigation.PushAsync(new DeckMode(accountToUse, _authClient));
            }
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
        /// store event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void StoreClicked(object sender, EventArgs e)
        {
            bool isSignedIn = _authClient.User != null;
            if (isSignedIn)
            {
                if (BindingContext is MainPageViewModel vm && vm.Account != null)
                {
                    await Shell.Current.Navigation.PushAsync(new Store(vm.Account, _authClient));
                }
            }
        }

        /// <summary>
        /// Deck mode event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void SignInClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///SignInPage");
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
        /// StatsBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void StatsClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();

            if (BindingContext is MainPageViewModel vm && vm.Account != null)
            {
                await Shell.Current.Navigation.PushAsync(new Stats(vm.Account));
            }
        }

        /// <summary>
        /// AboutBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void AboutClicked(object sender, EventArgs e)
        {
            await SlideOutButtons();
            await Shell.Current.GoToAsync("About");
        }

        /// <summary>
        /// AIBtn event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void AIClicked(object sender, EventArgs e)
        {
            bool isSignedIn = _authClient.User != null;
            if (isSignedIn)
            {
                if (BindingContext is MainPageViewModel vm && vm.Account != null)
                {
                    await Shell.Current.Navigation.PushAsync(new AI(vm.Account, _authClient));
                }
            }
            else
            {
                await DisplayAlert("Sign In", "Sign in for AI assistance.", "Done");
            }
        }

        private async void SignOutClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Sign Out", "Do you want to sign out?", "Yes", "Cancel");

            if (!confirm)
                return;

            _authClient.SignOut();

            SignInBtn.IsVisible = true;
            SignOutBtn.IsVisible = false;
            StatsBtn.IsVisible = false;

            if (BindingContext is MainPageViewModel vm)
            {
                vm.Username = "Guest";
                vm.Account = new Account();
                UpdateUserImage();
            }
        }
    }
}