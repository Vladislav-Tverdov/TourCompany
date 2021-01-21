﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCompany.Models;

namespace TCompany.Migrations
{
    [DbContext(typeof(TourContext))]
    [Migration("20201029130633_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCompany.Models.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("DaysCost")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("ToursName")
                        .HasColumnType("varchar(100)");

                    b.HasKey("TourId");

                    b.ToTable("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
