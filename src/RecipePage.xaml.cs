using Hangry.ViewModel;

namespace Hangry;

public partial class RecipePage : ContentPage
{
    private RecipeViewModel ViewModel => this.BindingContext as RecipeViewModel;

    public RecipePage(RecipeViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}

    private void NextButton_Clicked(object sender, EventArgs e) => this.ViewModel.Next();

    private void PrevButton_Clicked(object sender, EventArgs e) => this.ViewModel.Previous();
}