namespace AdvantageBlackjack;
using AdvantageBlackjack.Blackjack;

public partial class BasicStrategy : ContentPage
{
    BlackjackHand _dealer;
    BlackjackHand _player;
    Deck _deck;

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

    private void DrawScreen()
    {
        StrategyGrid.Children.Clear();
        for (int i = 0; i < _dealer.Cards.Count; i++)
        {
            if (_dealer.Cards[i] is Card card) // Ensure it's a Card
            {
                string cardImageSource = GetCardImageSource(card);
                Image cardImage = new Image
                {
                    Source = cardImageSource,
                    HeightRequest = 200,
                    WidthRequest = 140
                };

                // Add the image to the grid
                StrategyGrid.Children.Add(cardImage);
                Grid.SetRow(cardImage, 0); // Dealer is in row 0
                Grid.SetColumn(cardImage, i); // Spread across columns
            }
        }

        // Display Player's Hand (Row 2)
        for (int i = 0; i < _player.Cards.Count; i++)
        {
            if (_player.Cards[i] is Card card)
            {
                string cardImageSource = GetCardImageSource(card);
                Image cardImage = new Image
                {
                    Source = cardImageSource,
                    HeightRequest = 200,
                    WidthRequest = 140
                };

                // Add the image to the grid
                StrategyGrid.Children.Add(cardImage);
                Grid.SetRow(cardImage, 2); // Player is in row 2
                Grid.SetColumn(cardImage, i);
            }
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

    }

    /// <summary>
    /// Stand event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void StandClicked(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Double event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DoubleClicked(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Split event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SplitClicked(object sender, EventArgs e)
    {

    }
}