namespace AdvantageBlackjack
{
    public partial class DeckMode : ContentPage
    {
        public DeckMode()
        {
            InitializeComponent();
        }

        /// <summary>
        /// back clicked event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void BackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

