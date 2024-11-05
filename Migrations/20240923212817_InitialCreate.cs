using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "John", "Doe" },
                    { 2, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "Jane", "Smith" },
                    { 3, new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "marktaylor@example.com", "Mark", "Taylor" },
                    { 4, new DateTime(1992, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "emilybrown@example.com", "Emily", "Brown" },
                    { 5, new DateTime(1978, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "danielwilliams@example.com", "Daniel", "Williams" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ReleaseDate", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Description 1", "Product 1", 10.99m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100 },
                    { 2, "Description 2", "Product 2", 25.50m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50 },
                    { 3, "Description 3", "Product 3", 15.75m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75 },
                    { 4, "Description 4", "Product 4", 35.00m, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25 },
                    { 5, "Description 5", "Product 5", 50.99m, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
