namespace Hangry.Lib;

public class IngredientsList
{
    // Used for serialization
    public IList<string> IngredientNames { get; set; }

    public List<Ingredient> Ingredients
    {
        get
        {
            if (this.ingredients is null && this.IngredientNames is not null)
            {
                this.ingredients = this.IngredientNames.Select((name) => new Ingredient(name)).ToList();
            }

            return this.ingredients;
        }
    }

    public List<Ingredient> ingredients = null;

    private IngredientsList() { }

    public static IngredientsList ReadFromFile(string ingredientsJsonFilePath,  Func<string, Stream> fileReader)
    {
        if (string.IsNullOrEmpty(ingredientsJsonFilePath))
        {
            throw new ArgumentNullException(nameof(ingredientsJsonFilePath));
        }

        return Common.DeserializeFromJSon<IngredientsList>(ingredientsJsonFilePath, fileReader);

    }
}