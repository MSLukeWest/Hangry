namespace Hangry.Lib;

public class RecipeList
{
    public IList<Recipe> Recipes { get; set; }

    private RecipeList() { }

    public static RecipeList ReadFromFile(string recipesJsonFilePath, Func<string, Stream> fileReader)
    {
        if (string.IsNullOrEmpty(recipesJsonFilePath))
        {
            throw new ArgumentNullException(nameof(recipesJsonFilePath));
        }

        return Common.DeserializeFromJSon<RecipeList>(recipesJsonFilePath, fileReader);
    }

    public void ParseTimeData()
    {
        foreach (var recipe in this.Recipes)
        {
            recipe.ParseTimeData();
        }
    }

    public List<Recipe> FindIngredientsMatches(IList<Ingredient> ingredients)
    {
        var ingredientNames = ingredients.Select(x => x.Name);
        return this.Recipes.Where(r => r.ingredients.All(i => ingredientNames.Contains(i))).ToList();
    }
}
