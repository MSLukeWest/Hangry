using Hangry.Lib;

namespace Hangry;

public class FoodData
{
    public IngredientsList Ingredients { get; private set;}

    public RecipeList Recipes { get; private set; }

    public FoodData()
    {
        this.Ingredients = IngredientsList.ReadFromFile("Data\\ingredients.json", Common.FileReader);
        this.Recipes = RecipeList.ReadFromFile("Data\\recipes.json", Common.FileReader);
    }
}
