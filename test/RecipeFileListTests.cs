using Hangry.Lib;

namespace Hangry.Test
{
    [TestClass]
    public class RecipeFileListTests
    {
        [TestMethod]
        public void ReadRecipesList()
        {
            const string jsonFilePath = @"Data\Recipes.json";
            var recipeList = RecipeList.ReadFromFile(jsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(recipeList);

            Assert.AreEqual(5000, recipeList.Recipes.Count);
            Assert.AreEqual("Homemade Bacon", recipeList.Recipes[0].name);
        }

        [TestMethod]
        public void ReadRecipesList_NullFile()
        {
            Assert.ThrowsException<ArgumentNullException>(() => RecipeList.ReadFromFile(null, TestCommon.TestFileReader));
        }
    }
}
