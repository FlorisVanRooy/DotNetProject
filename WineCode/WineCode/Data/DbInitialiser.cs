using System;
using System.Collections.Generic;
using System.Linq;
using WineCode.Models;

namespace WineCode.Data
{
    public static class DbInitializer
    {
        public static void Initialize(WineContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.Wines.Any() || context.Categories.Any() || context.Countries.Any() ||
                context.Kinds.Any() || context.Recipes.Any())
            {
                return; // Database has already been seeded
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
            context.SaveChanges(); // Save categories to DB

            // Seed Countries
            var countries = new[]
            {
                new Country { Name = "France" },
                new Country { Name = "Italy" },
                new Country { Name = "Spain" },
                new Country { Name = "USA" }
            };
            context.Countries.AddRange(countries);
            context.SaveChanges(); // Save countries to DB

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
            context.SaveChanges(); // Save kinds to DB

            // Seed Wines
            var wines = new List<Wine>
            {
                new Wine
                {
                    Name = "Chateau Margaux",
                    Description = "A famous French red wine",
                    TasteProfile = "Rich and complex",
                    Image = "https://www.topwijnen.be/media/cache/product_detail/b/0/9/e/b09e54296c8c63ced5db824aafc4fd69769146eb_Margaux_02.png",
                    Link = "https://www.topwijnen.be/fr/produit/wijnen/frankrijk/bordeaux/medoc/margaux/pavillon-rouge-de-ch-margaux/WN1002416",
                    Price = "$120",
                    Country = countries[0], // France
                    Category = categories[0], // Red
                    Kind = kinds[1] // Merlot
                },
                new Wine
                {
                    Name = "Pinot Grigio",
                    Description = "A light white wine",
                    TasteProfile = "Crisp and fresh",
                    Image = "https://www.wijnbeurs.be/media/catalog/product/K/2/K200777_2023_bella_vittoria_pinot_grigio_edit.png",
                    Link = "https://www.wijnbeurs.be/bella-vittoria-pinot-grigio-delle-venezie",
                    Price = "$45",
                    Country = countries[1], // Italy
                    Category = categories[1], // White
                    Kind = kinds[0] // Sauvignon Blanc
                },
                new Wine
                {
                    Name = "Chardonnay",
                    Description = "A full-bodied white wine",
                    TasteProfile = "Buttery and oaky",
                    Image = "https://cdn.webshopapp.com/shops/70983/files/417038615/800x1024x2/callune-chardonnay-6-x-75cl.jpg",
                    Link = "https://www.wijnbeurs.be/chardonnay",
                    Price = "$50",
                    Country = countries[2], // Spain
                    Category = categories[1], // White
                    Kind = kinds[2] // Chardonnay
                },
                new Wine
                {
                    Name = "Cabernet Sauvignon",
                    Description = "A bold red wine",
                    TasteProfile = "Dark fruit and chocolate",
                    Image = "https://vinoscoop.be/cdn/shop/products/VinosG2VontadeCabernetSauvignonwebshop_grande.jpg?v=1654091272",
                    Link = "https://www.wijnbeurs.be/cabernet-sauvignon",
                    Price = "$80",
                    Country = countries[3], // USA
                    Category = categories[0], // Red
                    Kind = kinds[3] // Cabernet Sauvignon
                },
                new Wine
                {
                    Name = "Tempranillo",
                    Description = "A Spanish red wine",
                    TasteProfile = "Cherry and plum flavors",
                    Image = "https://cdn.webshopapp.com/shops/139160/files/466407416/800x1024x2/reinares-tinto-tempranillo.jpg",
                    Link = "https://www.wijnbeurs.be/tempranillo",
                    Price = "$40",
                    Country = countries[1], // Italy
                    Category = categories[0], // Red
                    Kind = kinds[5] // Tempranillo
                },
                new Wine
                {
                    Name = "Malbec",
                    Description = "A rich, fruity red wine",
                    TasteProfile = "Blackberry and plum notes",
                    Image = "https://thewinetist.be/wp-content/uploads/2021/04/Catena-Malbec.png",
                    Link = "https://www.wijnbeurs.be/malbec",
                    Price = "$60",
                    Country = countries[0], // France
                    Category = categories[0], // Red
                    Kind = kinds[6] // Malbec
                }
            };
            context.Wines.AddRange(wines);
            context.SaveChanges(); // Save wines to DB

            // Seed Recipes
            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    Name = "Biefstuk",
                    Description = "Juicy steak cooked to perfection",
                    Link = "https://www.fit.nl/recept/biefstuk-bakken",
                    Image = "https://www.fit.nl/wp-content/uploads/2022/01/Biefstuk-bakken-recept.jpg",
                    Wines = new List<Wine> { wines[3] } // Cabernet Sauvignon
                },
                new Recipe
                {
                    Name = "Asperges",
                    Description = "Fresh asparagus served with hollandaise sauce",
                    Link = "https://www.leukerecepten.nl/recepten/asperges-op-klassieke-wijze-met-ham-en-ei/",
                    Image = "https://www.leukerecepten.nl/app/uploads/2020/04/klassieke-asperges.jpg",
                    Wines = new List<Wine> { wines[2], wines[3] } // Chardonnay
                },
                new Recipe
                {
                    Name = "Friet",
                    Description = "Crispy Belgian fries",
                    Link = "https://www.libelle-lekker.be/bekijk-recept/5483/zelfgemaakte-frietjes-1",
                    Image = "https://www.okokorecepten.nl/i/recepten/redactie/2009-1/patates-frites-500.jpg ",
                    Wines = new List<Wine> { wines[4] } // Tempranillo
                },
                new Recipe
                {
                    Name = "Kip",
                    Description = "Delicious roasted chicken",
                    Link = "https://www.leukerecepten.nl/kip-recepten/",
                    Image = "https://www.flyingfoodie.nl/wp-content/uploads/2023/06/Toscaanse-Kip-2.jpg",
                    Wines = new List<Wine> { wines[5] } // Malbec
                },
                new Recipe
                {
                    Name = "Spaghetti",
                    Description = "Classic spaghetti with tomato sauce",
                    Link = "https://www.solo.be/nl/recipes/spaghetti-bolognese-188346",
                    Image = "https://www.solo.be/nl/-/media/Project/Upfield/Brands/Solo/Solo-be/Assets/Recipes/sync-images/269d7aa7-0760-4ec9-b909-cb2ccc33edaf.jpg?rev=24477ddadfb44d1898842cfb4ff53564&w=1600",
                    Wines = new List<Wine> { wines[1] } // Pinot Grigio
                }
            };
            context.Recipes.AddRange(recipes);

            context.SaveChanges(); // Save recipes to DB
        }
    }
}
