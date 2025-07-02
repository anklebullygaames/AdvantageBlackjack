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
        MainBack.SetValue(Grid.ZIndexProperty, 1);

        H17Radio.IsChecked = GlobalSettings.H17;
        S17Radio.IsChecked = !GlobalSettings.H17;
        DoubleDeckRadio.IsChecked = GlobalSettings.DoubleDeck;
        FourDeckRadio.IsChecked = !GlobalSettings.DoubleDeck;
        DoubleAfterSplitSwitch.IsToggled = GlobalSettings.DoubleAfterSplit;
        SurrenderSwitch.IsToggled = GlobalSettings.Surrender;
        DoubleAfterSplitSwitch.IsToggled = GlobalSettings.DoubleAfterSplit;

        if (GlobalSettings.DoubleDeck)
        {
            if (GlobalSettings.H17)
            {
                if (GlobalSettings.Surrender)
                {
                    TwoDeckH17Hardsurrender.IsVisible = true;
                }
                else
                {
                    TwoDeckH17Hardnosurrender.IsVisible = true;
                }
            }
            else
            {
                if (GlobalSettings.Surrender)
                {
                    TwoDeckS17Hardsurrender.IsVisible = true;
                }
                else
                {
                    TwoDeckS17Hardnosurrender.IsVisible = true;
                }
            }
        }
        else
        {
            if (GlobalSettings.H17)
            {
                if (GlobalSettings.Surrender)
                {
                    FourDeckH17Hardsurrender.IsVisible = true;
                }
                else
                {
                    FourDeckH17Hardnosurrender.IsVisible = true;
                }
            }
            else
            {
                if (GlobalSettings.Surrender)
                {
                    FourDeckS17Hardsurrender.IsVisible = true;
                }
                else
                {
                    FourDeckS17Hardnosurrender.IsVisible = true;
                }
            }
        }
    }

    /// <summary>
    /// Whether the user is in the options menu
    /// </summary>
    private bool _isInSettingsMenu = false;

    /// <summary>
    /// BasicStrategyBtn clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void SoftHandsClicked(object sender, EventArgs e)
    {
        Border newBorder = GetCurrentSoftTotalsBorder();
        if (_isInSettingsMenu)
            FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
        else
            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    /// <summary>
    /// Pairs clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void PairsClicked(object sender, EventArgs e)
    {
        Border newBorder = GetCurrentPairsBorder();
        if (_isInSettingsMenu)
            FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
        else
            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    /// <summary>
    /// Hard totals clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void HardTotalsClicked(object sender, EventArgs e)
    {
        Border newBorder = GetCurrentHardTotalsBorder();
        if (_isInSettingsMenu)
            FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
        else
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
    /// Fades to a new table
    /// </summary>
    /// <param name="oldBorder">oldBorder</param>
    /// <param name="newBorder">newBorder</param>
    private async void FadeToNewImage(Border oldBorder, Border newBorder)
    {
        if (oldBorder == newBorder || !oldBorder.IsVisible)
            return;

        const uint animationSpeed = 250;

        newBorder.Opacity = 0;
        newBorder.IsVisible = true;

        await oldBorder.FadeTo(0, animationSpeed);

        oldBorder.IsVisible = false;
        oldBorder.Opacity = 1;

        await newBorder.FadeTo(1, animationSpeed);
    }

    private Border GetCurrentHardTotalsBorder()
    {
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17 && GlobalSettings.Surrender)
            return TwoDeckH17Hardsurrender;
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17 && !GlobalSettings.Surrender)
            return TwoDeckH17Hardnosurrender;
        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17 && GlobalSettings.Surrender)
            return TwoDeckS17Hardsurrender;
        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17 && !GlobalSettings.Surrender)
            return TwoDeckS17Hardnosurrender;
        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17 && GlobalSettings.Surrender)
            return FourDeckH17Hardsurrender;
        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17 && !GlobalSettings.Surrender)
            return FourDeckH17Hardnosurrender;
        if (!GlobalSettings.DoubleDeck && !GlobalSettings.H17 && GlobalSettings.Surrender)
            return FourDeckS17Hardsurrender;
        return FourDeckS17Hardnosurrender;
    }

    private Border GetCurrentSoftTotalsBorder()
    {
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17)
            return TwoDeckH17Soft;
        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17)
            return TwoDeckS17Soft;
        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17)
            return FourDeckH17Soft;
        return FourDeckS17Soft;
    }

    private Border GetCurrentPairsBorder()
    {
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit && GlobalSettings.Surrender)
            return TwoDeckH17PairsDassurrender;
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit && !GlobalSettings.Surrender)
            return TwoDeckH17PairsDasnosurrender;
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17 && !GlobalSettings.DoubleAfterSplit && GlobalSettings.Surrender)
            return TwoDeckH17PairsNoDassurrender;
        if (GlobalSettings.DoubleDeck && GlobalSettings.H17 && !GlobalSettings.DoubleAfterSplit && !GlobalSettings.Surrender)
            return TwoDeckH17PairsNoDasnosurrender;

        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit && GlobalSettings.Surrender)
            return TwoDeckS17PairsDassurrender;
        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit && !GlobalSettings.Surrender)
            return TwoDeckS17PairsDasnosurrender;
        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17 && !GlobalSettings.DoubleAfterSplit && GlobalSettings.Surrender)
            return TwoDeckS17PairsNoDassurrender;
        if (GlobalSettings.DoubleDeck && !GlobalSettings.H17 && !GlobalSettings.DoubleAfterSplit && !GlobalSettings.Surrender)
            return TwoDeckS17PairsNoDasnosurrender;

        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit && GlobalSettings.Surrender)
            return FourDeckH17PairsDassurrender;
        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit && !GlobalSettings.Surrender)
            return FourDeckH17PairsDasnosurrender;
        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17 && !GlobalSettings.DoubleAfterSplit && GlobalSettings.Surrender)
            return FourDeckH17PairsNoDassurrender;
        if (!GlobalSettings.DoubleDeck && GlobalSettings.H17 && !GlobalSettings.DoubleAfterSplit && !GlobalSettings.Surrender)
            return FourDeckH17PairsNoDasnosurrender;

        if (!GlobalSettings.DoubleDeck && !GlobalSettings.H17 && GlobalSettings.DoubleAfterSplit)
            return FourDeckS17PairsDas;
        return FourDeckS17PairsNoDas;
    }

    /// <summary>
    /// Returns the currently visible border
    /// </summary>
    /// <returns>Border</returns>
    private Border GetCurrentVisibleBorder()
    {
        // Hard totals
        if (TwoDeckH17Hardnosurrender.IsVisible) return TwoDeckH17Hardnosurrender;
        if (TwoDeckH17Hardsurrender.IsVisible) return TwoDeckH17Hardsurrender;
        if (TwoDeckS17Hardnosurrender.IsVisible) return TwoDeckS17Hardnosurrender;
        if (TwoDeckS17Hardsurrender.IsVisible) return TwoDeckS17Hardsurrender;
        if (FourDeckH17Hardnosurrender.IsVisible) return FourDeckH17Hardnosurrender;
        if (FourDeckH17Hardsurrender.IsVisible) return FourDeckH17Hardsurrender;
        if (FourDeckS17Hardnosurrender.IsVisible) return FourDeckS17Hardnosurrender;
        if (FourDeckS17Hardsurrender.IsVisible) return FourDeckS17Hardsurrender;

        // Soft totals
        if (TwoDeckH17Soft.IsVisible) return TwoDeckH17Soft;
        if (TwoDeckS17Soft.IsVisible) return TwoDeckS17Soft;
        if (FourDeckH17Soft.IsVisible) return FourDeckH17Soft;
        if (FourDeckS17Soft.IsVisible) return FourDeckS17Soft;

        // Pairs — 2 deck
        if (TwoDeckH17PairsDasnosurrender.IsVisible) return TwoDeckH17PairsDasnosurrender;
        if (TwoDeckH17PairsDassurrender.IsVisible) return TwoDeckH17PairsDassurrender;
        if (TwoDeckH17PairsNoDasnosurrender.IsVisible) return TwoDeckH17PairsNoDasnosurrender;
        if (TwoDeckH17PairsNoDassurrender.IsVisible) return TwoDeckH17PairsNoDassurrender;

        if (TwoDeckS17PairsDasnosurrender.IsVisible) return TwoDeckS17PairsDasnosurrender;
        if (TwoDeckS17PairsDassurrender.IsVisible) return TwoDeckS17PairsDassurrender;
        if (TwoDeckS17PairsNoDasnosurrender.IsVisible) return TwoDeckS17PairsNoDasnosurrender;
        if (TwoDeckS17PairsNoDassurrender.IsVisible) return TwoDeckS17PairsNoDassurrender;

        // Pairs — 4 deck
        if (FourDeckH17PairsDasnosurrender.IsVisible) return FourDeckH17PairsDasnosurrender;
        if (FourDeckH17PairsDassurrender.IsVisible) return FourDeckH17PairsDassurrender;
        if (FourDeckH17PairsNoDasnosurrender.IsVisible) return FourDeckH17PairsNoDasnosurrender;
        if (FourDeckH17PairsNoDassurrender.IsVisible) return FourDeckH17PairsNoDassurrender;

        if (FourDeckS17PairsDas.IsVisible) return FourDeckS17PairsDas;
        if (FourDeckS17PairsNoDas.IsVisible) return FourDeckS17PairsNoDas;

        // Default fallback (to avoid null return)
        return FourDeckH17Hardnosurrender;
    }

    /// <summary>
    /// Settings clicked event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    async void SettingsClicked(object sender, EventArgs e)
    {
        _isInSettingsMenu = true;
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
        _isInSettingsMenu = false;

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
            GlobalSettings.H17 = (sender == H17Radio);

            Border newBorder = GetCurrentVisibleBorder();

            if (newBorder.Equals(GetCurrentHardTotalsBorder()))
                newBorder = GetCurrentHardTotalsBorder();
            else if (newBorder.Equals(GetCurrentSoftTotalsBorder()))
                newBorder = GetCurrentSoftTotalsBorder();
            else
                newBorder = GetCurrentPairsBorder();

            if (_isInSettingsMenu)
                FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
            else
                SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
        }
    }

    /// <summary>
    /// Deck rule changed event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DeckRuleToggled(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            GlobalSettings.DoubleDeck = (sender == DoubleDeckRadio);

            Border newBorder = GetCurrentVisibleBorder();

            if (newBorder.Equals(GetCurrentHardTotalsBorder()))
                newBorder = GetCurrentHardTotalsBorder();
            else if (newBorder.Equals(GetCurrentSoftTotalsBorder()))
                newBorder = GetCurrentSoftTotalsBorder();
            else
                newBorder = GetCurrentPairsBorder();

            if (_isInSettingsMenu)
                FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
            else
                SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
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

        Border newBorder = GetCurrentVisibleBorder();

        if (newBorder.Equals(GetCurrentHardTotalsBorder()))
            newBorder = GetCurrentHardTotalsBorder();
        else if (newBorder.Equals(GetCurrentSoftTotalsBorder()))
            newBorder = GetCurrentSoftTotalsBorder();
        else
            newBorder = GetCurrentPairsBorder();

        if (_isInSettingsMenu)
            FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
        else
            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
    }

    /// <summary>
    /// DAS switched event handler
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">e</param>
    private void DoubleAfterSplitToggled(object sender, ToggledEventArgs e)
    {
        GlobalSettings.DoubleAfterSplit = e.Value;

        Border newBorder = GetCurrentPairsBorder();
        if (_isInSettingsMenu)
            FadeToNewImage(GetCurrentVisibleBorder(), newBorder);
        else
            SlideToNewImage(GetCurrentVisibleBorder(), newBorder);
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