﻿using DAL2.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Configuration;

public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
{
    public void Configure(EntityTypeBuilder<BookCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(bc => bc.Book)
            .WithMany(b => b.BookCategory)
            .HasForeignKey(bc => bc.BookId);

        builder.HasOne(bc => bc.Category)
            .WithMany(c => c.BooksCategories)
            .HasForeignKey(bc => bc.CategoryId);
    }
}