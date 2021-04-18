﻿// <auto-generated />
using System;
using AcessoDados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcessoDados.Migrations
{
    [DbContext(typeof(AcessoDbContext))]
    partial class AcessoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StorePOS.tblFamily", b =>
                {
                    b.Property<string>("fldFamilyID")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("fldFamily")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("fldFamilyID");

                    b.ToTable("tblFamily");
                });

            modelBuilder.Entity("StorePOS.tblPayment", b =>
                {
                    b.Property<int>("fldPaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("fldCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("fldPaidValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("fldPaymentTypeID")
                        .HasColumnType("int");

                    b.Property<int>("fldSalesID")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<string>("fldStore")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("fldPaymentID");

                    b.HasIndex("fldPaymentTypeID");

                    b.HasIndex("fldSalesID");

                    b.ToTable("tblPayments");
                });

            modelBuilder.Entity("StorePOS.tblPaymentType", b =>
                {
                    b.Property<int>("fldPaymentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fldPaymentType")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("fldPaymentTypeID");

                    b.ToTable("tblPaymentTypes");
                });

            modelBuilder.Entity("StorePOS.tblPos", b =>
                {
                    b.Property<int>("fldPosID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fldStoreID")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("fldStoreLocation")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("fldPosID");

                    b.HasIndex("fldStoreID");

                    b.ToTable("MyPos");
                });

            modelBuilder.Entity("StorePOS.tblProduct", b =>
                {
                    b.Property<int>("fldProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fldBarcode")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<DateTime?>("fldDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fldDateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("fldDiscontinued")
                        .HasColumnType("bit");

                    b.Property<string>("fldFamily")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("fldProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("fldQtyPerUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("fldUnitMeasure")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("fldUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("fldProductID");

                    b.HasIndex("fldFamily");

                    b.ToTable("tblProduct");
                });

            modelBuilder.Entity("StorePOS.tblSale", b =>
                {
                    b.Property<int>("fldSalesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fldCUstomer")
                        .HasColumnType("int");

                    b.Property<DateTime?>("fldDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fldDatemodified")
                        .HasColumnType("datetime2");

                    b.Property<int>("fldPOSUser")
                        .HasColumnType("int");

                    b.Property<int>("fldPOSnum")
                        .HasColumnType("int");

                    b.Property<bool?>("fldPaid")
                        .HasColumnType("bit");

                    b.Property<string>("fldSalesDocNum")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("fldStore")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<int?>("tblPosfldPosID")
                        .HasColumnType("int");

                    b.HasKey("fldSalesID");

                    b.HasIndex("fldPOSUser");

                    b.HasIndex("tblPosfldPosID");

                    b.ToTable("tblSale");
                });

            modelBuilder.Entity("StorePOS.tblSalesDetail", b =>
                {
                    b.Property<int>("fldSalesDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("fldDateCreated")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("fldLineTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("fldProduct")
                        .HasColumnType("int");

                    b.Property<int>("fldQuantity")
                        .HasColumnType("int");

                    b.Property<int>("fldSalesID")
                        .HasColumnType("int");

                    b.Property<int>("fldSeq")
                        .HasColumnType("int");

                    b.Property<int>("fldUnitPrice")
                        .HasColumnType("int");

                    b.HasKey("fldSalesDetailID");

                    b.HasIndex("fldSalesID");

                    b.ToTable("tblSalesDetail");
                });

            modelBuilder.Entity("StorePOS.tblStock", b =>
                {
                    b.Property<int>("fldStockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("fldCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fldModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("fldProductID")
                        .HasColumnType("int");

                    b.Property<int?>("fldQtySaleUnit")
                        .HasColumnType("int");

                    b.Property<int>("fldQuantity")
                        .HasColumnType("int");

                    b.Property<int>("fldQuantityBase")
                        .HasColumnType("int");

                    b.Property<string>("fldSaleUnit")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("fldStoreID")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.HasKey("fldStockID");

                    b.HasIndex("fldProductID");

                    b.HasIndex("fldStoreID");

                    b.ToTable("tblStock");
                });

            modelBuilder.Entity("StorePOS.tblStore", b =>
                {
                    b.Property<string>("fldStoreID")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<bool?>("fldActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("fldCreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fldModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("fldStore")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("fldStoreAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("fldStoreID");

                    b.ToTable("tblStore");
                });

            modelBuilder.Entity("StorePOS.tblUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("Id");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("StorePOS.tblPayment", b =>
                {
                    b.HasOne("StorePOS.tblPaymentType", "tblPaymentType")
                        .WithMany("tblPayments")
                        .HasForeignKey("fldPaymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorePOS.tblSale", "tblSale")
                        .WithMany("tblPayments")
                        .HasForeignKey("fldSalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StorePOS.tblPos", b =>
                {
                    b.HasOne("StorePOS.tblStore", "tblStore")
                        .WithMany("tblPos")
                        .HasForeignKey("fldStoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StorePOS.tblProduct", b =>
                {
                    b.HasOne("StorePOS.tblFamily", "tblFamily")
                        .WithMany("tblProducts")
                        .HasForeignKey("fldFamily")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StorePOS.tblSale", b =>
                {
                    b.HasOne("StorePOS.tblUser", "tblUser")
                        .WithMany("tblSales")
                        .HasForeignKey("fldPOSUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorePOS.tblPos", "tblPos")
                        .WithMany("tblSales")
                        .HasForeignKey("tblPosfldPosID");
                });

            modelBuilder.Entity("StorePOS.tblSalesDetail", b =>
                {
                    b.HasOne("StorePOS.tblSale", "tblSale")
                        .WithMany("tblSalesDetails")
                        .HasForeignKey("fldSalesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StorePOS.tblStock", b =>
                {
                    b.HasOne("StorePOS.tblProduct", "tblProduct")
                        .WithMany("tblStocks")
                        .HasForeignKey("fldProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StorePOS.tblStore", "tblStore")
                        .WithMany("tblStocks")
                        .HasForeignKey("fldStoreID");
                });
#pragma warning restore 612, 618
        }
    }
}