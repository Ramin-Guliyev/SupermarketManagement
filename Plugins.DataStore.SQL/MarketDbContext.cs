using CoreBusiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>()
                .HasData(
                new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage Desc" },
                new Category { CategoryId = 2, Name = "Meat", Description = "Meat Desc" },
                new Category { CategoryId = 3, Name = "Bakery", Description = "Bakery Desc" });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { CategoryId = 1, Name = "Ice Tea", ProductId = 1, Price = 1.99, Quantity = 100 },
                new Product { CategoryId = 1, Name = "Ginger Ale", ProductId = 2, Price = 2.99, Quantity = 200 },
                new Product { CategoryId = 3, Name = "Wheat Bread", ProductId = 3, Price = 1.59, Quantity = 300 },
                new Product { CategoryId = 3, Name = "White Bread", ProductId = 4, Price = 1.50, Quantity = 250 },
                new Product { CategoryId = 2, Name = "Beef", ProductId = 5, Price = 19.99, Quantity = 25 });
        }
    }
}
