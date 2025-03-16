namespace AdvantageBlackjack;

public partial class StrategyTables : ContentPage
{
	public StrategyTables()
	{
		InitializeComponent();
        MenuGrid.IsVisible = false;
        H17Switch.IsToggled = H17;
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
        SlideToNewImage(GetCurrentVisibleImage(), SoftTotalsTable);
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void PairsClicked(object sender, EventArgs e)
    {
        SlideToNewImage(GetCurrentVisibleImage(), PairsTable);
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HardTotalsClicked(object sender, EventArgs e)
    {
        SlideToNewImage(GetCurrentVisibleImage(), HardTotalsTable);
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

        const uint animationSpeed = 250; // Adjust animation speed as needed

        double screenWidth = this.Width; // Get screen width dynamically

        if (double.IsNaN(screenWidth) || screenWidth == 0)
        {
            screenWidth = 400; // Fallback value if not set
        }

        // Ensure the new image starts off-screen to the left
        newImage.TranslationX = -screenWidth;
        newImage.IsVisible = true;

        // Animate old image sliding out to the right
        await oldImage.TranslateTo(screenWidth, 0, animationSpeed, Easing.Linear);
        oldImage.IsVisible = false; // Hide old image after animation
        oldImage.TranslationX = 0; // Reset position

        // Animate new image sliding in from the left
        await newImage.TranslateTo(0, 0, animationSpeed, Easing.Linear);
    }

    /// <summary>
    /// Returns the currently visible image
    /// </summary>
    /// <returns>The currently visible Image</returns>
    private Image GetCurrentVisibleImage()
    {
        if (HardTotalsTable.IsVisible) return HardTotalsTable;
        if (SoftTotalsTable.IsVisible) return SoftTotalsTable;
        return PairsTable;
    }

    async void SettingsClicked(object sender, EventArgs e)
    {
        MenuGrid.IsVisible = true; // Show the menu before animation starts
        _ = MainContentGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, 800u, Easing.CubicIn);
        await MainContentGrid.ScaleTo(0.8, 800u);
        _ = MainContentGrid.FadeTo(0.8, 800u);
    }

    async void GridAreaClicked(object sender, EventArgs e)
    {
        _ = MainContentGrid.FadeTo(1, 800u);
        _ = MainContentGrid.ScaleTo(1, 800u);
        await MainContentGrid.TranslateTo(0, 0, 800u, Easing.CubicIn);
        MenuGrid.IsVisible = false;
    }

    private void H17Toggled(object sender, ToggledEventArgs e)
    {
        H17 = e.Value;
    }

    private void DoubleAfterSplitToggled(object sender, ToggledEventArgs e)
    {
        DoubleAfterSplit = e.Value;
    }
}