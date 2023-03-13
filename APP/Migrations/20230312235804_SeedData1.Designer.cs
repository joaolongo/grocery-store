﻿// <auto-generated />
using System;
using APP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APP.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230312235804_SeedData1")]
    partial class SeedData1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("APP.Domain.Basket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("APP.Domain.BasketItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BasketItem");
                });

            modelBuilder.Entity("APP.Domain.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid?>("SpecialOfferId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5a164522-55fe-406d-8c0d-fe2907154b82"),
                            Name = "Soup",
                            Price = 0.65m
                        },
                        new
                        {
                            Id = new Guid("3c27db6e-7a6b-4f72-b542-2d2353ecc2e5"),
                            Name = "Bread",
                            Price = 0.8m
                        },
                        new
                        {
                            Id = new Guid("d7aeb3c3-8467-4e60-bec1-12ba88e59380"),
                            Name = "Milk",
                            Price = 1.3m
                        },
                        new
                        {
                            Id = new Guid("9200f2d7-72a9-4c7d-b5d5-5dd3e3ee4dc4"),
                            Name = "Apples",
                            Price = 1m
                        });
                });

            modelBuilder.Entity("APP.Domain.SpecialOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("DiscountItemId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("Percentage")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<int>("RequiredAmount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DiscountItemId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("SpecialOffer");
                });

            modelBuilder.Entity("APP.Domain.BasketItem", b =>
                {
                    b.HasOne("APP.Domain.Basket", "Basket")
                        .WithMany("Items")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APP.Domain.Item", "Item")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("APP.Domain.SpecialOffer", b =>
                {
                    b.HasOne("APP.Domain.Item", "DiscountItem")
                        .WithMany()
                        .HasForeignKey("DiscountItemId");

                    b.HasOne("APP.Domain.Item", "Item")
                        .WithOne("SpecialOffer")
                        .HasForeignKey("APP.Domain.SpecialOffer", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("DiscountItem");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("APP.Domain.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("APP.Domain.Item", b =>
                {
                    b.Navigation("SpecialOffer");
                });
#pragma warning restore 612, 618
        }
    }
}