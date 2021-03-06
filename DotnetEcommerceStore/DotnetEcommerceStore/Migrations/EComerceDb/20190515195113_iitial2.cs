﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetEcommerceStore.Migrations.EComerceDb
{
    public partial class iitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                });

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
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKU = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CartID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemsID);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_CheckoutItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Name", "Price", "SKU" },
                values: new object[,]
                {
                    { 1, "A stringed instrument that emits pleasant tones. Can be played solo or in an orchestra", "Violin", 350m, "12" },
                    { 2, "Pear-shaped fiddle having strings that are sounded not by a bow but by the rosined rim of a wooden wheel turned by a handle at the instrument's end.", "Hurdy Gurdy", 9000m, "123" },
                    { 3, " instrument that adds a buzzing timbral quality to a player's voice when the player vocalizes into it", "Kazoo", 100m, "1234" },
                    { 4, " Australian Aboriginal wind instrument, which is blown to produce a deep, resonant sound, varied by rhythmic accents of timbre and volume.", "Didgeridoo", 27m, "12345" },
                    { 5, "Waisted resonating chamber with goatskin belly. Carved wooden makara finial. Gut strings. Played with small, attached plectrum.", "Lute", 568m, "123456" },
                    { 6, "electronic musical instrument in which the tone is generated by two high-frequency oscillators and the pitch controlled by the movement of the performer's hand toward and away from the circuit.", "Theremin", 123m, "1234567" },
                    { 7, "Single reed saxophone made of brass and a tapered bore on a fingering system based on that of the oboe", "Tenor saxophone", 789m, "12345678" },
                    { 8, "instruments produce sound hydraulically, as music is played by covering different water jets to produce different pitches", "Hydrolauphone", 1999m, "123456789" },
                    { 9, "A series of glass bowls rotates while the player simply touches the bowls with wet fingers to create the desired notes", "Glass Harmonica", 894m, "987654" },
                    { 10, "An organ that is powered by gasoline and propane; he sound are produced by combustion and explosion.", "Pyrophone", 25m, "987654321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartID",
                table: "CartItems",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutItems_CheckoutID",
                table: "CheckoutItems",
                column: "CheckoutID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutItems_ProductID",
                table: "CheckoutItems",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CheckoutItems");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Checkout");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
