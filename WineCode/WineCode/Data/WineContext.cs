using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;
using Microsoft.EntityFrameworkCore;

namespace WineCode.Data
{
    public class WineContext : DbContext
    {
        public WineContext(DbContextOptions<WineContext> options) : base(options) { }

        public DbSet<Wine> Wines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>().ToTable("Wine");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Kind>().ToTable("Kind");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            //modelBuilder.Entity<Favorite>().ToTable("Favorite");

            // Configuring one-to-many relationship between Recipe and Wine
            modelBuilder.Entity<Wine>()
                .HasMany(w => w.Recipes)
                .WithMany(r => r.Wines)
                .UsingEntity(j => j.ToTable("WineRecipe"));

            // Configuring many-to-many relationship between Favorite and Wine through FavoriteWine
            //modelBuilder.Entity<FavoriteWine>()
            //    .HasKey(fw => new { fw.FavoriteId, fw.WineID });

            //modelBuilder.Entity<FavoriteWine>()
            //    .HasOne(fw => fw.Favorite)
            //    .WithMany(f => f.FavoriteWines)
            //    .HasForeignKey(fw => fw.FavoriteId);

            //modelBuilder.Entity<FavoriteWine>()
            //    .HasOne(fw => fw.Wine)
            //    .WithMany(w => w.FavoriteWines)
            //    .HasForeignKey(fw => fw.WineID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WineAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
