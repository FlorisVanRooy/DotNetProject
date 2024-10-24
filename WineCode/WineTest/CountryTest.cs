using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineTest
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void Country_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var country = new Country();

            // Act & Assert
            Assert.AreEqual(0, country.CountryId); // Default value for int is 0
            Assert.AreEqual(string.Empty, country.Name); // Default value for string is empty
        }

        [TestMethod]
        public void Country_ShouldAllowSettingCountryId()
        {
            // Arrange
            var country = new Country();
            var expectedCountryId = 1;

            // Act
            country.CountryId = expectedCountryId;

            // Assert
            Assert.AreEqual(expectedCountryId, country.CountryId);
        }

        [TestMethod]
        public void Country_ShouldAllowSettingName()
        {
            // Arrange
            var country = new Country();
            var expectedName = "France";

            // Act
            country.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, country.Name);
        }

        [TestMethod]
        public void Country_ShouldAllowSettingEmptyName()
        {
            // Arrange
            var country = new Country();
            var expectedName = string.Empty;

            // Act
            country.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, country.Name);
        }
    }
}
