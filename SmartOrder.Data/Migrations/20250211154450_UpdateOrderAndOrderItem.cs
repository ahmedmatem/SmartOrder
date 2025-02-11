using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartOrder.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderAndOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "Orders",
                newName: "Status");

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedWaiterId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Assigned Waiter Identifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsServed",
                table: "OrderItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is item served by waiter");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Menu Item Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AssignedWaiterId",
                table: "Orders",
                column: "AssignedWaiterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemId",
                table: "OrderItems",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AssignedWaiterId",
                table: "Orders",
                column: "AssignedWaiterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_MenuItems_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AssignedWaiterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AssignedWaiterId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "AssignedWaiterId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsServed",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "OrderStatus");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OrderItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Item name.");

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Price of a single unit of the item.");
        }
    }
}
