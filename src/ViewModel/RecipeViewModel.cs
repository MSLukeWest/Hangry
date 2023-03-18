using CommunityToolkit.Mvvm.ComponentModel;
using Hangry.Lib;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Hangry.ViewModel;

public partial class RecipeViewModel : ObservableObject
{
    [ObservableProperty]
    Recipe current;

    readonly IConnectivity connectivity;
    readonly FoodData foodData;

    public RecipeViewModel(IConnectivity connectivity, FoodData foodData)
    {
        this.connectivity = connectivity;
        this.foodData = foodData;

        this.current = this.foodData.Recipes.Recipes[2];

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            Debug.WriteLine("Oh no, no internet...");
        }
    }
}
