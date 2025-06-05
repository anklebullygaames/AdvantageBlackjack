using AdvantageBlackjack.Pages;

namespace AdvantageBlackjack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("StrategyTables", typeof(StrategyTables));
            Routing.RegisterRoute("BasicStrategy", typeof(BasicStrategy));
            Routing.RegisterRoute("PairsAndSoftHands", typeof(PairsAndSoftHands));
            Routing.RegisterRoute("DeckMode", typeof(DeckMode));
            Routing.RegisterRoute("DealMode", typeof(DealMode));
            Routing.RegisterRoute("RunningCountPrompt", typeof(RunningCountPrompt));
            Routing.RegisterRoute("SignInPage", typeof(SignInPage));
            Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
            Routing.RegisterRoute("About", typeof(About));
            Routing.RegisterRoute("Stats", typeof(Stats));
            Routing.RegisterRoute("AI", typeof(AI));
        }
    }
}

