﻿// <auto-generated />
using System;
using DAL2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL2.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DAL2.Entitys.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Сергій Жадан"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Грицак Ярослав"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Дал Роальд"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Дашвар Люко"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Дочинець Мирослав"
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("StatusId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Text for first book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "First book",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Text for second book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "Second book",
                            StatusId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Text for 3 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "3 book",
                            StatusId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Text for 4 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "4 book",
                            StatusId = 3
                        },
                        new
                        {
                            Id = 5,
                            Description = "Text for 5 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "5 book",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 6,
                            Description = "Text for 6 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "6 book",
                            StatusId = 2
                        },
                        new
                        {
                            Id = 7,
                            Description = "Text for 7 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "7 book",
                            StatusId = 3
                        },
                        new
                        {
                            Id = 8,
                            Description = "Text for 8 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "8 book",
                            StatusId = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Text for 9 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "9 book",
                            StatusId = 1
                        },
                        new
                        {
                            Id = 10,
                            Description = "Text for 10 book",
                            Image = new byte[0],
                            LanguageId = 1,
                            Name = "10 book",
                            StatusId = 2
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId", "AuthorId")
                        .IsUnique();

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 3,
                            BookId = 1
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            BookId = 2
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            BookId = 4
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 2,
                            BookId = 5
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 1,
                            BookId = 6
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 1,
                            BookId = 7
                        },
                        new
                        {
                            Id = 8,
                            AuthorId = 3,
                            BookId = 8
                        },
                        new
                        {
                            Id = 9,
                            AuthorId = 1,
                            BookId = 9
                        },
                        new
                        {
                            Id = 10,
                            AuthorId = 4,
                            BookId = 10
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.BookCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("BookId", "CategoryId")
                        .IsUnique();

                    b.ToTable("BookCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            CategoryId = 4
                        },
                        new
                        {
                            Id = 5,
                            BookId = 5,
                            CategoryId = 2
                        },
                        new
                        {
                            Id = 6,
                            BookId = 6,
                            CategoryId = 1
                        },
                        new
                        {
                            Id = 7,
                            BookId = 7,
                            CategoryId = 1
                        },
                        new
                        {
                            Id = 8,
                            BookId = 8,
                            CategoryId = 3
                        },
                        new
                        {
                            Id = 9,
                            BookId = 9,
                            CategoryId = 1
                        },
                        new
                        {
                            Id = 10,
                            BookId = 10,
                            CategoryId = 4
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.BookTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TagId");

                    b.HasIndex("BookId", "TagId")
                        .IsUnique();

                    b.ToTable("BookTags");
                });

            modelBuilder.Entity("DAL2.Entitys.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ethnic & Cultural"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Europe"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Historical"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Military"
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("ChapterName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PremiumPublishDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("PublishDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BookId", "ChapterId")
                        .IsUnique();

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("DAL2.Entitys.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Abbreviated")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Abbreviated")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviated = "UKR",
                            Name = "Ukraine"
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CratedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("DAL2.Entitys.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Ball")
                        .HasColumnType("float");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("BookId", "UserId")
                        .IsUnique();

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("DAL2.Entitys.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "finished"
                        },
                        new
                        {
                            Id = 2,
                            Name = "to throw"
                        },
                        new
                        {
                            Id = 3,
                            Name = "continues"
                        });
                });

            modelBuilder.Entity("DAL2.Entitys.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("DAL2.Entitys.Book", b =>
                {
                    b.HasOne("DAL2.Entitys.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL2.Entitys.Status", "Status")
                        .WithMany("Books")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DAL2.Entitys.BookAuthor", b =>
                {
                    b.HasOne("DAL2.Entitys.Author", "Author")
                        .WithMany("BookAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL2.Entitys.Book", "Book")
                        .WithMany("BookAuthor")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DAL2.Entitys.BookCategory", b =>
                {
                    b.HasOne("DAL2.Entitys.Book", "Book")
                        .WithMany("BookCategory")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL2.Entitys.Category", "Category")
                        .WithMany("BooksCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DAL2.Entitys.BookTag", b =>
                {
                    b.HasOne("DAL2.Entitys.Book", "Book")
                        .WithMany("BookTag")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL2.Entitys.Tag", "Tag")
                        .WithMany("BookTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("DAL2.Entitys.Chapter", b =>
                {
                    b.HasOne("DAL2.Entitys.Book", "Book")
                        .WithMany("Chapters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DAL2.Entitys.Page", b =>
                {
                    b.HasOne("DAL2.Entitys.Chapter", "Chapter")
                        .WithMany("Pages")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("DAL2.Entitys.Rating", b =>
                {
                    b.HasOne("DAL2.Entitys.Book", "Book")
                        .WithMany("Ratings")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DAL2.Entitys.Author", b =>
                {
                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("DAL2.Entitys.Book", b =>
                {
                    b.Navigation("BookAuthor");

                    b.Navigation("BookCategory");

                    b.Navigation("BookTag");

                    b.Navigation("Chapters");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("DAL2.Entitys.Category", b =>
                {
                    b.Navigation("BooksCategories");
                });

            modelBuilder.Entity("DAL2.Entitys.Chapter", b =>
                {
                    b.Navigation("Pages");
                });

            modelBuilder.Entity("DAL2.Entitys.Language", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DAL2.Entitys.Status", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("DAL2.Entitys.Tag", b =>
                {
                    b.Navigation("BookTags");
                });
#pragma warning restore 612, 618
        }
    }
}
