using DAL2.Entitys;
using DAL2.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL2.Seeding;

public class TagSeeder : ISeeder<Tag>
{
    private readonly List<Tag> _tags = new()
    {

    };

    public void Seed(EntityTypeBuilder<Tag> builder) => builder.HasData(_tags);
}