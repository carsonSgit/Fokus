namespace Fokus
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Allows for different "pages"
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(TaskPage), typeof(TaskPage));
        }
    }
}
