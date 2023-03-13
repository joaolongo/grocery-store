using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APP.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SpecialOffer",
                columns: new[] { "Id", "Description", "DiscountItemId", "ItemId", "Percentage", "RequiredAmount" },
                values: new object[,]
                {
                    { new Guid("317f6f8f-b0df-44a7-b07d-05c8f2fcf02b"), "Apples have 10% off their normal price this week", null, new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"), 0.1m, 1 },
                    { new Guid("9faae3b7-2e49-4b7e-9fa3-74e8a259afe0"), "Buy 2 tins of soup and get a loaf of bread for half price", new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"), new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"), 0.5m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpecialOffer",
                keyColumn: "Id",
                keyValue: new Guid("317f6f8f-b0df-44a7-b07d-05c8f2fcf02b"));

            migrationBuilder.DeleteData(
                table: "SpecialOffer",
                keyColumn: "Id",
                keyValue: new Guid("9faae3b7-2e49-4b7e-9fa3-74e8a259afe0"));
        }
    }
}
