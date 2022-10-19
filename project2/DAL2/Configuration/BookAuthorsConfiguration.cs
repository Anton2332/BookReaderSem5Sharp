using DAL2.Entitys;
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
            .HasForeignKey(ba => ba.BookId);

        builder.HasOne(ba => ba.Author)
            .WithMany(b => b.BookAuthor)
            .HasForeignKey(ba => ba.AuthorId);
    }
}