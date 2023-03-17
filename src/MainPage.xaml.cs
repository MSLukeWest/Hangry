using Hangry.ViewModel;

namespace Hangry;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        this.BindingContext = vm;
    }

    // TODO: Change this to a Command?
    void OnSearchBarButtonPressed(object sender, EventArgs args)
    {
        SearchBar searchBar = (SearchBar)sender;
        string searchText = searchBar.Text;
    }
}
