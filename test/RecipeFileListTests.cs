using Hangry.Lib;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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

            Assert.AreEqual(4999, recipeList.Recipes.Count);
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

            var ingredientsList = IngredientsList.ReadFromFile(TestCommon.PantryJsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(ingredientsList);

            var matches = recipeList.FindIngredientsMatches(ingredientsList.Ingredients);
            Assert.IsNotNull(matches);
            Assert.AreEqual(3, matches.Count);
        }

        [TestMethod]
        public void ParseRecipesTimeData()
        {
            var recipeList = RecipeList.ReadFromFile(TestCommon.RecipesJsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(recipeList);

            recipeList.ParseTimeData();
            int failedTimeCount = 0;
            int partialFailedTimeCount = 0;
            foreach (var recipe in recipeList.Recipes)
            {
                bool failed1 = recipe.Prep == default;
                bool failed2 = recipe.Cook == default;
                bool failed3 = recipe.Ready == default;

                if (failed1 && failed2 && failed3)
                {
                    failedTimeCount++;
                }
                else if (failed1 || failed2 || failed3)
                {
                    partialFailedTimeCount++;
                }
            }

            Assert.AreEqual(0, partialFailedTimeCount);
            Assert.AreEqual(0, failedTimeCount);
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
