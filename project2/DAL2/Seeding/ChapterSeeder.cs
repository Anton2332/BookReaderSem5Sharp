using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class ChapterSeeder : ISeeder<Chapter>
{
    private readonly List<Chapter> _chapters = new()
    {

    };

    public void Seed(EntityTypeBuilder<Chapter> builder) => builder.HasData(_chapters);
}