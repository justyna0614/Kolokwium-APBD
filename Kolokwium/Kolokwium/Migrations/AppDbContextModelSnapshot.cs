﻿// <auto-generated />
using System;
using Kolokwium.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kolokwium.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kolokwium.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClient");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Kolokwium.Models.Discount", b =>
                {
                    b.Property<int>("IdDiscount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDiscount"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("int");

                    b.Property<int>("IdSubscriptionNavigationIdSubscription")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDiscount");

                    b.HasIndex("IdSubscriptionNavigationIdSubscription");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("Kolokwium.Models.Payment", b =>
                {
                    b.Property<int>("IdPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPayment"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClinet")
                        .HasColumnType("int");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("int");

                    b.HasKey("IdPayment");

                    b.HasIndex("IdClinet");

                    b.HasIndex("IdSubscription");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Kolokwium.Models.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSale"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdClinet")
                        .HasColumnType("int");

                    b.Property<int>("IdSubscription")
                        .HasColumnType("int");

                    b.HasKey("IdSale");

                    b.HasIndex("IdClinet");

                    b.HasIndex("IdSubscription");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("Kolokwium.Models.Subscription", b =>
                {
                    b.Property<int>("IdSubscription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSubscription"));

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RenewalPeriod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSubscription");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("Kolokwium.Models.Discount", b =>
                {
                    b.HasOne("Kolokwium.Models.Subscription", "IdSubscriptionNavigation")
                        .WithMany("Discounts")
                        .HasForeignKey("IdSubscriptionNavigationIdSubscription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdSubscriptionNavigation");
                });

            modelBuilder.Entity("Kolokwium.Models.Payment", b =>
                {
                    b.HasOne("Kolokwium.Models.Client", "IdClientNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("IdClinet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Subscription", "IdSubscriptionNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("IdSubscription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdSubscriptionNavigation");
                });

            modelBuilder.Entity("Kolokwium.Models.Sale", b =>
                {
                    b.HasOne("Kolokwium.Models.Client", "IdClientNavigation")
                        .WithMany("Sales")
                        .HasForeignKey("IdClinet")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium.Models.Subscription", "IdSubscriptionNavigation")
                        .WithMany("Sales")
                        .HasForeignKey("IdSubscription")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdClientNavigation");

                    b.Navigation("IdSubscriptionNavigation");
                });

            modelBuilder.Entity("Kolokwium.Models.Client", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Kolokwium.Models.Subscription", b =>
                {
                    b.Navigation("Discounts");

                    b.Navigation("Payments");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
