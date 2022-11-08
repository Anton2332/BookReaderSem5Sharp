using DAL2.Entitys;
using DAL2.Seeding;
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
            .HasForeignKey(bt => bt.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bt => bt.Tag)
            .WithMany(t => t.BookTags)
            .HasForeignKey(bt => bt.TagId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(x => new
        {
            x.BookId,
            x.TagId
        }).IsUnique();

        new BookTagSeeder().Seed(builder);
    }
}