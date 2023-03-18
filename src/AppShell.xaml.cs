namespace Hangry;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(PantryPage), typeof(PantryPage));
        Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
    }
}
