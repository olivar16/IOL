using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IOLDotNet.Migrations.GroceryStoreItem
{
    public partial class newGrocery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryStoreItem",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Brand = table.Column<string>(maxLength: 50, nullable: true),
                    Item = table.Column<string>(maxLength: 50, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Store = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryStoreItem", x => x.itemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryStoreItem");
        }
    }
}
