using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APP.Migrations
{
    /// <inheritdoc />
    public partial class SeedData1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Name", "Price", "SpecialOfferId" },
                values: new object[,]
                {
                    { new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"), "Bread", 0.8m, null },
                    { new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"), "Soup", 0.65m, null },
                    { new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"), "Apples", 1m, null },
                    { new Guid("d7aeb3c3-8467-4e60-bec1-12ba88e59380"), "Milk", 1.3m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"));

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"));

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"));

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("d7aeb3c3-8467-4e60-bec1-12ba88e59380"));
        }
    }
}
