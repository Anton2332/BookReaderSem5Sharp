using DAL2.Entitys;
using DAL2.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Image).IsRequired();
        
        builder.HasOne(b => b.Language)
            .WithMany(l => l.Books)
            .HasForeignKey(b => b.LanguageId);

        builder.HasOne(b => b.Status)
            .WithMany(s => s.Books)
            .HasForeignKey(b => b.StatusId);

        builder.Property(b => b.Image).IsRequired();

        builder.Property(b => b.Description)
            .HasColumnType("text")
            ;
        
        new BookSeeder().Seed(builder);
        
    }
}