﻿// <auto-generated />
using System;
using BookStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200123140815_Initial_BookGenre5")]
    partial class Initial_BookGenre5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Domain.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("_Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.BookGenre", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<Guid?>("BookId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GenreId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookId", "GenreId");

                    b.HasIndex("BookId1");

                    b.HasIndex("GenreId1");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("_Update")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookStore.Domain.Entities.BookGenre", b =>
                {
                    b.HasOne("BookStore.Domain.Entities.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("BookId1");

                    b.HasOne("BookStore.Domain.Entities.Genre", "Genre")
                        .WithMany("bookGenres")
                        .HasForeignKey("GenreId1");
                });
#pragma warning restore 612, 618
        }
    }
}
