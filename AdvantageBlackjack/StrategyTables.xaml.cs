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
}