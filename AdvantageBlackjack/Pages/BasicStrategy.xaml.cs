namespace AdvantageBlackjack;
using AdvantageBlackjack.Blackjack;

/// <summary>
/// Basic Strategy
/// </summary>
public partial class BasicStrategy : ContentPage 
{

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
    public (int PlayerScore, CardFace DealerFace) CurrentMatchup;

    /// <summary>
    /// The property for the players aces
    /// </summary>
    public int PlayerAces;

    /// <summary>
    /// Property to track pair
    /// </summary>
    public bool Pair = false;

    /// <summary>
    /// The current answer
    /// </summary>
    public Answer CurrentAnswer
    {
        get
        {
            if (PlayerAces == 2)
                return Answer.Split;

            else if (PlayerAces == 1)
                return AnswerDatabase.GetSoftAnswer(CurrentMatchup);

            else
                if (Pair)
                {
                    return AnswerDatabase.GetPairAnswer(CurrentMatchup);
                }
                else
                {
                    return AnswerDatabase.GetHardAnswer(CurrentMatchup);
                }
        }
    }


    /// <summary>
    /// Constructor fot the BasicStrategy page which creates new player/dealer hands and a new deck then deals the initial cards
    /// </summary>
    public BasicStrategy()
    {
        InitializeComponent();

        BasicStrategyHeader.SetValue(Grid.ZIndexProperty, 1);
        StrategyGrid.SetValue(Grid.ZIndexProperty, 0);
        MainBack.SetValue(Grid.ZIndexProperty, 2);

        H17Radio.IsChecked = GlobalSettings.H17;
        S17Radio.IsChecked = !GlobalSettings.H17;
        DoubleAfterSplitSwitch.IsToggled = GlobalSettings.DoubleAfterSplit;

        _dealer = new BlackjackHand(true);
        _player = new BlackjackHand(false);
        _deck = new Deck();
        _deck.Shuffle();

        DealStartCards();

    }

    /// <summary>
    /// Makes the hands and deals 2 cards to both the player and the dealer, updates all
    /// </summary>
    /// <summary>
    /// Resets the hands, deals new cards, updates matchup, and updates UI.
    /// </summary>
    private void DealStartCards()
    {
        _player = new BlackjackHand(false);
        _dealer = new BlackjackHand(true);

        BlackjackCard playerCard1;
        BlackjackCard playerCard2;

        do
        {
            playerCard1 = (BlackjackCard)_deck.Deal();
            playerCard2 = (BlackjackCard)_deck.Deal();
        }
        while (playerCard1.Value + playerCard2.Value == 21);


        BlackjackCard dealerCard = (BlackjackCard)_deck.Deal();
        _dealer.AddCard(dealerCard);
        _dealer.AddCard(_deck.Deal());
        _player.AddCard(playerCard1);
        _player.AddCard(playerCard2);

        CurrentMatchup = (playerCard1.Value + playerCard2.Value, dealerCard.Face);
        if (playerCard1.Face == playerCard2.Face)
        {
            Pair = true;
        }
        if (playerCard1.Face == CardFace.A)
        {
            PlayerAces++;
        }
        if (playerCard2.Face == CardFace.A)
        {
            PlayerAces++;
        }

        UpdateScoreLabels();
        DrawScreen();
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
        Pair = false;
        PlayerAces = 0;

        BlackjackCard playerCard1;
        BlackjackCard playerCard2;

        do
        {
            playerCard1 = (BlackjackCard)_deck.Deal();
            playerCard2 = (BlackjackCard)_deck.Deal();
        }
        while (playerCard1.Value + playerCard2.Value == 21);

        BlackjackCard dealerCard = (BlackjackCard)_deck.Deal();
        _dealer.AddCard(dealerCard);
        _dealer.AddCard(_deck.Deal());
        _player.AddCard(playerCard1);
        _player.AddCard(playerCard2);



        CurrentMatchup = (playerCard1.Value + playerCard2.Value, dealerCard.Face);

        if (playerCard1.Face == playerCard2.Face)
        {
            Pair = true;
        }
        if (playerCard1.Face == CardFace.A)
        {
            PlayerAces++;
        }
        if (playerCard2.Face == CardFace.A)
        {
            PlayerAces++;
        }

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
            string cardImageSource = (i == 1) ? "back.png" : GetCardImageSource((Card)_dealer.Cards[i]);

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
        string currentAnswer = $"ANS: {CurrentAnswer.ToString()}";
        string currentAceCount = $"AC: {PlayerAces.ToString()}";
        string currentPair = $"Pair: {Pair.ToString()}";

        PercentCorrectLabel.Text = percentText;
        FractionCorrectLabel.Text = fractionText;
        AnswerLabel.Text = currentAnswer;
        PairLabel.Text = currentPair;
        AceLabel.Text = currentAceCount;
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
        return $"{suitString}_{valueInt}.png";
    }

    /// <summary>
    /// Hit click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HitClicked(object sender, EventArgs e)
    {
        if (CurrentAnswer == Answer.Hit)
        {
            RoundsCorrect++;
        }
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
        if (CurrentAnswer == Answer.Stand)
        {
            RoundsCorrect++;
        }
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
        if (CurrentAnswer == Answer.Double)
        {
            RoundsCorrect++;
        }
        DealMoreCards();
        UpdateScoreLabels();
    }

    /// <summary>
    /// Split click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SplitClicked(object sender, EventArgs e)
    {
        if (CurrentAnswer == Answer.Split)
        {
            RoundsCorrect++;
        }
        DealMoreCards();
        UpdateScoreLabels();
    }

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
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        if (e.Value)
        {
            GlobalSettings.H17 = (sender == H17Radio); // Check which radio button was selected
        }
    }

    /// <summary>
    /// DAS switched event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DoubleAfterSplitToggled(object sender, ToggledEventArgs e)
    {
        GlobalSettings.DoubleAfterSplit = e.Value;
    }

    async void HintClicked(object sender, EventArgs e)
    {
        Button correctButton = null;

        // Determine which button should animate based on the correct answer
        switch (CurrentAnswer)
        {
            case Answer.Hit:
                correctButton = HitButton;
                break;
            case Answer.Stand:
                correctButton = StandButton;
                break;
            case Answer.Double:
                correctButton = DoubleButton;
                break;
            case Answer.Split:
                correctButton = SplitButton;
                break;
        }

        if (correctButton != null)
        {
            await correctButton.ScaleTo(1.2, 300, Easing.CubicOut); // Enlarge slightly
            await correctButton.ScaleTo(1.0, 300, Easing.CubicIn);  // Return to normal
        }
    }

    /// <summary>
    /// back clicked event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void BackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}