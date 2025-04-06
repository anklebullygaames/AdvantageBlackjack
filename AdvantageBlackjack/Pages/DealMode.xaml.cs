namespace AdvantageBlackjack;
using AdvantageBlackjack.Blackjack;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

/// <summary>
/// Deal Mode
/// </summary>
public partial class DealMode : ContentPage 
{

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