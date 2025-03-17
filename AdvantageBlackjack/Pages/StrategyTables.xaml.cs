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
        Image newImage = H17 ? H17SoftTotalsTable : S17SoftTotalsTable;
        SlideToNewImage(GetCurrentVisibleImage(), newImage);
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void PairsClicked(object sender, EventArgs e)
    {
        Image newImage;

        if (DoubleAfterSplit)
            newImage = H17 ? H17PairsTableDas : S17PairsTableDas;
        else
            newImage = H17 ? H17PairsTableNoDas : S17PairsTableNoDas;

        SlideToNewImage(GetCurrentVisibleImage(), newImage);
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HardTotalsClicked(object sender, EventArgs e)
    {
        Image newImage = H17 ? H17HardTotalsTable : S17HardTotalsTable;
        SlideToNewImage(GetCurrentVisibleImage(), newImage);
    }

    /// <summary>
    /// Animation for 
    /// </summary>
    /// <param name="oldImage">The currently visible image</param>
    /// <param name="newImage">The new image to show</param>
    private async void SlideToNewImage(Image oldImage, Image newImage)
    {
        if (oldImage == newImage || !oldImage.IsVisible)
            return;

        const uint animationSpeed = 250;

        double screenWidth = this.Width;
        if (double.IsNaN(screenWidth) || screenWidth == 0)
        {
            screenWidth = 400; // Fallback value
        }

        // Ensure new image starts off-screen left
        newImage.TranslationX = -screenWidth;
        newImage.IsVisible = true;

        // Animate old image out
        await oldImage.TranslateTo(screenWidth, 0, animationSpeed, Easing.Linear);
        oldImage.IsVisible = false;
        oldImage.TranslationX = 0; // Reset position

        // Animate new image in
        await newImage.TranslateTo(0, 0, animationSpeed, Easing.Linear);
    }

    private Image DetermineNewVisibleImage()
    {
        return H17 ? H17HardTotalsTable : S17HardTotalsTable;
    }

    /// <summary>
    /// Returns the currently visible image
    /// </summary>
    /// <returns>The currently visible Image</returns>
    private Image GetCurrentVisibleImage()
    {
        if (H17HardTotalsTable.IsVisible) return H17HardTotalsTable;
        if (S17HardTotalsTable.IsVisible) return S17HardTotalsTable;
        if (H17SoftTotalsTable.IsVisible) return H17SoftTotalsTable;
        if (S17SoftTotalsTable.IsVisible) return S17SoftTotalsTable;
        if (H17PairsTableDas.IsVisible) return H17PairsTableDas;
        if (S17PairsTableDas.IsVisible) return S17PairsTableDas;
        if (H17PairsTableNoDas.IsVisible) return H17PairsTableNoDas;
        if (S17PairsTableNoDas.IsVisible) return S17PairsTableNoDas;

        return H17HardTotalsTable; // Default to H17 Hard Totals if no table is active
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
            H17 = (sender == H17Radio);
            Image newImage = H17 ? H17HardTotalsTable : S17HardTotalsTable;
            SlideToNewImage(GetCurrentVisibleImage(), newImage);
        }
    }

    private void DoubleAfterSplitToggled(object sender, ToggledEventArgs e)
    {
        DoubleAfterSplit = e.Value;

        // Check if the currently visible image is a Pairs table, and switch to the correct one
        if (H17PairsTableDas.IsVisible || H17PairsTableNoDas.IsVisible ||
            S17PairsTableDas.IsVisible || S17PairsTableNoDas.IsVisible)
        {
            Image newImage = DoubleAfterSplit
                ? (H17 ? H17PairsTableDas : S17PairsTableDas)
                : (H17 ? H17PairsTableNoDas : S17PairsTableNoDas);

            SlideToNewImage(GetCurrentVisibleImage(), newImage);
        }
    }
}