using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineTest
{
    [TestClass]
    public class WineTest
    {
        [TestMethod]
        public void Wine_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var wine = new Wine();

            // Act & Assert
            Assert.AreEqual(0, wine.WineID); // Default value for int is 0
            Assert.AreEqual(string.Empty, wine.Name); // Default value for string is empty
            Assert.AreEqual(string.Empty, wine.Description); // Default value for string is empty
            Assert.AreEqual(string.Empty, wine.TasteProfile); // Default value for string is empty
            Assert.AreEqual(string.Empty, wine.Image); // Default value for string is empty
            Assert.AreEqual(string.Empty, wine.Link); // Default value for string is empty
            Assert.AreEqual(string.Empty, wine.Price); // Default value for string is empty
            Assert.IsNull(wine.Country); // Default value for Country should be null
            Assert.IsNull(wine.Categories); // Default value for ICollection<Category> should be null
            Assert.IsNull(wine.Kind); // Default value for Kind should be null
            Assert.IsNull(wine.Recipes); // Default value for ICollection<Recipe> should be null
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingWineID()
        {
            // Arrange
            var wine = new Wine();
            var expectedWineID = 1;

            // Act
            wine.WineID = expectedWineID;

            // Assert
            Assert.AreEqual(expectedWineID, wine.WineID);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingName()
        {
            // Arrange
            var wine = new Wine();
            var expectedName = "Chardonnay";

            // Act
            wine.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, wine.Name);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingDescription()
        {
            // Arrange
            var wine = new Wine();
            var expectedDescription = "A full-bodied white wine.";

            // Act
            wine.Description = expectedDescription;

            // Assert
            Assert.AreEqual(expectedDescription, wine.Description);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingTasteProfile()
        {
            // Arrange
            var wine = new Wine();
            var expectedTasteProfile = "Fruity and crisp.";

            // Act
            wine.TasteProfile = expectedTasteProfile;

            // Assert
            Assert.AreEqual(expectedTasteProfile, wine.TasteProfile);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingImage()
        {
            // Arrange
            var wine = new Wine();
            var expectedImage = "http://example.com/images/chardonnay.jpg";

            // Act
            wine.Image = expectedImage;

            // Assert
            Assert.AreEqual(expectedImage, wine.Image);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingLink()
        {
            // Arrange
            var wine = new Wine();
            var expectedLink = "http://example.com/chardonnay";

            // Act
            wine.Link = expectedLink;

            // Assert
            Assert.AreEqual(expectedLink, wine.Link);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingPrice()
        {
            // Arrange
            var wine = new Wine();
            var expectedPrice = "20.99";

            // Act
            wine.Price = expectedPrice;

            // Assert
            Assert.AreEqual(expectedPrice, wine.Price);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingCountry()
        {
            // Arrange
            var wine = new Wine();
            var expectedCountry = new Country { /* Set properties if any */ };

            // Act
            wine.Country = expectedCountry;

            // Assert
            Assert.AreEqual(expectedCountry, wine.Country);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingCategories()
        {
            // Arrange
            var wine = new Wine();
            var expectedCategories = new List<Category>
            {
                new Category { CategoryId = 1, Name = "Red" },
                new Category { CategoryId = 2, Name = "Organic" }
            };

            // Act
            wine.Categories = expectedCategories;

            // Assert
            CollectionAssert.AreEqual(expectedCategories, wine.Categories.ToList());
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingKind()
        {
            // Arrange
            var wine = new Wine();
            var expectedKind = new Kind { KindId = 1, Name = "Chardonnay" };

            // Act
            wine.Kind = expectedKind;

            // Assert
            Assert.AreEqual(expectedKind, wine.Kind);
        }

        [TestMethod]
        public void Wine_ShouldAllowSettingRecipes()
        {
            // Arrange
            var wine = new Wine();
            var expectedRecipes = new List<Recipe>
            {
                new Recipe { RecipeId = 1, Name = "Pasta Primavera", Description = "A pasta dish.", Link = "http://example.com/recipe" }
            };

            // Act
            wine.Recipes = expectedRecipes;

            // Assert
            CollectionAssert.AreEqual(expectedRecipes, wine.Recipes.ToList());
        }
    }
}
