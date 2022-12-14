using DAL2.Entitys;
using DAL2.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Configuration;

public class BookAuthorsConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthor)
            .HasForeignKey(ba => ba.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ba => ba.Author)
            .WithMany(b => b.BookAuthor)
            .HasForeignKey(ba => ba.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(x => new
        {
            x.BookId,
            x.AuthorId
        }).IsUnique();
        
        new BookAuthorSeeder().Seed(builder);
    }
}