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
        FlipToNewImage(GetCurrentVisibleImage(), SoftTotalsTable);
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void PairsClicked(object sender, EventArgs e)
    {
        FlipToNewImage(GetCurrentVisibleImage(), PairsTable);
    }

    /// <summary>
    /// BasicStrategyBtn event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HardTotalsClicked(object sender, EventArgs e)
    {
        FlipToNewImage(GetCurrentVisibleImage(), HardTotalsTable);
    }

    /// <summary>
    /// Handles the animation and visibility switching
    /// </summary>
    /// <param name="oldImage">The currently visible image</param>
    /// <param name="newImage">The new image to show</param>
    private async void FlipToNewImage(Image oldImage, Image newImage)
    {
        if (oldImage == newImage || !oldImage.IsVisible)
            return;

        // Perspective effect (only works on some platforms)
        oldImage.AnchorX = 0.5;
        oldImage.AnchorY = 0.5;
        newImage.AnchorX = 0.5;
        newImage.AnchorY = 0.5;

        // Step 1: Rotate the current image to 90 degrees while fading it out
        oldImage.RotateYTo(180, 250, Easing.Linear);
        oldImage.Opacity = 0;
        oldImage.HeightRequest = 200;
        oldImage.WidthRequest = 240;
        oldImage.IsVisible = false;

        // Step 2: Reset the new image's rotation to 90 degrees (so it starts from the side)
        newImage.HeightRequest = 200;
        newImage.WidthRequest = 240;
        newImage.RotationY = 180;
        newImage.Opacity = 0;
        newImage.IsVisible = true;

        // Step 3: Rotate the new image back to 0 degrees while fading it in
        newImage.RotateYTo(360, 250, Easing.Linear);
        newImage.Opacity = 1;
        newImage.HeightRequest = 300;
        newImage.WidthRequest = 360;
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