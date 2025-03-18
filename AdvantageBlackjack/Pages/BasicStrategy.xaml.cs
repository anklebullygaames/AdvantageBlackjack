namespace AdvantageBlackjack;
using AdvantageBlackjack.Blackjack;

/// <summary>
/// Basic Strategy
/// </summary>
public partial class BasicStrategy : ContentPage 
{
    /// <summary>
    /// Whether or not DAS is active
    /// </summary>
    public bool DoubleAfterSplit { get; set; } = true;

    /// <summary>
    /// Whether H17 is active (false means S17 is active)
    /// </summary>
    public bool H17 { get; set; } = true;

    /// <summary>
    /// The dealers blackjack hand
    /// </summary>
    BlackjackHand _dealer;

    /// <summary>
    /// the blayers blackjack hand
    /// </summary>
    BlackjackHand _player;

    /// <summary>
    /// The deck of cards
    /// </summary>
    Deck _deck;

    /// <summary>
    /// The number of rounds played
    /// </summary>
    public int RoundsPlayed;

    /// <summary>
    /// The number of rounds played correctly
    /// </summary>
    public int RoundsCorrect;

    /// <summary>
    /// The percentage of rounds played correctly
    /// </summary>
    public float PercentCorrect => (float)(RoundsCorrect) / (float)(RoundsPlayed);

    /// <summary>
    /// Stores the current matchup as (Player Card Hand, Player Card Hand)
    /// </summary>
    public (BlackjackHand, BlackjackHand) CurrentMatchup;

    /// <summary>
    /// The private backing field for the CurrentAnswer
    /// </summary>
    private Answer _currentAnswer;
    
    /// <summary>
    /// The current answer
    /// </summary>
    public Answer CurrentAnswer
    {
        get
        {
            if (CurrentMatchup.Item1.Cards[0].Face == CurrentMatchup.Item1.Cards[1].Face)
            {
                return AnswerDatabase.GetPairAnswer(CurrentMatchup);
            }

            if (CurrentMatchup.Item1.AceCount == 0)
            {
                return AnswerDatabase.GetHardAnswer(CurrentMatchup);
            }
            if (CurrentMatchup.Item1.AceCount == 1 )
            {
                return AnswerDatabase.GetSoftAnswer(CurrentMatchup);
            }
        }
        private set
        {
            _currentAnswer = value;
        }
    }


    /// <summary>
    /// Constructor fot the BasicStrategy page which creates new player/dealer hands and a new deck then deals the initial cards
    /// </summary>
    public BasicStrategy()
    {
        InitializeComponent();

        _dealer = new BlackjackHand(true);
        _player = new BlackjackHand(false);
        _deck = new Deck();

        DealMoreCards();

    }

    /// <summary>
    /// Resets the hands and deals 2 new cards to both the player and the dealer, updates all
    /// </summary>
    /// <summary>
    /// Resets the hands, deals new cards, updates matchup, and updates UI.
    /// </summary>
    private void DealMoreCards()
    {
        _player = new BlackjackHand(false);
        _dealer = new BlackjackHand(true);

        _deck.Shuffle();
        Card playerCard1 = (Card)_deck.Deal();
        Card playerCard2 = (Card)_deck.Deal();
        Card dealerCard = (Card)_deck.Deal();
        _dealer.AddCard(dealerCard);
        _dealer.AddCard(_deck.Deal());
        _player.AddCard(playerCard1);
        _player.AddCard(playerCard2);

        CurrentMatchup = (_player, _dealer);
        CurrentAnswer = AnswerDatabase.GetAnswer(CurrentMatchup);
        RoundsPlayed++;
        UpdateScoreLabels();
        DrawScreen();
    }

    /// <summary>
    /// Draws the screen to reflect the training
    /// </summary>
    private async void DrawScreen()
    {
        StrategyGrid.Children.Clear();

        double cardWidth = 140;
        double cardHeight = 200;

        double backCardWidth = 225;
        double backCardHeight = 315;

        double screenWidth = StrategyGrid.Width;
        double screenHeight = StrategyGrid.Height;
        double startY = -cardHeight * 2;

        // Player Cards: Animate from left & right
        for (int i = 0; i < _player.Cards.Count; i++)
        {
            string cardImageSource = GetCardImageSource((Card)_player.Cards[i]);
            double startX = (i == 0) ? -screenWidth : screenWidth;

            Image cardImage = new Image
            {
                Source = cardImageSource,
                HeightRequest = cardHeight,
                WidthRequest = cardWidth,
                TranslationX = startX // S
            };

            StrategyGrid.Children.Add(cardImage);
            Grid.SetRow(cardImage, 2);
            Grid.SetColumn(cardImage, i);

            await cardImage.TranslateTo(0, 0, 400, Easing.CubicOut);
        }

        // Dealer Cards: Animate from top
        for (int i = 0; i < _dealer.Cards.Count; i++)
        {
            string cardImageSource = (i == 1) ? "CardImages/back.png" : GetCardImageSource((Card)_dealer.Cards[i]);

            Image cardImage = new Image
            {
                Source = cardImageSource,
                HeightRequest = (i == 1) ? backCardHeight : cardHeight,
                WidthRequest = (i == 1) ? backCardWidth : cardWidth,
                TranslationY = startY
            };

            StrategyGrid.Children.Add(cardImage);
            Grid.SetRow(cardImage, 0);
            Grid.SetColumn(cardImage, i);

            await cardImage.TranslateTo(0, 0, 400, Easing.CubicOut);
        }
    }

    /// <summary>
    /// Updates the labels showing rounds played and percentage correct.
    /// </summary>
    private void UpdateScoreLabels()
    {
        string percentText = (RoundsPlayed > 0) ? $"{(PercentCorrect * 100):0}%" : "0%";
        string fractionText = $"{RoundsCorrect}/{RoundsPlayed}";

        PercentCorrectLabel.Text = percentText;
        FractionCorrectLabel.Text = fractionText;
    }



    /// <summary>
    /// Returns the correct card image source
    /// </summary>
    /// <param name="card">card</param>
    /// <returns>The cards image source</returns>
    private string GetCardImageSource(Card card)
    {
        string suitString = card.Suit.ToString().ToLower();
        int valueInt = (int)card.Face + 1;
        return $"CardImages/{suitString}_{valueInt}.png";
    }

    /// <summary>
    /// Hit click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HitClicked(object sender, EventArgs e)
    {
        DealMoreCards();
        UpdateScoreLabels();
    }

    /// <summary>
    /// Stand click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void StandClicked(object sender, EventArgs e)
    {
        DealMoreCards();
        UpdateScoreLabels();
    }

    /// <summary>
    /// Double click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DoubleClicked(object sender, EventArgs e)
    {
        DealMoreCards();
        RoundsCorrect++;
        UpdateScoreLabels();
    }

    /// <summary>
    /// Split click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SplitClicked(object sender, EventArgs e)
    {
        DealMoreCards();
        RoundsCorrect++;
        UpdateScoreLabels();
    }
}