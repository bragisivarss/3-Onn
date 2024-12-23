using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lokaverk.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMeal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMeal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    strCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrMealThumb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient11 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient12 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient13 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient14 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient15 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient16 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient17 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient18 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient19 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrIngredient20 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    People = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idDrink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrDrink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrGlass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrDrinkThumb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CreatedDate", "IdMeal", "StrArea", "StrIngredient1", "StrIngredient10", "StrIngredient11", "StrIngredient12", "StrIngredient13", "StrIngredient14", "StrIngredient15", "StrIngredient16", "StrIngredient17", "StrIngredient18", "StrIngredient19", "StrIngredient2", "StrIngredient20", "StrIngredient3", "StrIngredient4", "StrIngredient5", "StrIngredient6", "StrIngredient7", "StrIngredient8", "StrIngredient9", "StrMeal", "StrMealThumb", "UpdatedDate", "strCategory" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2", "someArea", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "beef", "url", null, null });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedDate", "Date", "DishId", "Email", "People", "Price", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 19, 4, 38, 588, DateTimeKind.Utc).AddTicks(3947), 1, "gunnsteinnskula@gmail.com", 10, 1000, null });

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Amount", "CreatedDate", "OrderId", "Price", "StrDrink", "StrDrinkThumb", "StrGlass", "UpdatedDate", "idDrink" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200, "Coca Cola", "url", "glass", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_OrderId",
                table: "Drinks",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishId",
                table: "Orders",
                column: "DishId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Dishes");
        }
    }
}
