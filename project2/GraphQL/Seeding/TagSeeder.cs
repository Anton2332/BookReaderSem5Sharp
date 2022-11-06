using GraphQL.Entitys;
using GraphQL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Seeding;

public class TagSeeder : ISeeder<Tag>
{
    private readonly List<Tag> _tags = new()
    {

    };

    public void Seed(EntityTypeBuilder<Tag> builder) => builder.HasData(_tags);
}