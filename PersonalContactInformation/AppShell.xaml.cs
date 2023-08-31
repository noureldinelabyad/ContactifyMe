
using PersonalContactInformation.Views;


namespace PersonalContactInformation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddContact), typeof(AddContact));
            Routing.RegisterRoute(nameof(EditContact), typeof(EditContact));
        }
    }
}