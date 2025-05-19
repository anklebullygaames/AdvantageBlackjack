using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;

namespace AdvantageBlackjack
{
    /// <summary>
    /// DeckMode
    /// </summary>
    public partial class DeckMode : ContentPage, INotifyPropertyChanged
    {

        /// <summary>
        /// The current card
        /// </summary>
        private BlackjackCard _currentCard;

        /// <summary>
        /// The deck of cards
        /// </summary>
        private Deck _deck;

        /// <summary>
        /// Number of cards swiped so far
        /// </summary>
        private int _cardsSwiped = 0;

        /// <summary>
        /// Cards in a deck
        /// </summary>
        private const int MaxCards = 52;

        /// <summary>
        /// Number correct so far
        /// </summary>
        private int _correct = 0;

        /// <summary>
        /// Number incorrect so far
        /// </summary>
        private int _incorrect = 0;

        /// <summary>
        /// The stopwatch
        /// </summary>
        private Stopwatch _stopwatch = new();

        /// <summary>
        /// Private backing field for time text
        /// </summary>
        private string _timeText = "0:00";

        /// <summary>
        /// Private backing field for the running count
        /// </summary>
        private int _runningCount = 0;

        /// <summary>
        /// Private backing field for the nex prompt threshold
        /// </summary>
        private int _nextPromptThreshold = 0;

        /// <summary>
        /// The number of running count promts correct so far
        /// </summary>
        private int _runningCountCorrect = 0;

        /// <summary>
        /// The number of running count prompts incorrect so far
        /// </summary>
        private int _runningCountIncorrect = 0;

        /// <summary>
        /// A random number
        /// </summary>
        private Random _rand = new();

        /// <summary>
        /// The time text
        /// </summary>
        public string TimeText
        {
            get => _timeText;
            set { _timeText = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// The accuracy text private backing field
        /// </summary>
        private string _accuracyText = "0%";

        /// <summary>
        /// The accuracy text
        /// </summary>
        public string AccuracyText
        {
            get => _accuracyText;
            set { _accuracyText = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// The current answer private backing field
        /// </summary>
        private int _currentAnswer;

        /// <summary>
        /// Whether race mode is enabled
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private bool _isRaceMode = true;

        /// <summary>
        /// The current answer based on the card showing
        /// </summary>
        public int CurrentAnswer
        {
            get => _currentAnswer;
            set
            {
                _currentAnswer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The private backing field for the last answer
        /// </summary>
        private int _lastUserAnswer;

        /// <summary>
        /// The last answer
        /// </summary>
        public int LastUserAnswer
        {
            get => _lastUserAnswer;
            set
            {
                _lastUserAnswer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The last swipe data private backing field
        /// </summary>
        private string _lastSwipeDelta = "X:0 Y:0";

        /// <summary>
        /// the last swipe data
        /// </summary>
        public string LastSwipeDelta
        {
            get => _lastSwipeDelta;
            set { _lastSwipeDelta = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// The deck mode page constructor
        /// </summary>
        public DeckMode()
        {
            InitializeComponent();
            BindingContext = this;
            _deck = new Deck();
            _deck.Shuffle();
            _stopwatch.Start();
            _nextPromptThreshold = _rand.Next(7, 13);

            StartTimer();
            LoadNextCard();
        }

        /// <summary>
        /// Starts the stopwatch
        /// </summary>
        private void StartTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TimeText = _stopwatch.Elapsed.ToString(@"m\:ss");
                return true;
            });
        }

        /// <summary>
        /// Loads the next card
        /// </summary>
        private async void LoadNextCard()
        {
            if (_cardsSwiped >= MaxCards)
            {
                _stopwatch.Stop();

                if (!_isRaceMode)
                {
                    await DisplayAlert("Deck Complete!", $"You answered {AccuracyText} running count questions correctly", "Retry");
                }
                else
                {
                    await DisplayAlert("Deck Complete!", $"You finished the deck in {TimeText}\nwith an accuracy of {AccuracyText}", "Retry");
                }

                _runningCount = 0;
                _nextPromptThreshold = _rand.Next(7, 13);
                _cardsSwiped = 0;
                _correct = 0;
                _incorrect = 0;
                if (_isRaceMode)
                {
                    AccuracyText = "0/0";
                }
                else
                {
                    AccuracyText = "0%";
                }

                TimeText = "0:00";
                AccuracyLabel.TextColor = Colors.Black;

                _deck = new Deck();
                _deck.Shuffle();
                _stopwatch.Reset();
                _stopwatch.Start();

                LoadNextCard();
            }


            _currentCard = (BlackjackCard)_deck.Deal();

            CardImage.Source = $"{_currentCard.Suit.ToString().ToLower()}_{(int)_currentCard.Face + 1}.png";

            int value = _currentCard.Value;
            CurrentAnswer = value switch
            {
                >= 2 and <= 6 => 1,
                >= 7 and <= 9 => 0,
                _ => -1
            };

        }

        /// <summary>
        /// Handles a swipe action
        /// </summary>
        /// <param name="direction">direction</param>
        private async void HandleSwipe(SwipeDirection direction)
        {
            LastSwipeDelta = $"Tapped: {direction}";

            int userDirection = direction switch
            {
                SwipeDirection.Left => -1,
                SwipeDirection.Right => 1,
                SwipeDirection.Down => 0,
                _ => -2
            };

            LastUserAnswer = userDirection;

            if (userDirection == CurrentAnswer)
            {
                _correct++;
                if (_isRaceMode) AccuracyLabel.TextColor = Colors.ForestGreen;
            }
            else
            {
                _incorrect++;
                if (_isRaceMode) AccuracyLabel.TextColor = Colors.DarkRed;
            }

            _cardsSwiped++;

            if (!_isRaceMode)
            {
                AccuracyText = $"{_runningCountCorrect}/{_runningCountCorrect + _runningCountIncorrect}";
            }
            else
            {
                AccuracyText = $"{(int)((float)_correct / (_correct + _incorrect) * 100)}%";
            }

            uint duration = 200;
            double screenWidth = Width;
            double screenHeight = Height;

            double targetX = direction switch
            {
                SwipeDirection.Left => -screenWidth,
                SwipeDirection.Right => screenWidth,
                _ => 0
            };

            double targetY = direction == SwipeDirection.Down ? screenHeight : 0;

            await CardImage.TranslateTo(targetX, targetY, duration, Easing.SinIn);

            CardImage.TranslationX = 0;
            CardImage.TranslationY = 0;

            int cardValue = _currentCard.Value;
            if (cardValue >= 2 && cardValue <= 6)
                _runningCount++;
            else if (cardValue >= 10 || _currentCard.Face == CardFace.A)
                _runningCount--;

            if (!_isRaceMode && _cardsSwiped == _nextPromptThreshold)
            {
                _nextPromptThreshold += _rand.Next(7, 13);
                await PromptRunningCount();
            }
            LoadNextCard();
        }

        /// <summary>
        /// Back to main menu
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private async void BackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        /// <summary>
        /// Gets the card swipe direction
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void OnCardSwiped(object sender, SwipedEventArgs e)
        {
            HandleSwipe(e.Direction);
        }

        /// <summary>
        /// Property changed event
        /// </summary>
        public new event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property changed invoker
        /// </summary>
        /// <param name="name">name</param>
        void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        /// <summary>
        /// Settings clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void SettingsClicked(object sender, EventArgs e)
        {
            _ = MainContentGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, 800u, Easing.CubicIn);
            await MainContentGrid.ScaleTo(0.8, 800u);
            _ = MainContentGrid.FadeTo(0.8, 800u);

            MenuGrid.TranslationY = 1000;
            MenuGrid.IsVisible = true;
            await MenuGrid.TranslateTo(0, 0, 500, Easing.CubicOut);
        }

        /// <summary>
        /// Options back clicked event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        async void OptionsBackClicked(object sender, EventArgs e)
        {
            await MenuGrid.TranslateTo(0, 1000, 500, Easing.CubicIn);
            MenuGrid.IsVisible = false;

            _ = MainContentGrid.FadeTo(1, 800u);
            _ = MainContentGrid.ScaleTo(1, 800u);
            await MainContentGrid.TranslateTo(0, 0, 800u, Easing.CubicIn);
        }

        /// <summary>
        /// Dealer rule toggled event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DealerRuleToggled(object sender, CheckedChangedEventArgs e)
        {
            if (RaceRadio.IsChecked)
            {
                _isRaceMode = true;
                TimeLabel.IsVisible = true;

                Grid.SetColumn(AccuracyLabel, 29);
                Grid.SetColumnSpan(AccuracyLabel, 8);
            }
            else if (RunningCountRadio.IsChecked)
            {
                _isRaceMode = false;
                TimeLabel.IsVisible = false;

                Grid.SetColumn(AccuracyLabel, 0);
                Grid.SetColumnSpan(AccuracyLabel, 40);
            }

            _deck = new Deck();
            _deck.Shuffle();

            _stopwatch.Reset();
            _stopwatch.Start();

            _cardsSwiped = 0;
            _correct = 0;
            _incorrect = 0;
            _runningCount = 0;
            _runningCountCorrect = 0;
            _runningCountIncorrect = 0;
            _nextPromptThreshold = _rand.Next(7, 13);

            TimeText = "0:00";
            AccuracyText = _isRaceMode ? "0%" : "0/0";
            AccuracyLabel.TextColor = Colors.Black;

            LoadNextCard();
        }

        /// <summary>
        /// Left arrow image tapped event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void LeftArrowTapped(object sender, EventArgs e) => HandleSwipe(SwipeDirection.Left);

        /// <summary>
        /// Down arrow image tapped event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DownArrowTapped(object sender, EventArgs e) => HandleSwipe(SwipeDirection.Down);

        /// <summary>
        /// Right arrow image tapped event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void RightArrowTapped(object sender, EventArgs e) => HandleSwipe(SwipeDirection.Right);

        /// <summary>
        /// Promps the user for the current running count
        /// </summary>
        /// <returns>Task</returns>
        private async Task PromptRunningCount()
        {
            var taskCompletionSource = new TaskCompletionSource<int>();

            var runningCountPrompt = new RunningCountPrompt(taskCompletionSource);
            await Navigation.PushAsync(runningCountPrompt);

            int userGuess = await taskCompletionSource.Task;

            if (userGuess == _runningCount)
            {
                _runningCountCorrect++;
                await DisplayAlert("Correct!", "Keep it going.", "OK");
            }
            else
            {
                _runningCountIncorrect++;
                await DisplayAlert("Incorrect", $"The correct running count was {_runningCount}.", "OK");
            }

            int totalGuesses = _runningCountCorrect + _runningCountIncorrect;
            AccuracyText = $"{_runningCountCorrect}/{totalGuesses}";
        }

        /// <summary>
        /// Restarts the current mode (Race or Running Count)
        /// </summary>
        private void RestartClicked(object sender, EventArgs e)
        {
            _deck = new Deck();
            _deck.Shuffle();

            _stopwatch.Reset();
            _stopwatch.Start();

            _cardsSwiped = 0;
            _correct = 0;
            _incorrect = 0;
            _runningCount = 0;
            _runningCountCorrect = 0;
            _runningCountIncorrect = 0;
            _nextPromptThreshold = _rand.Next(7, 13);

            TimeText = "0:00";
            AccuracyText = _isRaceMode ? "0%" : "0/0";
            AccuracyLabel.TextColor = Colors.Black;

            LoadNextCard();
            
            OptionsBackClicked(sender, e);
        }

    }
}