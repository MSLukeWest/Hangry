using CommunityToolkit.Mvvm.ComponentModel;
using Hangry.Lib;
using Hangry.ViewModel;
using System.Collections.ObjectModel;

namespace Hangry;

public partial class PantryPage : ContentPage
{
	public PantryPage(PantryViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;
    }

    void OnItemDeleted(object sender, EventArgs args)
    {
        var f = sender.GetType();
    }

    // TODO: Remove
    private void PantryIngredientsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //var f = sender.GetType();
        if (e.CurrentSelection.Count > 0)
        {
            var selectedIngredient = e.CurrentSelection[0] as Ingredient;
            selectedIngredient.Selected = true;
            //var vm = this.BindingContext as PantryViewModel;
            //vm.RaiseSelectionChanged();
            //var collectionView = sender as CollectionView;
            //vm.Items.CollectionChanged();
        }

        if (e.PreviousSelection.Count > 0)
        {
            var deSelectedIngredient = e.PreviousSelection[0] as Ingredient;
            deSelectedIngredient.Selected = false;
        }
    }
}