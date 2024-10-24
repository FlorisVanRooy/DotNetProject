using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void Category_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var category = new Category();

            // Act & Assert
            Assert.AreEqual(0, category.CategoryId); // Default value for int is 0
            Assert.AreEqual(string.Empty, category.Name); // Default value for string is empty
        }

        [TestMethod]
        public void Category_ShouldAllowSettingCategoryId()
        {
            // Arrange
            var category = new Category();
            var expectedCategoryId = 1;

            // Act
            category.CategoryId = expectedCategoryId;

            // Assert
            Assert.AreEqual(expectedCategoryId, category.CategoryId);
        }

        [TestMethod]
        public void Category_ShouldAllowSettingName()
        {
            // Arrange
            var category = new Category();
            var expectedName = "Red Wine";

            // Act
            category.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, category.Name);
        }

        [TestMethod]
        public void Category_ShouldAllowSettingEmptyName()
        {
            // Arrange
            var category = new Category();
            var expectedName = string.Empty;

            // Act
            category.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, category.Name);
        }
    }
}
