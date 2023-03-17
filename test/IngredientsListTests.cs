using Hangry.Lib;

namespace Hangry.Test
{
    [TestClass]
    public class IngredientsListTests
    {
        [TestMethod]
        public void ReadIngredientsList()
        {
            const string jsonFilePath = @"Data\Ingredients.json";
            var ingredientsList = IngredientsList.ReadFromFile(jsonFilePath, TestCommon.TestFileReader);
            Assert.IsNotNull(ingredientsList);
            Assert.IsNotNull(ingredientsList.IngredientNames);

            Assert.AreEqual(8566, ingredientsList.Ingredients.Count);
            Assert.AreEqual("celery salt (optional)", ingredientsList.Ingredients[0].Name);
        }

        [TestMethod]
        public void IngredientsList_NullFile()
        {
            Assert.ThrowsException<ArgumentNullException>(() => IngredientsList.ReadFromFile(null, TestCommon.TestFileReader));
        }
    }
}