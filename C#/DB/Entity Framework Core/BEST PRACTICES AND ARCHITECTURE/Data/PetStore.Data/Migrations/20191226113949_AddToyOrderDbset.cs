﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace PetStore.Data.Migrations
{
    public partial class AddToyOrderDbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrder_Orders_OrderId",
                table: "ToyOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrder_Toys_ToyId",
                table: "ToyOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToyOrder",
                table: "ToyOrder");

            migrationBuilder.RenameTable(
                name: "ToyOrder",
                newName: "ToyOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ToyOrder_ToyId",
                table: "ToyOrders",
                newName: "IX_ToyOrders_ToyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToyOrders",
                table: "ToyOrders",
                columns: new[] { "OrderId", "ToyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrders_Orders_OrderId",
                table: "ToyOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrders_Toys_ToyId",
                table: "ToyOrders",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrders_Orders_OrderId",
                table: "ToyOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyOrders_Toys_ToyId",
                table: "ToyOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToyOrders",
                table: "ToyOrders");

            migrationBuilder.RenameTable(
                name: "ToyOrders",
                newName: "ToyOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ToyOrders_ToyId",
                table: "ToyOrder",
                newName: "IX_ToyOrder_ToyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToyOrder",
                table: "ToyOrder",
                columns: new[] { "OrderId", "ToyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrder_Orders_OrderId",
                table: "ToyOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyOrder_Toys_ToyId",
                table: "ToyOrder",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
