﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesPortal.Api.Infrastructure.Persistence.Context;

#nullable disable

namespace SalesPortal.Api.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Envanter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ENVCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Envanters");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.SalesProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SalesProducts");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.SalesUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EnvanterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Package")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnvanterId");

                    b.ToTable("SalesUnits");
                });

            modelBuilder.Entity("SalesProductSalesUnit", b =>
                {
                    b.Property<Guid>("SalesProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalesUnitsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SalesProductsId", "SalesUnitsId");

                    b.HasIndex("SalesUnitsId");

                    b.ToTable("SalesProductSalesUnit");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Envanter", b =>
                {
                    b.HasOne("SalesPortal.Api.Domain.Models.Brand", "Brand")
                        .WithMany("Envanters")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesPortal.Api.Domain.Models.Company", "Company")
                        .WithMany("Envanters")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.SalesProduct", b =>
                {
                    b.HasOne("SalesPortal.Api.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.SalesUnit", b =>
                {
                    b.HasOne("SalesPortal.Api.Domain.Models.Envanter", "Envanter")
                        .WithMany("SalesUnits")
                        .HasForeignKey("EnvanterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Envanter");
                });

            modelBuilder.Entity("SalesProductSalesUnit", b =>
                {
                    b.HasOne("SalesPortal.Api.Domain.Models.SalesProduct", null)
                        .WithMany()
                        .HasForeignKey("SalesProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesPortal.Api.Domain.Models.SalesUnit", null)
                        .WithMany()
                        .HasForeignKey("SalesUnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Brand", b =>
                {
                    b.Navigation("Envanters");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Company", b =>
                {
                    b.Navigation("Envanters");
                });

            modelBuilder.Entity("SalesPortal.Api.Domain.Models.Envanter", b =>
                {
                    b.Navigation("SalesUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
