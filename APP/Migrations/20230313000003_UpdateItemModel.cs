using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialOfferId",
                table: "Item");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpecialOfferId",
                table: "Item",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"),
                column: "SpecialOfferId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"),
                column: "SpecialOfferId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"),
                column: "SpecialOfferId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("d7aeb3c3-8467-4e60-bec1-12ba88e59380"),
                column: "SpecialOfferId",
                value: null);
        }
    }
}
