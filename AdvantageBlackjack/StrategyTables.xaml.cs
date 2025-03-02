namespace AdvantageBlackjack;

public partial class StrategyTables : ContentPage
{
	public StrategyTables()
	{
		InitializeComponent();
	}

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SoftHandsClicked(object sender, EventArgs e)
    {
        HardTotalsTable.IsVisible = false;
        SoftTotalsTable.IsVisible = true;
        PairsTable.IsVisible = false;
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void PairsClicked(object sender, EventArgs e)
    {
        HardTotalsTable.IsVisible = false;
        SoftTotalsTable.IsVisible = false;
        PairsTable.IsVisible = true;
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HardTotalsClicked(object sender, EventArgs e)
    {
        HardTotalsTable.IsVisible = true;
        SoftTotalsTable.IsVisible = false;
        PairsTable.IsVisible = false;
    }
}