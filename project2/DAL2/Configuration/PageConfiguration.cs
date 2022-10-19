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

        builder.Property(p => p.XmlContent).HasColumnType("xml");

        builder.Ignore(p => p.XmlValueWrapper);
        //     this.Property(c => c.XmlContent).HasColumnType("xml");
        //
        //     this.Ignore(c => c.XmlValueWrapper);
    }
}