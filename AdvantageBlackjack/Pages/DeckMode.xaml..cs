using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using AdvantageBlackjack.Blackjack;

namespace AdvantageBlackjack
{
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
        /// Stopwatch for timing
        /// </summary>
        private Stopwatch _stopwatch = new();

        /// <summary>
        /// Private backing field for time text
        /// </summary>
        private string _timeText = "0:00";

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
        /// the private backing field for the last answer
        /// </summary>
        private int _lastUserAnswer;

        /// <summary>
        /// the last answer
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
                return true; // Repeat
            });
        }

        private async void LoadNextCard()
        {
            if (_cardsSwiped >= MaxCards)
            {
                _stopwatch.Stop();

                bool retry = await DisplayAlert(
                    "Deck Complete",
                    $"You finished the deck in {TimeText}\nwith an accuracy of {AccuracyText}",
                    "Retry",
                    "Back"
                );

                if (retry)
                {
                    // Reset stats
                    _cardsSwiped = 0;
                    _correct = 0;
                    _incorrect = 0;
                    AccuracyText = "0%";
                    TimeText = "0:00";
                    AccuracyLabel.TextColor = Colors.Black;

                    // Reset deck and timer
                    _deck = new Deck();
                    _deck.Shuffle();
                    _stopwatch.Reset();
                    _stopwatch.Start();

                    LoadNextCard(); // Load the first card
                }
                else
                {
                    await Shell.Current.GoToAsync("..");
                }

                return;
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

        private async void OnCardSwiped(object sender, SwipedEventArgs e)
        {
            // Store direction text for debugging
            LastSwipeDelta = $"Swipe: {e.Direction}";

            int userDirection = e.Direction switch
            {
                SwipeDirection.Left => -1,
                SwipeDirection.Right => 1,
                SwipeDirection.Down => 0,
                _ => -2 // For Up or unknown
            };

            LastUserAnswer = userDirection;

            if (userDirection == CurrentAnswer)
            {
                _correct++;
                AccuracyLabel.TextColor = Colors.Green;
            }
            else
            {
                _incorrect++;
                AccuracyLabel.TextColor = Colors.Red;
            }

            _cardsSwiped++;

            AccuracyText = $"{(int)((float)_correct / (_correct + _incorrect) * 100)}%";

            uint duration = 200;
            double screenWidth = Width;
            double screenHeight = Height;

            double targetX = e.Direction switch
            {
                SwipeDirection.Left => -screenWidth,
                SwipeDirection.Right => screenWidth,
                _ => 0
            };

            double targetY = e.Direction switch
            {
                SwipeDirection.Down => screenHeight,
                _ => 0
            };

            await CardImage.TranslateTo(targetX, targetY, duration, Easing.SinIn);

            // Reset position and color
            CardImage.TranslationX = 0;
            CardImage.TranslationY = 0;
            AccuracyLabel.TextColor = Colors.Black;

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
            await MenuGrid.TranslateTo(0, 1000, 500, Easing.CubicIn); // Slide back down
            MenuGrid.IsVisible = false; // Hide after animation

            _ = MainContentGrid.FadeTo(1, 800u);
            _ = MainContentGrid.ScaleTo(1, 800u);
            await MainContentGrid.TranslateTo(0, 0, 800u, Easing.CubicIn);
        }

        /// <summary>
        /// Dealer rule changed event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void DealerRuleToggled(object sender, CheckedChangedEventArgs e)
        {

        }
    }
}