﻿// <auto-generated />
using BookWorm.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookWorm.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookWorm.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Action"
                        });
                });

            modelBuilder.Entity("BookWorm.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            Category = "Novel",
                            Description = "A novel written by American author F. Scott Fitzgerald.",
                            ISBN = "9780743273565",
                            ListPrice = 10.99,
                            Price = 8.9900000000000002,
                            Price100 = 6.9900000000000002,
                            Price50 = 7.9900000000000002,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Harper Lee",
                            Category = "Novel",
                            Description = "A novel by Harper Lee published in 1960.",
                            ISBN = "9780061120084",
                            ListPrice = 14.99,
                            Price = 12.99,
                            Price100 = 9.9900000000000002,
                            Price50 = 10.99,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            Category = "SciFi",
                            Description = "A dystopian social science fiction novel and cautionary tale by the English writer George Orwell.",
                            ISBN = "9780451524935",
                            ListPrice = 15.99,
                            Price = 13.99,
                            Price100 = 10.99,
                            Price50 = 11.99,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jane Austen",
                            Category = "Romantic Novel",
                            Description = "A romantic novel of manners written by Jane Austen.",
                            ISBN = "9781503290563",
                            ListPrice = 9.9900000000000002,
                            Price = 7.9900000000000002,
                            Price100 = 5.9900000000000002,
                            Price50 = 6.9900000000000002,
                            Title = "Pride and Prejudice"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
