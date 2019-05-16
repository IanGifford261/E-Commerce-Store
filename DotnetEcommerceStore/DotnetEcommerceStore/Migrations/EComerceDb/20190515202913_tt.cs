using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetEcommerceStore.Migrations.EComerceDb
{
    public partial class tt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckoutItemsID",
                table: "CheckoutItems",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CheckoutID",
                table: "Checkout",
                newName: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CheckoutItems",
                newName: "CheckoutItemsID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Checkout",
                newName: "CheckoutID");
        }
    }
}
