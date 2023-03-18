using Hangry.ViewModel;

namespace Hangry;

public partial class RecipePage : ContentPage
{
	public RecipePage(RecipeViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}