using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineTest
{
    [TestClass]
    public class KindTest
    {
        [TestMethod]
        public void Kind_ShouldInitializeWithDefaultValues()
        {
            // Arrange
            var kind = new Kind();

            // Act & Assert
            Assert.AreEqual(0, kind.KindId); // Default value for int is 0
            Assert.AreEqual(string.Empty, kind.Name); // Default value for string is empty
        }

        [TestMethod]
        public void Kind_ShouldAllowSettingKindId()
        {
            // Arrange
            var kind = new Kind();
            var expectedKindId = 1;

            // Act
            kind.KindId = expectedKindId;

            // Assert
            Assert.AreEqual(expectedKindId, kind.KindId);
        }

        [TestMethod]
        public void Kind_ShouldAllowSettingName()
        {
            // Arrange
            var kind = new Kind();
            var expectedName = "Sauvignon";

            // Act
            kind.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, kind.Name);
        }

        [TestMethod]
        public void Kind_ShouldAllowSettingEmptyName()
        {
            // Arrange
            var kind = new Kind();
            var expectedName = string.Empty;

            // Act
            kind.Name = expectedName;

            // Assert
            Assert.AreEqual(expectedName, kind.Name);
        }
    }
}
