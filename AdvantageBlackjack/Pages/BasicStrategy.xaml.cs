namespace AdvantageBlackjack;
using AdvantageBlackjack.Blackjack;
using AdvantageBlackjack.Pages;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

/// <summary>
/// Basic Strategy
/// </summary>
public partial class BasicStrategy : ContentPage 
{
    private readonly Account _account;

    private readonly FirebaseAuthClient _authClient;

    /// <summary>
    /// The dealers blackjack hand
    /// </summary>
    BlackjackHand _dealer;

    /// <summary>
    /// The players blackjack hand
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
    /// The number of aces in the player hand
    /// </summary>
    public int PlayerAces;

    /// <summary>
    /// Whether the play hand is currently a pair
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
    /// Constructor for the BasicStrategy page
    /// </summary>
    public BasicStrategy(Account account, FirebaseAuthClient authClient)
    {
        InitializeComponent();
        _account = account;
        _authClient = authClient;
        MainBack.SetValue(Grid.ZIndexProperty, 2);
        BasicStrategyHeader.SetValue(Grid.ZIndexProperty, 1);
        StrategyGrid.SetValue(Grid.ZIndexProperty, 0);

        H17Radio.IsChecked = GlobalSettings.H17;
        S17Radio.IsChecked = !GlobalSettings.H17;
        DoubleDeckRadio.IsChecked = GlobalSettings.DoubleDeck;
        FourDeckRadio.IsChecked = !GlobalSettings.DoubleDeck;
        DoubleAfterSplitSwitch.IsToggled = GlobalSettings.DoubleAfterSplit;
        SurrenderSwitch.IsToggled = GlobalSettings.Surrender;

        _dealer = new BlackjackHand(true);
        _player = new BlackjackHand(false);
        _deck = new Deck();
        _deck.Shuffle();

        _ = AnimateSurrenderButton(GlobalSettings.Surrender);

        DealStartCards();

    }

    /// <summary>
    /// Deals the initial cards to the player and deal
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
    /// Deals more cards to the player and dealer
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
    /// Draws the screen
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

        for (int i = 0; i < _player.Cards.Count; i++)
        {
            string cardImageSource = GetCardImageSource((Card)_player.Cards[i]);
            double startX = (i == 0) ? -screenWidth : screenWidth;

            Image cardImage = new Image
            {
                Source = cardImageSource,
                HeightRequest = cardHeight,
                WidthRequest = cardWidth,
                TranslationX = startX
            };

            StrategyGrid.Children.Add(cardImage);
            Grid.SetRow(cardImage, 2);
            Grid.SetColumn(cardImage, i);

            await cardImage.TranslateTo(0, 0, 400, Easing.CubicOut);
        }

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
    /// Updates the rounds played and percentage correct labels
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

    // <summary>
    /// Animates the surrender button in or out from the left
    /// </summary>
    /// <param name="isVisible">Whether the button should slide in or out</param>
    private async Task AnimateSurrenderButton(bool isVisible)
    {
        if (isVisible)
        {
            SurrenderButton.IsVisible = true;
            SurrenderButton.TranslationX = -this.Width;
            await Task.WhenAll(
                SurrenderButton.TranslateTo(0, 0, 100, Easing.CubicOut),
                AdjustActionButtons(true)
            );
        }
        else
        {
            SurrenderButton.IsVisible = false;
            await Task.WhenAll(
                SurrenderButton.TranslateTo(-this.Width, 0, 100, Easing.CubicIn),
                AdjustActionButtons(false)
            );
        }
    }


    /// <summary>
    /// Adjusts the vertical position of the action buttons when Surrender is shown or hidden
    /// </summary>
    /// <param name="moveDown">True to move buttons down, false to reset them</param>
    private async Task AdjustActionButtons(bool moveDown)
    {
        double offset = moveDown ? 35 : 0;

        var tasks = new[]
        {
            HitButton.TranslateTo(0, offset, 250, Easing.CubicOut),
            StandButton.TranslateTo(0, offset, 250, Easing.CubicOut),
            DoubleButton.TranslateTo(0, offset, 250, Easing.CubicOut),
            SplitButton.TranslateTo(0, offset, 250, Easing.CubicOut)
        };

        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Returns a cards image source
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
        _account.Diamonds += 1;
        _account.CorrectPlays += (CurrentAnswer == Answer.Hit) ? 1 : 0;
        _account.IncorrectPlays += (CurrentAnswer != Answer.Hit) ? 1 : 0;

        RoundsCorrect += (CurrentAnswer == Answer.Hit) ? 1 : 0;
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
        _account.Diamonds += 1;
        _account.CorrectPlays += (CurrentAnswer == Answer.Stand) ? 1 : 0;
        _account.IncorrectPlays += (CurrentAnswer != Answer.Stand) ? 1 : 0;

        RoundsCorrect += (CurrentAnswer == Answer.Stand) ? 1 : 0;
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
        _account.Diamonds += 1;
        _account.CorrectPlays += (CurrentAnswer == Answer.Double) ? 1 : 0;
        _account.IncorrectPlays += (CurrentAnswer != Answer.Double) ? 1 : 0;

        RoundsCorrect += (CurrentAnswer == Answer.Double) ? 1 : 0;

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
        _account.Diamonds += 1;
        _account.CorrectPlays += (CurrentAnswer == Answer.Split) ? 1 : 0;
        _account.IncorrectPlays += (CurrentAnswer != Answer.Split) ? 1 : 0;

        RoundsCorrect += (CurrentAnswer == Answer.Split) ? 1 : 0;
        DealMoreCards();
        UpdateScoreLabels();
    }

    /// <summary>
    /// Surrender click event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SurrenderClicked(object sender, EventArgs e)
    {
        _account.Diamonds += 1;
        _account.CorrectPlays += (CurrentAnswer == Answer.Surrender) ? 1 : 0;
        _account.IncorrectPlays += (CurrentAnswer != Answer.Surrender) ? 1 : 0;

        RoundsCorrect += (CurrentAnswer == Answer.Surrender) ? 1 : 0;
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
    /// <param name="sender">snder</param>
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
    /// Dealer rule changed event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DealerRuleToggled(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            GlobalSettings.H17 = (sender == H17Radio);
            _account.H17 = GlobalSettings.H17;
        }
    }

    /// <summary>
    /// Dealer rule changed event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DeckRuleToggled(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            GlobalSettings.DoubleDeck = (sender == DoubleDeckRadio);
            _account.DoubleDeck = GlobalSettings.DoubleDeck;
        }
    }

    /// <summary>
    /// Surrender switched event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SurrenderToggled(object sender, ToggledEventArgs e)
    {
        GlobalSettings.Surrender = e.Value;
        _account.Surrender = GlobalSettings.Surrender;
        _ = AnimateSurrenderButton(e.Value);
    }

    /// <summary>
    /// DAS switched event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DoubleAfterSplitToggled(object sender, ToggledEventArgs e)
    {
        GlobalSettings.DoubleAfterSplit = e.Value;
        _account.DoubleAfterSplit = GlobalSettings.DoubleAfterSplit;
    }

    /// <summary>
    /// Hint clicked event handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async void HintClicked(object sender, EventArgs e)
    {
        Button correctButton = null;

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
            await correctButton.ScaleTo(1.2, 300, Easing.CubicOut);
            await correctButton.ScaleTo(1.0, 300, Easing.CubicIn);
        }
    }

    private async void BackClicked(object sender, EventArgs e)
    {
        if (_authClient.User != null)
        {
            try
            {
                string token = await _authClient.User.GetIdTokenAsync();

                var firebaseClient = new FirebaseClient(
                    "https://ap-blackjack-default-rtdb.firebaseio.com/",
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(token)
                    });

                await firebaseClient
                    .Child("Accounts")
                    .Child(_authClient.User.Uid)
                    .PutAsync(_account);

                Console.WriteLine("Account saved before returning to MainPage.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving account: {ex.Message}");
            }
        }

        await Shell.Current.GoToAsync("..");
    }
}