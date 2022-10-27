using DAL2.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Configuration;

public class BookTagsConfiguration : IEntityTypeConfiguration<BookTag>
{
    public void Configure(EntityTypeBuilder<BookTag> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(bt => bt.Book)
            .WithMany(b => b.BookTag)
            .HasForeignKey(bt => bt.BookId);

        builder.HasOne(bt => bt.Tag)
            .WithMany(t => t.BookTags)
            .HasForeignKey(bt => bt.TagId);
        
        
    }
}