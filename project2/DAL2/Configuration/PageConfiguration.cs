using DAL2.Entitys;
using DAL2.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Configuration;

public class PageConfiguration : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(p => p.Chapter)
            .WithMany(ch => ch.Pages)
            .HasForeignKey(p => p.ChapterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.Content)
            .HasColumnType("text")
            .IsRequired()
            ;

        builder.Property(p => p.Image)
            .IsRequired()
            ;
        
        new PageSeeder().Seed(builder);
    }
}