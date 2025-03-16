namespace AdvantageBlackjack;
using AdvantageBlackjack.Blackjack;

public partial class BasicStrategy : ContentPage 
{
    BlackjackHand _dealer;

    BlackjackHand _player;

    Deck _deck;

    public int RoundsPlayed;

    public int RoundsCorrect;

    public BasicStrategy()
    {
        InitializeComponent();

        _dealer = new BlackjackHand(true);
        _player = new BlackjackHand(false);
        _deck = new Deck();

        DealInitialCards();

    }

    private void DealInitialCards()
    {
        _deck.DeckMethod();
        _deck.Shuffle();
        for (int i = 0; i < 2; i++)
        {
            _player.AddCard(_deck.Deal());
            _dealer.AddCard(_deck.Deal());
        }
        DrawScreen();
    }

    /// <summary>
    /// Resets the hands and deals 2 new cards to both the player and the dealer
    /// </summary>
    private void DealMoreCards()
    {
        _player = new BlackjackHand(false); // Reset the player's hand
        _dealer = new BlackjackHand(true);  // Reset the dealer's hand

        _player.AddCard(_deck.Deal());
        _player.AddCard(_deck.Deal());
        _dealer.AddCard(_deck.Deal());
        _dealer.AddCard(_deck.Deal());

        DrawScreen(); // Update the UI to reflect the new cards
    }

    private void DrawScreen()
    {
        StrategyGrid.Children.Clear();

        double cardWidth = 140;
        double cardHeight = 200;
        
        double backCardWidth = 225;
        double backCardHeight = 315;

        for (int i = 0; i < _dealer.Cards.Count; i++)
        {
            string cardImageSource = (i == 1) ? "CardImages/back.png" : GetCardImageSource((Card)_dealer.Cards[i]);

            Image cardImage = new Image
            {
                Source = cardImageSource,
                HeightRequest = (i == 1) ? backCardHeight : cardHeight,
                WidthRequest = (i == 1) ? backCardWidth : cardWidth
            };
            StrategyGrid.Children.Add(cardImage);
            Grid.SetRow(cardImage, 0);
            Grid.SetColumn(cardImage, i);
        }

        for (int i = 0; i < _player.Cards.Count; i++)
        {
            string cardImageSource = GetCardImageSource((Card)_player.Cards[i]);

            Image cardImage = new Image
            {
                Source = cardImageSource,
                HeightRequest = cardHeight,
                WidthRequest = cardWidth
            };
            StrategyGrid.Children.Add(cardImage);
            Grid.SetRow(cardImage, 2);
            Grid.SetColumn(cardImage, i);
        }
    }


    /// <summary>
    /// returns the image source for a card
    /// </summary>
    /// <param name="card"></param>
    /// <returns></returns>
    private string GetCardImageSource(Card card)
    {
        string suitString = card.Suit.ToString().ToLower();
        int valueInt = (int)card.Face + 1;
        return $"CardImages/{suitString}_{valueInt}.png";
    }

    /// <summary>
    /// Hit event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HitClicked(object sender, EventArgs e)
    {
        DealMoreCards();
    }

    /// <summary>
    /// Stand event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void StandClicked(object sender, EventArgs e)
    {
        DealMoreCards();
    }

    /// <summary>
    /// Double event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DoubleClicked(object sender, EventArgs e)
    {
        DealMoreCards();
    }

    /// <summary>
    /// Split event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SplitClicked(object sender, EventArgs e)
    {
        DealMoreCards();
    }
}