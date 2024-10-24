using System.Text.Json.Serialization;

namespace WineCode.Models
{
    public class Wine
    {
        public int WineID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TasteProfile { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;

        // Navigation properties
        public Country Country { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public Kind Kind { get; set; }

        // Many-to-many relationship with Recipe
        [JsonIgnore]
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public bool Favorite { get; set; }
    }
}
