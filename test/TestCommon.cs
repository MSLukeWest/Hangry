namespace Hangry.Test;

internal static class TestCommon
{
    internal const string RecipesJsonFilePath = @"Data\Recipes.json";
    internal const string IngredientsJsonFilePath = @"Data\Ingredients.json";
    internal const string PantryJsonFilePath = @"Data\Pantry.json";

    internal static Func<string, Stream> TestFileReader = ((path) =>
    {
        return File.OpenRead(path);
    });

    internal static string CreateTempJsonFileWithText(string text)
    {
        var filePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".json";
        File.WriteAllText(filePath, text);
        return filePath;
    }
}
