using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using Hangry.Lib;

namespace Hangry.ViewModel;

public partial class RecipeViewModel : ObservableObject
{
    [ObservableProperty]
    Recipe current;

    [ObservableProperty]
    bool enablePrev;

    [ObservableProperty]
    bool enableNext;

    private IList<Recipe> Matches { get; set; } = null;
    private int CurrentIndex = 0;

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
        if (matches is not null && matches.Count > 0)
        {
            this.Matches = matches;
            this.Current = this.Matches.FirstOrDefault();
            this.EnableNext = this.Matches.Count > 1;
            this.EnablePrev = false;
            this.CurrentIndex = 0;
        }
    }

    internal void Previous()
    {
        this.CurrentIndex--;
        this.EnableNext = true;
        this.EnablePrev = this.CurrentIndex > 0;
        this.UpdateCurrent();
    }

    internal void Next()
    {
        this.CurrentIndex++;
        this.EnableNext = this.CurrentIndex != (this.Matches.Count - 1);
        this.EnablePrev = true;
        this.UpdateCurrent();
    }

    private void UpdateCurrent()
    {
        this.Current = this.Matches[CurrentIndex];
    }
}
