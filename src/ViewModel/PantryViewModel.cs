using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Hangry.Lib;

namespace Hangry.ViewModel;

public partial class PantryViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Ingredient> items;

    public PantryViewModel()
    {
        this.Items = new ObservableCollection<Ingredient>();
        var pantryIngredients = IngredientsList.ReadFromFile("Data\\pantry.json", Common.FileReader);
        foreach (var ingredient in pantryIngredients.Ingredients)
        {
            this.Items.Add(ingredient);
        }
    }

    [ObservableProperty]
    string searchText;

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(SearchText))
            return;

        Items.Insert(0, new Ingredient(SearchText));

        SearchText = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        var toDelete = Items.Where((i) => i.Name.Equals(s, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        if (toDelete != null)
        {
            Items.Remove(toDelete);
        }
    }

    [RelayCommand]
    private static async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    // TODO: This isn't being used, remove
    public void RaiseSelectionChanged()
    {
        this.OnPropertyChanged("Items");
    }
}
