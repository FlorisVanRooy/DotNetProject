using System;
using System.Collections.Generic;
using System.Linq;
using WineCode.Models;

namespace WineCode.Data
{
    public static class DbInitialiser
    {
        public static void Initialize(WineContext context)
        {
            // Zorg ervoor dat de database is aangemaakt
            context.Database.EnsureCreated();

            // Controleer of de database al gegevens bevat
            if (context.Wines.Any() || context.Categories.Any() || context.Countries.Any() ||
                context.Kinds.Any() || context.Recipes.Any())
            {
                return; // Database is al gevuld
            }

            // Seed Categories
            var categories = new[]
            {
                new Category { Name = "Red" },
                new Category { Name = "White" },
                new Category { Name = "Vegan" },
                new Category { Name = "Rosé" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges(); // Sla de categorieën op in de DB

            // Seed Countries
            var countries = new[]
            {
                new Country { Name = "France" },
                new Country { Name = "Italy" },
                new Country { Name = "Spain" },
                new Country { Name = "USA" }
            };
            context.Countries.AddRange(countries);
            context.SaveChanges(); // Sla de landen op in de DB

            // Seed Kinds
            var kinds = new[]
            {
                new Kind { Name = "Sauvignon Blanc" },
                new Kind { Name = "Merlot" },
                new Kind { Name = "Chardonnay" },
                new Kind { Name = "Cabernet Sauvignon" },
                new Kind { Name = "Pinot Noir" },
                new Kind { Name = "Tempranillo" },
                new Kind { Name = "Malbec" }
            };
            context.Kinds.AddRange(kinds);
            context.SaveChanges(); // Sla de soorten op in de DB

            // Seed Wines
            var wines = new List<Wine>
            {
                new Wine
                {
                    Name = "Chateau Margaux",
                    Description = "A famous French red wine",
                    TasteProfile = "Rich and complex",
                    Image = "https://www.topwijnen.be/media/cache/product_detail/b/0/9/e/b09e54296c8c63ced5db824aafc4fd69769146eb_Margaux_02.png",
                    Link = "https://www.topwijnen.be/fr/produit/wijnen/frankrijk/bordeaux/medoc/margaux/pavillon-rouge-de-ch-margaux/WN1002416?srsltid=AfmBOor7ADM0CHbO8B2XFVJk2HsG2KwRkAYnol5d1kJQgTs5eqoPclMJ4SA",
                    Price = "$120",
                    Country = countries[0],
                    Categories = new List<Category> { categories[0] }, // Red
                    Kind = kinds[1] // Merlot
                },
                new Wine
                {
                    Name = "Pinot Grigio",
                    Description = "A light white wine",
                    TasteProfile = "Crisp and fresh",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200777_2023_bella_vittoria_pinot_grigio_edit.png?quality=95&fit=bounds&height=560&width=700&bg-color=FFF",
                    Link = "https://www.wijnbeurs.be/bella-vittoria-pinot-grigio-delle-venezie",
                    Price = "$45",
                    Country = countries[1],
                    Categories = new List<Category> { categories[1] }, // White
                    Kind = kinds[0] // Sauvignon Blanc
                },
                new Wine
                {
                    Name = "Chardonnay",
                    Description = "A full-bodied white wine",
                    TasteProfile = "Buttery and oaky",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200778_chardonnay.jpg",
                    Link = "https://www.wijnbeurs.be/chardonnay",
                    Price = "$50",
                    Country = countries[2],
                    Categories = new List<Category> { categories[1] }, // White
                    Kind = kinds[2] // Chardonnay
                },
                new Wine
                {
                    Name = "Cabernet Sauvignon",
                    Description = "A bold red wine",
                    TasteProfile = "Dark fruit and chocolate",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200779_cabernet_sauvignon.jpg",
                    Link = "https://www.wijnbeurs.be/cabernet-sauvignon",
                    Price = "$80",
                    Country = countries[3],
                    Categories = new List<Category> { categories[0] }, // Red
                    Kind = kinds[3] // Cabernet Sauvignon
                },
                new Wine
                {
                    Name = "Tempranillo",
                    Description = "A Spanish red wine",
                    TasteProfile = "Cherry and plum flavors",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200780_tempranillo.jpg",
                    Link = "https://www.wijnbeurs.be/tempranillo",
                    Price = "$40",
                    Country = countries[1],
                    Categories = new List<Category> { categories[0] }, // Red
                    Kind = kinds[5] // Tempranillo
                },
                new Wine
                {
                    Name = "Malbec",
                    Description = "A rich, fruity red wine",
                    TasteProfile = "Blackberry and plum notes",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200781_malbec.jpg",
                    Link = "https://www.wijnbeurs.be/malbec",
                    Price = "$60",
                    Country = countries[0],
                    Categories = new List<Category> { categories[0] }, // Red
                    Kind = kinds[6] // Malbec
                }
            };
            context.Wines.AddRange(wines);
            context.SaveChanges(); // Sla de wijnen op in de DB

            // Seed Recipes
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "Biefstuk",
                    Description = "Juicy steak cooked to perfection",
                    Link = "https://www.example.com/biefstuk-recept",
                    Image = "https://www.example.com/images/biefstuk.jpg",
                    Wines = new List<Wine> { wines[3] } // Cabernet Sauvignon
                },
                new Recipe
                {
                    Name = "Asperges",
                    Description = "Fresh asparagus served with hollandaise sauce",
                    Link = "https://www.example.com/asperges-recept",
                    Image = "https://www.example.com/images/asperges.jpg",
                    Wines = new List<Wine> { wines[2], wines[3] } // Chardonnay
                },
                new Recipe
                {
                    Name = "Friet",
                    Description = "Crispy Belgian fries",
                    Link = "https://www.example.com/friet-recept",
                    Image = "https://www.example.com/images/friet.jpg",
                    Wines = new List<Wine> { wines[4] } // Tempranillo
                },
                new Recipe
                {
                    Name = "Kip",
                    Description = "Delicious roasted chicken",
                    Link = "https://www.example.com/kip-recept",
                    Image = "https://www.example.com/images/kip.jpg",
                    Wines = new List<Wine> { wines[5] } // Malbec
                },
                new Recipe
                {
                    Name = "Spaghetti",
                    Description = "Classic spaghetti with tomato sauce",
                    Link = "https://www.example.com/spaghetti-recept",
                    Image = "https://www.example.com/images/spaghetti.jpg",
                    Wines = new List<Wine> { wines[1] } // Pinot Grigio
                }
            };
            context.Recipes.AddRange(recipes);
            context.SaveChanges(); // Sla de recepten op in de DB

            // Seed Favorites
            //var favorites = new List<Favorite>
            //{
            //    new Favorite
            //    {
            //        FavoriteWines = new List<FavoriteWine>
            //        {
            //            new FavoriteWine { WineID = wines[0].WineID },
            //            new FavoriteWine { WineID = wines[1].WineID }
            //        }
            //    },
            //    new Favorite
            //    {
            //        FavoriteWines = new List<FavoriteWine>
            //        {
            //            new FavoriteWine { WineID = wines[1].WineID }
            //        }
            //    }
            //};

            //context.Favorites.AddRange(favorites);
            context.SaveChanges(); // Sla de favorieten op in de DB
        }
    }
}
