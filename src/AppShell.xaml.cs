namespace Hangry;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(PantryPage), typeof(PantryPage));
    }
}
