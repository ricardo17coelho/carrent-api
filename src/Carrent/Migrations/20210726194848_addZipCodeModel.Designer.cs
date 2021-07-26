﻿// <auto-generated />
using System;
using Carrent.Common.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carrent.Migrations
{
    [DbContext(typeof(CarRentDbContext))]
    [Migration("20210726194848_addZipCodeModel")]
    partial class addZipCodeModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Carrent.CarManagement.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Carrent.CarManagement.Domain.CarClass", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarClasses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("27713fb4-4ef0-4e06-8357-54fead94f691"),
                            PricePerDay = 12m,
                            Type = "Classic"
                        },
                        new
                        {
                            Id = new Guid("4868a0b5-33d2-4187-8728-a7481c767da7"),
                            PricePerDay = 8m,
                            Type = "Basic"
                        },
                        new
                        {
                            Id = new Guid("1cfab1df-f331-4bb2-9e99-c75e86c3cd99"),
                            PricePerDay = 20m,
                            Type = "Medium"
                        },
                        new
                        {
                            Id = new Guid("e665700e-20e4-4c71-8e2a-6e5190b44026"),
                            PricePerDay = 40m,
                            Type = "Luxury"
                        });
                });

            modelBuilder.Entity("Carrent.ZipCodeManagement.Domain.ZipCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ZipCodes");
                });

            modelBuilder.Entity("Carrent.CarManagement.Domain.Car", b =>
                {
                    b.HasOne("Carrent.CarManagement.Domain.CarClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });
#pragma warning restore 612, 618
        }
    }
}
