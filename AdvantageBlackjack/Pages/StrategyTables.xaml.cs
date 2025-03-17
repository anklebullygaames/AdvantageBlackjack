namespace AdvantageBlackjack;

public partial class StrategyTables : ContentPage
{
	public StrategyTables()
	{
		InitializeComponent();
        MenuGrid.IsVisible = false;

        H17Radio.IsChecked = H17;
        S17Radio.IsChecked = !H17;

        DoubleAfterSplitSwitch.IsToggled = DoubleAfterSplit;
    }

    public bool DoubleAfterSplit { get; set; } = true;

    public bool H17 { get; set; } = true;

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SoftHandsClicked(object sender, EventArgs e)
    {
        Border newBorder = H17 ? H17SoftTotalsBorder : S17SoftTotalsBorder;
        SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    private void PairsClicked(object sender, EventArgs e)
    {
        Border newBorder = DoubleAfterSplit
            ? (H17 ? H17PairsTableDasBorder : S17PairsTableDasBorder)
            : (H17 ? H17PairsTableNoDasBorder : S17PairsTableNoDasBorder);

        SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    private void HardTotalsClicked(object sender, EventArgs e)
    {
        Border newBorder = H17 ? H17HardTotalsBorder : S17HardTotalsBorder;
        SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }


    /// <summary>
    /// Animation for 
    /// </summary>
    /// <param name="oldImage">The currently visible image</param>
    /// <param name="newImage">The new image to show</param>
    private async void SlideToNewImage(Border oldBorder, Border newBorder)
    {
        if (oldBorder == newBorder || !oldBorder.IsVisible)
            return;

        const uint animationSpeed = 250;
        double screenWidth = this.Width;

        if (double.IsNaN(screenWidth) || screenWidth == 0)
        {
            screenWidth = 400; // Fallback value
        }

        // Ensure new border starts off-screen left
        newBorder.TranslationX = -screenWidth;
        newBorder.IsVisible = true;

        // Animate old border out
        await oldBorder.TranslateTo(screenWidth, 0, animationSpeed, Easing.Linear);
        oldBorder.IsVisible = false;
        oldBorder.TranslationX = 0; // Reset position

        // Animate new border in
        await newBorder.TranslateTo(0, 0, animationSpeed, Easing.Linear);
    }


    private Image DetermineNewVisibleImage()
    {
        return H17 ? H17HardTotalsTable : S17HardTotalsTable;
    }

    /// <summary>
    /// Returns the currently visible image
    /// </summary>
    /// <returns>The currently visible Image</returns>
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

        return H17HardTotalsBorder; // Default to H17 Hard Totals if no table is active
    }

    async void SettingsClicked(object sender, EventArgs e)
    {
        _ = MainContentGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, 800u, Easing.CubicIn);
        await MainContentGrid.ScaleTo(0.8, 800u);
        _ = MainContentGrid.FadeTo(0.8, 800u);

        MenuGrid.TranslationY = 1000; // Start position off-screen
        MenuGrid.IsVisible = true; // Make it visible before animation
        await MenuGrid.TranslateTo(0, 0, 500, Easing.CubicOut); // Slide up
    }

    async void GridAreaClicked(object sender, EventArgs e)
    {
        await MenuGrid.TranslateTo(0, 1000, 500, Easing.CubicIn); // Slide back down
        MenuGrid.IsVisible = false; // Hide after animation

        _ = MainContentGrid.FadeTo(1, 800u);
        _ = MainContentGrid.ScaleTo(1, 800u);
        await MainContentGrid.TranslateTo(0, 0, 800u, Easing.CubicIn);
    }

    private void DealerRuleToggled(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            H17 = (sender == H17Radio); // Check which radio button was selected

            Border newBorder = H17 ? H17HardTotalsBorder : S17HardTotalsBorder;
            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
        }
    }

    private void DoubleAfterSplitToggled(object sender, ToggledEventArgs e)
    {
        DoubleAfterSplit = e.Value;

        // Check if the currently visible table is a Pairs table, and switch it
        if (H17PairsTableDasBorder.IsVisible || H17PairsTableNoDasBorder.IsVisible ||
            S17PairsTableDasBorder.IsVisible || S17PairsTableNoDasBorder.IsVisible)
        {
            Border newBorder = DoubleAfterSplit
                ? (H17 ? H17PairsTableDasBorder : S17PairsTableDasBorder)
                : (H17 ? H17PairsTableNoDasBorder : S17PairsTableNoDasBorder);

            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
        }
    }
}