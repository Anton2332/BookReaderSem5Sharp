using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class ChapterSeeder : ISeeder<Chapter>
{
    private readonly List<Chapter> _chapters = new()
    {

    };

    public void Seed(EntityTypeBuilder<Chapter> builder) => builder.HasData(_chapters);
}