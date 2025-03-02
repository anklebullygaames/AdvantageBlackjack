namespace AdvantageBlackjack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("StrategyTables", typeof(StrategyTables));
        }
    }
}
