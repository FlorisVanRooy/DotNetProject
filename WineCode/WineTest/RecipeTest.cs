using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineTest
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void Recipe_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var recipe = new Recipe();

            // Act & Assert
            Assert.AreEqual(0, recipe.RecipeId); // Default value for int is 0
            Assert.AreEqual(string.Empty, recipe.Name); // Default value for string is empty
            Assert.AreEqual(string.Empty, recipe.Description); // Default value for string is empty
            Assert.AreEqual(string.Empty, recipe.Link); // Default value for string is empty
            Assert.AreEqual(string.Empty, recipe.Image); // Default value for string is empty
        }

        [TestMethod]
        public void Recipe_ShouldAllowSettingRecipeId()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedRecipeId = 1;

            // Act
            recipe.RecipeId = expectedRecipeId;

            // Assert
            Assert.AreEqual(expectedRecipeId, recipe.RecipeId);
        }

        [TestMethod]
        public void Recipe_ShouldAllowSettingName()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedName = "Pasta Primavera";

            // Act
            recipe.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, recipe.Name);
        }

        [TestMethod]
        public void Recipe_ShouldAllowSettingDescription()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedDescription = "A delightful vegetable pasta dish.";

            // Act
            recipe.Description = expectedDescription;

            // Assert
            Assert.AreEqual(expectedDescription, recipe.Description);
        }

        [TestMethod]
        public void Recipe_ShouldAllowSettingLink()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedLink = "http://example.com/pasta-primavera";

            // Act
            recipe.Link = expectedLink;

            // Assert
            Assert.AreEqual(expectedLink, recipe.Link);
        }

        [TestMethod]
        public void Recipe_ShouldAllowSettingImage()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedImage = "http://example.com/images/pasta-primavera.jpg";

            // Act
            recipe.Image = expectedImage;

            // Assert
            Assert.AreEqual(expectedImage, recipe.Image);
        }

        [TestMethod]
        public void Recipe_ShouldAllowSettingEmptyName()
        {
            // Arrange
            var recipe = new Recipe();
            var expectedName = string.Empty;

            // Act
            recipe.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, recipe.Name);
        }
    }
}
