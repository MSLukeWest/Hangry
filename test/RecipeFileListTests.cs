using Hangry.Lib;

namespace Hangry.Test
{
    [TestClass]
    public class RecipeFileListTests
    {
        [TestMethod]
        public void ReadRecipesList()
        {
            var recipeList = RecipeList.ReadFromFile(TestCommon.RecipesJsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(recipeList);

            Assert.AreEqual(5000, recipeList.Recipes.Count);
            Assert.AreEqual("Homemade Bacon", recipeList.Recipes[0].name);
        }

        [TestMethod]
        public void RecipesList_FindIngredientsMatches_Simple()
        {
            var tempRecipesFilePath = TestCommon.CreateTempJsonFileWithText(TestRecipe);
            var tempIngredientsFilePath = TestCommon.CreateTempJsonFileWithText(TestIngredients);
            
            var recipeList = RecipeList.ReadFromFile(tempRecipesFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(recipeList);

            var ingredientsList = IngredientsList.ReadFromFile(tempIngredientsFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(ingredientsList);

            var matches = recipeList.FindIngredientsMatches(ingredientsList.Ingredients);
            Assert.IsNotNull(matches);
            Assert.AreEqual(1, matches.Count);
        }

        [TestMethod]
        public void RecipesList_FindIngredientsMatches_Complex()
        {
            var recipeList = RecipeList.ReadFromFile(TestCommon.RecipesJsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(recipeList);

            var ingredientsList = IngredientsList.ReadFromFile(TestCommon.IngredientsJsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(ingredientsList);

            var matches = recipeList.FindIngredientsMatches(ingredientsList.Ingredients);
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Count > 0);
        }

            [TestMethod]
        public void ReadRecipesList_NullFile()
        {
            Assert.ThrowsException<ArgumentNullException>(() => RecipeList.ReadFromFile(null, TestCommon.TestFileReader));
        }

        private const string TestRecipe = @"{""Recipes"": [ { ""id"": 222388, ""name"": ""Homemade Bacon"", ""avg_rating"": ""5.00"", ""num_ratings"": 3, ""image_url"": ""https://images.media-allrecipes.com/userphotos/720x405/876328.jpg"", ""ingredients"": [ ""foo"", ""bar"" ], ""cooking_directions"": [ ""Blah"" ] } ] }";
        private const string TestIngredients = @"{""IngredientNames"": [ ""foo"", ""bar"", ""banana"" ] }";
    }
}
