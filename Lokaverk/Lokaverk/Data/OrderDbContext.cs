using Lokaverk.Models;
using Microsoft.EntityFrameworkCore;

namespace Lokaverk.Data
{
    public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Dish
            modelBuilder.Entity<Dish>().HasData(
                new Dish
                {
                    Id = 1,
                    IdMeal = "2",
                    StrMeal = "beef",
                    StrArea = "someArea",
                    StrMealThumb = "url",
                    StrIngredient1 = "",
                    StrIngredient2 = "",
                    StrIngredient3 = "",
                    StrIngredient4 = "",
                    StrIngredient5 = "",
                    StrIngredient6 = "",
                    StrIngredient7 = "",
                    StrIngredient8 = "",
                    StrIngredient9 = "",
                    StrIngredient10 = "",
                    StrIngredient11 = "",
                    StrIngredient12 = "",
                    StrIngredient13 = "",
                    StrIngredient14 = "",
                    StrIngredient15 = "",
                    StrIngredient16 = "",
                    StrIngredient17 = "",
                    StrIngredient18 = "",
                    StrIngredient19 = "",
                    StrIngredient20 = ""
                }
            );

            // Seed data for Order
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Price = 1000,
                    Email = "gunnsteinnskula@gmail.com",
                    People = 10,
                    Date = DateTime.UtcNow,
                    DishId = 1 // FK to Dish
                }
            );

            // Seed data for Drink
            modelBuilder.Entity<Drink>().HasData(
                new Drink
                {
                    Id = 1,
                    StrDrink = "Coca Cola",
                    StrGlass = "glass",
                    StrDrinkThumb = "url",
                    Price = 200,
                    Amount = 2,
                    OrderId = 1 // FK to Order
                }
            );

        }
    }
}
