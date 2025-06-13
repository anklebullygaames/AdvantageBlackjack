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
            Routing.RegisterRoute("About", typeof(About));
            Routing.RegisterRoute("Stats", typeof(Stats));
            Routing.RegisterRoute("Store", typeof(Store));
            Routing.RegisterRoute("RunningCountPrompt", typeof(RunningCountPrompt));
            Routing.RegisterRoute("AI", typeof(AI));
        }
    }
}

