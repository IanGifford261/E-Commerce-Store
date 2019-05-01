using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetEcommerceStore.Migrations
{
    public partial class ian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FavInstrument",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavInstrument",
                table: "AspNetUsers");
        }
    }
}
