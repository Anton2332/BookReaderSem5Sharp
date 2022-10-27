using DAL2.Entitys;
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
            .HasForeignKey(p => p.ChapterId);

        builder.Property(p => p.Content)
            .HasColumnType("text")
            .IsRequired()
            ;

        builder.Property(p => p.Image)
            .IsRequired()
            ;
        

    }
}