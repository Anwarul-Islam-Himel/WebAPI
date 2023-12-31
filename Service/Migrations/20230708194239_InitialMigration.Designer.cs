﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.AppDb;

#nullable disable

namespace Service.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230708194239_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.EntityModel.Expenditure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("IncomeOrExpenditureTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VoucerNumber")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IncomeOrExpenditureTypeId");

                    b.ToTable("Expenditure", (string)null);
                });

            modelBuilder.Entity("Domain.EntityModel.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("IncomeOrExpenditureTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VoucerNumber")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IncomeOrExpenditureTypeId");

                    b.ToTable("Income", (string)null);
                });

            modelBuilder.Entity("Domain.EntityModel.IncomeOrExpenditureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("IncomeOrExpenditureEnum")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("IncomeOrExpenditureType", (string)null);
                });

            modelBuilder.Entity("Domain.EntityModel.Expenditure", b =>
                {
                    b.HasOne("Domain.EntityModel.IncomeOrExpenditureType", "IncomeOrExpenditureType")
                        .WithMany()
                        .HasForeignKey("IncomeOrExpenditureTypeId");

                    b.Navigation("IncomeOrExpenditureType");
                });

            modelBuilder.Entity("Domain.EntityModel.Income", b =>
                {
                    b.HasOne("Domain.EntityModel.IncomeOrExpenditureType", "IncomeOrExpenditureType")
                        .WithMany()
                        .HasForeignKey("IncomeOrExpenditureTypeId");

                    b.Navigation("IncomeOrExpenditureType");
                });
#pragma warning restore 612, 618
        }
    }
}
