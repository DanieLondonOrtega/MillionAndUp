﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MillionAndUp.Infrastructure.DataAccess.Context;

#nullable disable

namespace MillionAndUp.Infrastructure.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20231208222233_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MillionAndUp.Domain.Entities.Owner", b =>
                {
                    b.Property<Guid>("IdOwner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birthday");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Photo");

                    b.HasKey("IdOwner");

                    b.ToTable("tblOwner", "dbo");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.Property", b =>
                {
                    b.Property<Guid>("IdProperty")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address");

                    b.Property<string>("CodeInternal")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("CodeInternal");

                    b.Property<Guid>("IdOwner")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("Year");

                    b.HasKey("IdProperty");

                    b.HasIndex("IdOwner");

                    b.ToTable("tblProperty", "dbo");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.PropertyImage", b =>
                {
                    b.Property<Guid>("IdPropertyImage")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProperty")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("Enabled");

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("File");

                    b.HasKey("IdPropertyImage", "IdProperty");

                    b.HasIndex("IdProperty");

                    b.ToTable("tblPropertyImage", "dbo");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.PropertyTrace", b =>
                {
                    b.Property<Guid>("IdPropertyTrace")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProperty")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSale")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateSale");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Tax")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Tax");

                    b.Property<decimal>("Value")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Value");

                    b.HasKey("IdPropertyTrace", "IdProperty");

                    b.HasIndex("IdProperty");

                    b.ToTable("tblPropertyTrace", "dbo");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.Property", b =>
                {
                    b.HasOne("MillionAndUp.Domain.Entities.Owner", "Owner")
                        .WithMany("Properties")
                        .HasForeignKey("IdOwner")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.PropertyImage", b =>
                {
                    b.HasOne("MillionAndUp.Domain.Entities.Property", "Property")
                        .WithMany("Images")
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.PropertyTrace", b =>
                {
                    b.HasOne("MillionAndUp.Domain.Entities.Property", "Property")
                        .WithMany("Traces")
                        .HasForeignKey("IdProperty")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("MillionAndUp.Domain.Entities.Property", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Traces");
                });
#pragma warning restore 612, 618
        }
    }
}
