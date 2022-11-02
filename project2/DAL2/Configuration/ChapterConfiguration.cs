using DAL2.Entitys;
using DAL2.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Configuration;

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>   
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(ch => ch.Book)
            .WithMany(b => b.Chapters)
            .HasForeignKey(ch => ch.BookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ch => ch.User)
            .WithMany(u => u.Chapters)
            .HasForeignKey(ch => ch.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(x => new
        {
            x.BookId,
            x.ChapterId
        }).IsUnique();

        builder.Property(x => x.ChapterName).HasMaxLength(250)
            ;

        new ChapterSeeder().Seed(builder);
    }
}