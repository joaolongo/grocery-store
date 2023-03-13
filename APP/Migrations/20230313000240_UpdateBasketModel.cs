using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBasketModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Basket_Id",
                table: "BasketItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Item_Id",
                table: "BasketItem");

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "BasketItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "BasketItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_BasketId",
                table: "BasketItem",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItem_ItemId",
                table: "BasketItem",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Basket_BasketId",
                table: "BasketItem",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Item_ItemId",
                table: "BasketItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Basket_BasketId",
                table: "BasketItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItem_Item_ItemId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_BasketId",
                table: "BasketItem");

            migrationBuilder.DropIndex(
                name: "IX_BasketItem_ItemId",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "BasketItem");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Basket_Id",
                table: "BasketItem",
                column: "Id",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItem_Item_Id",
                table: "BasketItem",
                column: "Id",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
