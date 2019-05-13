using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetEcommerceStore.Migrations.EComerceDb
{
    public partial class restart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checkout",
                columns: table => new
                {
                    CheckoutID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PurchaseTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkout", x => x.CheckoutID);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutItems",
                columns: table => new
                {
                    CheckoutItemsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CheckoutID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutItems", x => x.CheckoutItemsID);
                    table.ForeignKey(
                        name: "FK_CheckoutItems_Checkout_CheckoutID",
                        column: x => x.CheckoutID,
                        principalTable: "Checkout",
                        principalColumn: "CheckoutID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutItems_CheckoutID",
                table: "CheckoutItems",
                column: "CheckoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutItems");

            migrationBuilder.DropTable(
                name: "Checkout");
        }
    }
}
