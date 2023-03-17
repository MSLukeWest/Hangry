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
}
