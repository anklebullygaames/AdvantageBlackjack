using AdvantageBlackjack.Pages;

namespace AdvantageBlackjack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("StrategyTables", typeof(StrategyTables));
            Routing.RegisterRoute("BasicStrategy", typeof(BasicStrategy));
            Routing.RegisterRoute("PairsAndSoftHands", typeof(PairsAndSoftHands));
            Routing.RegisterRoute("DeckMode", typeof(DeckMode));
            Routing.RegisterRoute("DealMode", typeof(DealMode));
            Routing.RegisterRoute("RunningCountPrompt", typeof(RunningCountPrompt));
        }
    }
}
