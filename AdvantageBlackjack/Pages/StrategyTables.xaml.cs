namespace AdvantageBlackjack;

/// <summary>
/// StrategyTables
/// </summary>
public partial class StrategyTables : ContentPage
{

    /// <summary>
    /// The constructor for the StrategyTables page
    /// </summary>
	public StrategyTables()
	{
		InitializeComponent();

        MenuGrid.IsVisible = false;

        H17Radio.IsChecked = GlobalSettings.H17;
        S17Radio.IsChecked = !GlobalSettings.H17;

        DoubleAfterSplitSwitch.IsToggled = GlobalSettings.DoubleAfterSplit;
    }

    /// <summary>
    /// BasicStrategyBtn clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SoftHandsClicked(object sender, EventArgs e)
    {
        Border newBorder = GlobalSettings.H17 ? H17SoftTotalsBorder : S17SoftTotalsBorder;
        SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    /// <summary>
    /// Pairs clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void PairsClicked(object sender, EventArgs e)
    {
        Border newBorder = GlobalSettings.DoubleAfterSplit
            ? (GlobalSettings.H17 ? H17PairsTableDasBorder : S17PairsTableDasBorder)
            : (GlobalSettings.H17 ? H17PairsTableNoDasBorder : S17PairsTableNoDasBorder);

        SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    /// <summary>
    /// Hard totals clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HardTotalsClicked(object sender, EventArgs e)
    {
        Border newBorder = GlobalSettings.H17 ? H17HardTotalsBorder : S17HardTotalsBorder;
        SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }


    /// <summary>
    /// Animation for sliding a new table into the screen.
    /// </summary>
    /// <param name="oldBorder">The currently visible border</param>
    /// <param name="newBorder">The new border to show</param>
    private async void SlideToNewImage(Border oldBorder, Border newBorder)
    {
        if (oldBorder == newBorder || !oldBorder.IsVisible)
            return;

        const uint animationSpeed = 250;
        double screenWidth = this.Width;

        if (double.IsNaN(screenWidth) || screenWidth == 0)
        {
            screenWidth = 400;
        }

        newBorder.TranslationX = -screenWidth;
        newBorder.IsVisible = true;

        await oldBorder.TranslateTo(screenWidth, 0, animationSpeed, Easing.Linear);
        oldBorder.IsVisible = false;
        oldBorder.TranslationX = 0;

        await newBorder.TranslateTo(0, 0, animationSpeed, Easing.Linear);
    }

    /// <summary>
    /// Returns the currently visible border
    /// </summary>
    /// <returns>Border</returns>
    private Border GetCurrentVisibleBorder()
    {
        if (H17HardTotalsBorder.IsVisible) return H17HardTotalsBorder;
        if (S17HardTotalsBorder.IsVisible) return S17HardTotalsBorder;
        if (H17SoftTotalsBorder.IsVisible) return H17SoftTotalsBorder;
        if (S17SoftTotalsBorder.IsVisible) return S17SoftTotalsBorder;
        if (H17PairsTableDasBorder.IsVisible) return H17PairsTableDasBorder;
        if (S17PairsTableDasBorder.IsVisible) return S17PairsTableDasBorder;
        if (H17PairsTableNoDasBorder.IsVisible) return H17PairsTableNoDasBorder;
        if (S17PairsTableNoDasBorder.IsVisible) return S17PairsTableNoDasBorder;

        return H17HardTotalsBorder;
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
        if (e.Value)
        {
            GlobalSettings.H17 = (sender == H17Radio); // Check which radio button was selected

            Border newBorder = GlobalSettings.H17 ? H17HardTotalsBorder : S17HardTotalsBorder;
            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
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

        // Check if the currently visible table is a Pairs table, and switch it
        if (H17PairsTableDasBorder.IsVisible || H17PairsTableNoDasBorder.IsVisible ||
            S17PairsTableDasBorder.IsVisible || S17PairsTableNoDasBorder.IsVisible)
        {
            Border newBorder = GlobalSettings.DoubleAfterSplit
                ? (GlobalSettings.H17 ? H17PairsTableDasBorder : S17PairsTableDasBorder)
                : (GlobalSettings.H17 ? H17PairsTableNoDasBorder : S17PairsTableNoDasBorder);

            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
        }
    }

    /// <summary>
    /// back clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    async void BackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}