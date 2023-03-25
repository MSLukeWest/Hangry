using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Hangry.Lib;

namespace Hangry.ViewModel;

public partial class RecipeViewModel : ObservableObject
{
    [ObservableProperty]
    Recipe current;

    internal IList<Recipe> Matches { get; private set; } = null;

    readonly IConnectivity connectivity;
    readonly FoodData foodData;

    public RecipeViewModel(IConnectivity connectivity, FoodData foodData)
    {
        this.connectivity = connectivity;
        this.foodData = foodData;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            Debug.WriteLine("Oh no, no internet...");
        }
    }

    public void SetMatches(IList<Recipe> matches)
    {
        this.Matches = matches;
        this.Current = this.Matches.FirstOrDefault();
    }
}
