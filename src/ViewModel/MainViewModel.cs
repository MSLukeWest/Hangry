using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Hangry.ViewModel;

public partial class MainViewModel : ObservableObject
{
    readonly IConnectivity connectivity;
    readonly FoodData foodData;
    readonly PantryViewModel pantryViewModel;
    readonly RecipeViewModel recipeViewModel;

    public MainViewModel(IConnectivity connectivity, FoodData foodData, PantryViewModel pantryViewModel, RecipeViewModel recipeViewModel)
    {
        this.connectivity = connectivity;
        this.foodData = foodData;
        this.pantryViewModel = pantryViewModel;
        this.recipeViewModel = recipeViewModel;
    }

    [RelayCommand]
    async Task OpenPantry()
    {
        await Shell.Current.GoToAsync($"{nameof(PantryPage)}");
    }

    [RelayCommand]
    async Task Suggest()
    {
        var suggestions = this.foodData.GetMatches(this.pantryViewModel.Items);
        this.recipeViewModel.SetMatches(suggestions);

        await Shell.Current.GoToAsync($"{nameof(RecipePage)}");
    }
}
