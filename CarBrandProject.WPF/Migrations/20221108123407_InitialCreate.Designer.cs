// <auto-generated />
using System;
using CarBrandProject.WPF.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarBrandProject.WPF.Migrations
{
    [DbContext(typeof(BrandsDbContext))]
    [Migration("20221108123407_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("CarBrandProject.WPF.EntityFramework.DTOs.BrandDto", b =>
                {
                    b.Property<Guid>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasColumnType("TEXT");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarBrandProject.WPF.EntityFramework.DTOs.ModelDto", b =>
                {
                    b.Property<Guid>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("DateOnMarket")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvalable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelClass")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PassangerCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TypeOfFuel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ModelId");

                    b.ToTable("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
