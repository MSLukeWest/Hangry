using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hangry.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;
    FoodData foodData;

    public MainViewModel(IConnectivity connectivity, FoodData foodData)
    {
        this.connectivity = connectivity;
        this.foodData = foodData;
    }

    [RelayCommand]
    async Task OpenPantry()
    {
        await Shell.Current.GoToAsync($"{nameof(PantryPage)}");
    }

    [RelayCommand]
    async Task Suggest()
    {
        
    }
}
