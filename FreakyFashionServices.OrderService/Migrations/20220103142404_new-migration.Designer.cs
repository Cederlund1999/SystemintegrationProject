﻿// <auto-generated />
using FreakyFashionServices.OrderService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreakyFashionServices.OrderService.Migrations
{
    [DbContext(typeof(OrderServiceContext))]
    [Migration("20220103142404_new-migration")]
    partial class newmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FreakyFashionServices.OrderService.Models.Domain.Items", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("OrderLineCustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderLineCustomerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FreakyFashionServices.OrderService.Models.Domain.OrderLine", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("FreakyFashionServices.OrderService.Models.Domain.Orders", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FreakyFashionServices.OrderService.Models.Domain.Items", b =>
                {
                    b.HasOne("FreakyFashionServices.OrderService.Models.Domain.OrderLine", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderLineCustomerId");
                });

            modelBuilder.Entity("FreakyFashionServices.OrderService.Models.Domain.OrderLine", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
