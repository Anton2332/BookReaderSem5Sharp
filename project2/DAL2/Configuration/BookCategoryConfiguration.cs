using DAL2.Entitys;
using DAL2.Seeding;
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
            .HasForeignKey(bc => bc.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bc => bc.Category)
            .WithMany(c => c.BooksCategories)
            .HasForeignKey(bc => bc.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(x => new
        {
            x.BookId,
            x.CategoryId
        }).IsUnique();
        
        new BookCategorySeeder().Seed(builder);
    }
}