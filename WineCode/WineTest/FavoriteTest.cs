//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WineCode.Models;

//namespace WineTest
//{
//    [TestClass]
//    public class FavoriteTest
//    {
//        [TestMethod]
//        public void Favorite_ShouldInitializeWithDefaultValues()
//        {
//            // Arrange
//            var favorite = new Favorite();

//            // Act & Assert
//            Assert.AreEqual(0, favorite.FavoriteId); // Default value for int is 0
//            Assert.IsNull(favorite.User); // Default value for User should be null
//            Assert.IsNotNull(favorite.Favorites); // Favorites should be initialized
//            Assert.AreEqual(0, favorite.Favorites.Count); // Default count for Favorites should be 0
//        }

//        [TestMethod]
//        public void Favorite_ShouldAllowSettingFavoriteId()
//        {
//            // Arrange
//            var favorite = new Favorite();
//            var expectedFavoriteId = 1;

//            // Act
//            favorite.FavoriteId = expectedFavoriteId;

//            // Assert
//            Assert.AreEqual(expectedFavoriteId, favorite.FavoriteId);
//        }

//        [TestMethod]
//        public void Favorite_ShouldAllowSettingUser()
//        {
//            // Arrange
//            var favorite = new Favorite();
//            var expectedUser = new User { /* initialize User properties as needed */ };

//            // Act
//            favorite.User = expectedUser;

//            // Assert
//            Assert.AreEqual(expectedUser, favorite.User);
//        }

//        [TestMethod]
//        public void Favorite_ShouldAllowAddingToFavorites()
//        {
//            // Arrange
//            var favorite = new Favorite
//            {
//                Favorites = new List<Wine>() // Initialize the Favorites list
//            };
//            var wine = new Wine { /* initialize Wine properties as needed */ };

//            // Act
//            favorite.Favorites.Add(wine);

//            // Assert
//            Assert.AreEqual(1, favorite.Favorites.Count);
//            Assert.AreEqual(wine, favorite.Favorites[0]);
//        }
//    }
//}
