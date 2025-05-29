using MSSA_Project.Performance;

namespace MSSA_Project
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("stats", typeof(StatsPage));
        }
    }
}
