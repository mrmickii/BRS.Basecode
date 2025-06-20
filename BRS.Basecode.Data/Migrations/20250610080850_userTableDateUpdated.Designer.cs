﻿// <auto-generated />
using System;
using BRS.Basecode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BRS.Basecode.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250610080850_userTableDateUpdated")]
    partial class userTableDateUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BRS.Basecode.Data.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_Created");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_Updated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Password");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.Property<int>("UserPin")
                        .HasColumnType("int")
                        .HasColumnName("User_Pin");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
