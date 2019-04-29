﻿// <auto-generated />
using DotnetEcommerceStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotnetEcommerceStore.Migrations.EComerceDb
{
    [DbContext(typeof(EComerceDbContext))]
    [Migration("20190429002702_seed")]
    partial class seed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotnetEcommerceStore.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("SKU");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A stringed instrument that emits pleasant tones. Can be played solo or in an orchestra",
                            Name = "Violin",
                            Price = 350m,
                            SKU = "12"
                        },
                        new
                        {
                            ID = 2,
                            Description = "Pear-shaped fiddle having strings that are sounded not by a bow but by the rosined rim of a wooden wheel turned by a handle at the instrument's end.",
                            Name = "Hurdy Gurdy",
                            Price = 9000m,
                            SKU = "123"
                        },
                        new
                        {
                            ID = 3,
                            Description = " instrument that adds a buzzing timbral quality to a player's voice when the player vocalizes into it",
                            Name = "Kazoo",
                            Price = 100m,
                            SKU = "1234"
                        },
                        new
                        {
                            ID = 4,
                            Description = " Australian Aboriginal wind instrument, which is blown to produce a deep, resonant sound, varied by rhythmic accents of timbre and volume.",
                            Name = "Didgeridoo",
                            Price = 27m,
                            SKU = "12345"
                        },
                        new
                        {
                            ID = 5,
                            Description = "Waisted resonating chamber with goatskin belly. Carved wooden makara finial. Gut strings. Played with small, attached plectrum.",
                            Name = "Lute",
                            Price = 568m,
                            SKU = "123456"
                        },
                        new
                        {
                            ID = 6,
                            Description = "electronic musical instrument in which the tone is generated by two high-frequency oscillators and the pitch controlled by the movement of the performer's hand toward and away from the circuit.",
                            Name = "Theremin",
                            Price = 123m,
                            SKU = "1234567"
                        },
                        new
                        {
                            ID = 7,
                            Description = "Single reed saxophone made of brass and a tapered bore on a fingering system based on that of the oboe",
                            Name = "Tenor saxophone",
                            Price = 789m,
                            SKU = "12345678"
                        },
                        new
                        {
                            ID = 8,
                            Description = "instruments produce sound hydraulically, as music is played by covering different water jets to produce different pitches",
                            Name = "Hydrolauphone",
                            Price = 1999m,
                            SKU = "123456789"
                        },
                        new
                        {
                            ID = 9,
                            Description = "A series of glass bowls rotates while the player simply touches the bowls with wet fingers to create the desired notes",
                            Name = "Glass Harmonica",
                            Price = 894m,
                            SKU = "987654"
                        },
                        new
                        {
                            ID = 10,
                            Description = "An organ that is powered by gasoline and propane; he sound are produced by combustion and explosion.",
                            Name = "Pyrophone",
                            Price = 25m,
                            SKU = "987654321"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
