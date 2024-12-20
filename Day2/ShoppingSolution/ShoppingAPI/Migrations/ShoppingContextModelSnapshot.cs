﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingAPI.Contexts;

#nullable disable

namespace ShoppingAPI.Migrations
{
    [DbContext(typeof(ShoppingContext))]
    partial class ShoppingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingAPI.Models.AuditLog", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogId"));

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OldValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogId");

                    b.ToTable("AuditLogs");
                });

            modelBuilder.Entity("ShoppingAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PricePerUnit")
                        .HasColumnType("real");

                    b.Property<int>("StockAvailable")
                        .HasColumnType("int");

                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Description = "Lenovo Laptop",
                            PricePerUnit = 45000f,
                            StockAvailable = 10,
                            Title = "Laptop"
                        },
                        new
                        {
                            Id = 102,
                            Description = "Samsung Mobile",
                            PricePerUnit = 15000f,
                            StockAvailable = 20,
                            Title = "Mobile"
                        },
                        new
                        {
                            Id = 103,
                            Description = "Apple Tablet",
                            PricePerUnit = 25000f,
                            StockAvailable = 5,
                            Title = "Tablet"
                        },
                        new
                        {
                            Id = 104,
                            Description = "MI Smart Watch",
                            PricePerUnit = 5000f,
                            StockAvailable = 15,
                            Title = "Smart Watch"
                        },
                        new
                        {
                            Id = 105,
                            Description = "Boat Headphones",
                            PricePerUnit = 2000f,
                            StockAvailable = 25,
                            Title = "Headphones"
                        });
                });

            modelBuilder.Entity("ShoppingAPI.Models.Supplier", b =>
                {
                    b.Property<string>("SupplierId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Phone")
                        .HasColumnType("float");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            SupplierId = "S101",
                            ContactPerson = "Ramu",
                            Phone = 9876543210.0,
                            SupplierName = "Lenovo"
                        },
                        new
                        {
                            SupplierId = "S102",
                            ContactPerson = "Somu",
                            Phone = 8877665544.0,
                            SupplierName = "Samsung"
                        },
                        new
                        {
                            SupplierId = "S103",
                            ContactPerson = "Bimu",
                            Phone = 7766554433.0,
                            SupplierName = "Apple"
                        },
                        new
                        {
                            SupplierId = "S104",
                            ContactPerson = "Monu",
                            Phone = 2223334445.0,
                            SupplierName = "MI"
                        });
                });

            modelBuilder.Entity("ShoppingAPI.Models.Product", b =>
                {
                    b.HasOne("ShoppingAPI.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ShoppingAPI.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
