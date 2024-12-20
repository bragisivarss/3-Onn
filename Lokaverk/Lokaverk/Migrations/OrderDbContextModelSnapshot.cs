﻿// <auto-generated />
using System;
using Lokaverk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lokaverk.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lokaverk.Models.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdMeal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrArea")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient16")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient17")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient18")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient19")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient20")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrIngredient9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrMeal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrMealThumb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("strCategory")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdMeal = "2",
                            StrArea = "someArea",
                            StrIngredient1 = "",
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
                            StrIngredient2 = "",
                            StrIngredient20 = "",
                            StrIngredient3 = "",
                            StrIngredient4 = "",
                            StrIngredient5 = "",
                            StrIngredient6 = "",
                            StrIngredient7 = "",
                            StrIngredient8 = "",
                            StrIngredient9 = "",
                            StrMeal = "beef",
                            StrMealThumb = "url"
                        });
                });

            modelBuilder.Entity("Lokaverk.Models.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<string>("StrDrink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrDrinkThumb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrGlass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("idDrink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderId = 1,
                            Price = 200,
                            StrDrink = "Coca Cola",
                            StrDrinkThumb = "url",
                            StrGlass = "glass"
                        });
                });

            modelBuilder.Entity("Lokaverk.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DishId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("People")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2024, 12, 20, 13, 20, 13, 771, DateTimeKind.Utc).AddTicks(9106),
                            DishId = 1,
                            Email = "gunnsteinnskula@gmail.com",
                            People = 10,
                            Price = 1000
                        });
                });

            modelBuilder.Entity("Lokaverk.Models.Drink", b =>
                {
                    b.HasOne("Lokaverk.Models.Order", "Order")
                        .WithMany("Drinks")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Lokaverk.Models.Order", b =>
                {
                    b.HasOne("Lokaverk.Models.Dish", "Dish")
                        .WithMany()
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Lokaverk.Models.Order", b =>
                {
                    b.Navigation("Drinks");
                });
#pragma warning restore 612, 618
        }
    }
}
